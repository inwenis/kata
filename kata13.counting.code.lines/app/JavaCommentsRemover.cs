using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

public static class JavaCommentsRemover
{
    private static string MatchSingleLineComments = "^[^\"]*?(//.*)"; // no string before
    private static string MatchSingleLineCommentsAfterString = "\".*\".*?(//.*)";
    private static string MatchSingleLineBlockComments = @"(/\*.*?\*/)";

    private static string MatchString = "\"(.*?)\"";

    public static string RemoveComments(string code)
    {
        var strings = new List<KeyValuePair<string, string>>();
        var matches = Regex.Matches(code, MatchString);
        foreach(var match in matches.Cast<Match>())
        {
            string toBeRemoved = match.Groups[1].Value;
            string id = Guid.NewGuid().ToString();
            code = code.Replace(toBeRemoved, id);
            strings.Add(new KeyValuePair<string, string>(id, toBeRemoved));
        }

        string commentsRemoved = code; // todo

        matches = Regex.Matches(commentsRemoved, MatchSingleLineComments, RegexOptions.Multiline);
        foreach(var match in matches.Cast<Match>())
        {
            commentsRemoved = commentsRemoved.Replace(match.Groups[1].Value, "");
        }

        var result = Regex.Match(code, MatchSingleLineCommentsAfterString); // bug, should match on commentsRemoved
        if(result.Success)
        {
            commentsRemoved = commentsRemoved.Replace(result.Groups[1].Value, "");
        }

        matches = Regex.Matches(commentsRemoved, MatchSingleLineBlockComments, RegexOptions.Singleline);
        foreach(var match in matches.Cast<Match>())
        {
            var newLinesCount = match.Groups[1].Value.Count(x => x == '\n');
            var replaceWith = string.Join("", Enumerable.Repeat('\n', newLinesCount));
            commentsRemoved = commentsRemoved.Replace(match.Groups[1].Value, replaceWith);
        }

        foreach(var item in strings)
        {
            commentsRemoved = commentsRemoved.Replace(item.Key, item.Value);
        }

        return commentsRemoved;
    }
}