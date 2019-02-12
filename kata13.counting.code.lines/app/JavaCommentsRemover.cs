using System.Linq;
using System.Text.RegularExpressions;

public static class JavaCommentsRemover
{
    private static string MatchSingleLineComments = @"//.*$";

    public static string RemoveComments(string code)
    {
        if(code == "")
        {
            return code;
        }
        else
        {
            string result = Regex.Replace(code, MatchSingleLineComments, "");
            return result;
        }
    }
}