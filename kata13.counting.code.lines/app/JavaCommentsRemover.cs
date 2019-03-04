using System.Linq;
using System.Text.RegularExpressions;

public static class JavaCommentsRemover
{
    private static string MatchSingleLineComments = "^[^\"]*(//.*)"; // no string before
    private static string MatchSingleLineCommentsAfterString = "\".*\".*?(//.*)";
    private static string MatchSingleLineBlockComments = @"/\*.*?\*/";

    public static string RemoveComments(string code)
    {
        string commentsRemoved = code;

        Match result = Regex.Match(code, MatchSingleLineComments);
        if(result.Success)
        {
            commentsRemoved = code.Replace(result.Groups[1].Value, "");
        }

        result = Regex.Match(code, MatchSingleLineCommentsAfterString);
        if(result.Success)
        {
            commentsRemoved = commentsRemoved.Replace(result.Groups[1].Value, "");
        }

        commentsRemoved = Regex.Replace(commentsRemoved, MatchSingleLineBlockComments, "", RegexOptions.Singleline);
        return commentsRemoved;
    }
}