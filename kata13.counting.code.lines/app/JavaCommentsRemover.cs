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
        foreach (var match in matches.Cast<Match>())
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
        MatchCollection matches = Regex.Matches(code, MatchLineComments, RegexOptions.Multiline);
        foreach (var match in matches.Cast<Match>())
        {
            code = code.Replace(match.Groups[1].Value, "");
        }
        return code;
    }

    private static string RemoveBlockComments(string code)
    {
        MatchCollection matches = Regex.Matches(code, MatchBlockComments, RegexOptions.Singleline);
        foreach (var match in matches.Cast<Match>())
        {
            var newLinesCount = match.Groups[1].Value.Count(x => x == '\n');
            var replaceWith = string.Join("", Enumerable.Repeat('\n', newLinesCount));
            code = code.Replace(match.Groups[1].Value, replaceWith);
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