using System;
using System.IO;
using System.Linq;

namespace spliter
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("wordlist.txt");
            var sums = FindSums.In(words);
            foreach(var sum in sums)
            {
                Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
            }
        }
    }
}
