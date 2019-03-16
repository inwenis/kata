using System.Linq;
using System.Text.RegularExpressions;

public static class JavaLinesCounter
{
    public static int Count(string code)
    {
        string codeWithoutComments = JavaCommentsRemover.RemoveComments(code);
        //string codeWithoutComments = JavaNoRegexCommentsRemover.RemoveComments(code); // uncomment this line to use the other CommentsRemover
        string[] split = codeWithoutComments.Split('\n');
        int loc = split.Count(line => line.Trim() != "");
        return loc;
    }
}