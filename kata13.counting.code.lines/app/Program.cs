using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "int x = 0; // comment \n" +
                "int y = 1;              ";
            string commentsRemoved = JavaCommentsRemover.RemoveComments(code);
            System.Console.WriteLine(commentsRemoved);
            int count = JavaLinesCounter.Count(code);
            System.Console.WriteLine(count);
        }
    }
}
