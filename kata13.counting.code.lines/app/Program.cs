using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "String s = \"this no comment // asdfsafd \"; /* stil no comment\n" +
                          "still no comments                                              \n" +
                          "end */ int code;";
            string commentsRemoved = JavaCommentsRemover.RemoveComments(code);
            System.Console.WriteLine(commentsRemoved);
            int count = JavaLinesCounter.Count(code);
            System.Console.WriteLine(count);
        }
    }
}
