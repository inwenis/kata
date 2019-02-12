using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            JavaLinesCounter.Count("/* this line is still code */ int x; /* more */");
            
        }
    }
}
