using System.Linq;
using System.Text.RegularExpressions;

public static class JavaLinesCounter
{
    private static string MatchSingleLineComments = @"^\s*//";
    // Matches:
    // " // comment"
    // "\t// comment"

    private static string MatchSingleLineBlockComments = @"/\*.*?\*/\s*$";
    // Matches:
    // /*block comment*/
    // Does not match:
    // /*block comment*/ int x;

    private static string MatchBlockCommentOpening = @"/\*";
    // Matches beginning of block comment /*...
    private static string MatchBlockCommentClosing = @"\*/";
    // Matches end of block comment ...*/

    public static int Count(string code)
    {
        if(code.Length == 0)
            return 0;
        else
        {
            string[] split = code.Split('\n');
            int linesCount = 0;
            int singleLinesComments = 0;
            int singleLinesBlockComments = 0;
            int emptyLines = 0;
            int blockCommentLines = 0;
            bool blockCommentOpen = false;
            foreach(string line in split)
            {
                if(blockCommentOpen && Regex.IsMatch(line, MatchBlockCommentClosing))
                {
                    blockCommentLines += 1;
                    blockCommentOpen = false;
                }
                else if(blockCommentOpen)
                {
                    blockCommentLines += 1;
                }
                else if (Regex.IsMatch(line, MatchSingleLineComments))
                {
                    singleLinesComments += 1;
                }
                else if (line.Trim() == "")
                {
                    emptyLines += 1;
                }
                else if (Regex.IsMatch(line, MatchSingleLineBlockComments))
                {
                    singleLinesBlockComments += 1;
                }
                else if (Regex.IsMatch(line, MatchBlockCommentOpening) && !Regex.IsMatch(line, MatchBlockCommentClosing))
                {
                    blockCommentLines += 1;
                    blockCommentOpen = true;
                }
                else
                {
                    linesCount += 1;
                }
            }
            return linesCount;
        }
    }
}