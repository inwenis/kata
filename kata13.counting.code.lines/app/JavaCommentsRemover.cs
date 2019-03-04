using System.Linq;
using System.Text.RegularExpressions;

public static class JavaCommentsRemover
{
    private static string MatchSingleLineComments = "^[^\"]*(//.*)"; // no string before
    private static string MatchSingleLineCommentsAfterString = "\".*\".*?(//.*)";
    private static string MatchSingleLineBlockComments = @"/\*.*?\*/";

    public static string RemoveComments(string code)
    {
        if(code == "")
        {
            return code;
        }
        else
        {
            Match result = Regex.Match(code, MatchSingleLineComments);
            string replaced;
            if(result.Success)
            {
                replaced = code.Replace(result.Groups[1].Value, "");
            }
            else
            {
                replaced = code;
            }

            result = Regex.Match(code, MatchSingleLineCommentsAfterString);
            if(result.Success)
            {
                replaced = replaced.Replace(result.Groups[1].Value, "");
            }

            replaced = Regex.Replace(replaced, MatchSingleLineBlockComments, "", RegexOptions.Singleline);
            return replaced;
        }
    }
}