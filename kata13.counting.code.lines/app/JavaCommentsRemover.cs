using System.Linq;
using System.Text.RegularExpressions;

public static class JavaCommentsRemover
{
    private static string MatchSingleLineComments = "^[^\"]*?(//.*)"; // no string before
    private static string MatchSingleLineCommentsAfterString = "\".*\".*?(//.*)";
    private static string MatchSingleLineBlockComments = @"(/\*.*?\*/)";

    public static string RemoveComments(string code)
    {
        string commentsRemoved = code;

        var matches = Regex.Matches(commentsRemoved, MatchSingleLineComments, RegexOptions.Multiline);
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
        return commentsRemoved;
    }
}