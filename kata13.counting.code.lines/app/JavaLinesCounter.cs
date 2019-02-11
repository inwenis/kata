using System.Linq;
using System.Text.RegularExpressions;

public static class JavaLinesCounter
{
    public static int Count(string code)
    {
        if(code.Length == 0)
            return 0;
        else
        {
            string[] split = code.Split('\n');
            int linesCount = split.Length;
            int commentLines = split.Count(line => Regex.IsMatch(line, @"^\s*//"));
            return linesCount - commentLines;
        }
    }
}