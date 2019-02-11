using System.Linq;
using System.Text.RegularExpressions;

public static class JavaLinesCounter
{
    private static string MatchSingleLineComments = @"^\s*//";
    // Matches:
    // " // comment"
    // "\t// comment"

    private static string MatchBlockComments = @"/\*.*\*/";
    // Matches:
    // "/*block comment \n more comment \n last line*/
    public static int Count(string code)
    {
        if(code.Length == 0)
            return 0;
        else
        {
            string[] split = code.Split('\n');
            int linesCount = split.Length;
            int commentLines = split.Count(line => Regex.IsMatch(line, MatchSingleLineComments));
            int emptyLines = split.Count(line => line.Trim() == "");
            int multiLineComments = 0;

            Match match = Regex.Match(code, MatchBlockComments, RegexOptions.Singleline);
            if(match.Success)
            {
                multiLineComments = match.Value.Split('\n').Length;
            }

            return linesCount - commentLines - emptyLines - multiLineComments;
        }
    }
}