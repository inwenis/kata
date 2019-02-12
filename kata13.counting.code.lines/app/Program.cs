using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string code =
            " int x;     \n" +
            " // comment \n" +
            " int y;     \n";
            string commentsRemoved = JavaCommentsRemover.RemoveComments(code);
            System.Console.WriteLine(commentsRemoved);
            int count = JavaLinesCounter.Count(code);
            System.Console.WriteLine(count);
        }
    }
}
