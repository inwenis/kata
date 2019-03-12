using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "String x = \"some words \\\" more\";";
            string commentsRemoved = JavaCommentsRemover.RemoveComments(code);
            System.Console.WriteLine(commentsRemoved);
            int count = JavaLinesCounter.Count(code);
            System.Console.WriteLine(count);
        }
    }
}
