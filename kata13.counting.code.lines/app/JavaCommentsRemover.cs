using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

public static class JavaCommentsRemover
{
    private static string MatchString = "\"((?:\\\"|[^\"])*?)\"";
    private static string MatchLineComments = "(//.*)";
    private static string MatchBlockComments = @"(/\*.*?\*/)";

    public static string RemoveComments(string code)
    {
        List<KeyValuePair<string, string>> strings = null;
        string codeWithStringsReplaced = ReplaceStrings(code, ref strings);
        string codeWithOutComments = RemoveCommentsInternal(codeWithStringsReplaced);
        string stringsReadded = ReAddStrings(codeWithOutComments, strings);
        return stringsReadded;
    }

    // the `code` can not contain "//" or "/*" or "*/" in string literals for this method to work correctly
    private static string RemoveCommentsInternal(string code)
    {
        bool anyMatch = true;
        while (anyMatch)
        {
            Match lineCommentMatch = Regex.Match(code, MatchLineComments, RegexOptions.Multiline);
            Match blockCommentMatch = Regex.Match(code, MatchBlockComments, RegexOptions.Singleline);
            Match firstMatch = null;
            anyMatch = lineCommentMatch.Success || blockCommentMatch.Success;

            if (lineCommentMatch.Success && !blockCommentMatch.Success)
            {
                firstMatch = lineCommentMatch;
            }
            else if (!lineCommentMatch.Success && blockCommentMatch.Success)
            {
                firstMatch = blockCommentMatch;
            }
            else if (lineCommentMatch.Index < blockCommentMatch.Index)
            {
                firstMatch = lineCommentMatch;
            }
            else if (lineCommentMatch.Index > blockCommentMatch.Index)
            {
                firstMatch = blockCommentMatch;
            }

            if (anyMatch)
            {
                string comment = firstMatch.Groups[1].Value;
                code = RemoveComment(code, comment);
            }
        }

        return code;
    }

    private static string RemoveComment(string code, string comment)
    {
        int newLinesCount = comment.Count(x => x == '\n');
        string newLines = string.Join("", Enumerable.Repeat('\n', newLinesCount));
        code = ReplaceFirst(code, comment, newLines);
        return code;
    }

    private static string ReplaceFirst(string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }

    private static string ReplaceStrings(string code, ref List<KeyValuePair<string, string>> replacedStrings)
    {
        replacedStrings = new List<KeyValuePair<string, string>>();
        var matches = Regex.Matches(code, MatchString);
        foreach (Match match in matches)
        {
            string stringWithoutQuotes = match.Groups[1].Value;
            string id = Guid.NewGuid().ToString();
            code = code.Replace(stringWithoutQuotes, id);
            replacedStrings.Add(new KeyValuePair<string, string>(id, stringWithoutQuotes));
        }
        return code;
    }

    private static string ReAddStrings(string code, List<KeyValuePair<string, string>> strings)
    {
        foreach (var item in strings)
        {
            code = code.Replace(item.Key, item.Value);
        }
        return code;
    }
}