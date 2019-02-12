using System.Linq;
using System.Text.RegularExpressions;

public static class JavaLinesCounter
{
    public static int Count(string code)
    {
        string codeWithoutComments = JavaCommentsRemover.RemoveComments(code);
        string[] split = codeWithoutComments.Split('\n');
        int loc = split.Count(line => line.Trim() != "");
        return loc;
    }
}