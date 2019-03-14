using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "//line comment*/ \nint x = 0;/* //line comment*/";
            string commentsRemoved = JavaCommentsRemover.RemoveComments(code);
            System.Console.WriteLine(commentsRemoved);
            int count = JavaLinesCounter.Count(code);
            System.Console.WriteLine(count);
        }
    }
}
