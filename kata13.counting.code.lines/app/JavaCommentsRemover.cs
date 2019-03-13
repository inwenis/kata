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
        string lineCommentsRemoved = RemoveLineComments(codeWithStringsReplaced);
        string blockCommentsRemoved = RemoveBlockComments(lineCommentsRemoved);
        string stringsReadded = ReAddStrings(blockCommentsRemoved, strings);
        return stringsReadded;
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

    private static string RemoveLineComments(string code)
    {
        var matches = Regex.Matches(code, MatchLineComments, RegexOptions.Multiline);
        foreach (Match match in matches)
        {
            string comment = match.Groups[1].Value;
            code = code.Replace(comment, "");
        }
        return code;
    }

    private static string RemoveBlockComments(string code)
    {
        MatchCollection matches = Regex.Matches(code, MatchBlockComments, RegexOptions.Singleline);
        foreach (Match match in matches)
        {
            string comment = match.Groups[1].Value;
            int newLinesCount = comment.Count(x => x == '\n');
            string newLines = string.Join("", Enumerable.Repeat('\n', newLinesCount));
            code = code.Replace(comment, newLines);
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