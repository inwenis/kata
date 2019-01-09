using System;
using System.IO;
using System.Linq;

namespace spliter
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramReadable.Run(args);
            ProgramFast.Run(args);

            var words = File.ReadAllLines("wordlist.txt");
            var sumsFoundWithReadable = ProgramReadable.FindSums(words).ToArray();
            var sumsFoundFast = ProgramFast.FindSums(words).ToArray();
            Console.WriteLine($"sumsFoundWithReadable: {sumsFoundWithReadable.Count()}");
            Console.WriteLine($"sumsFoundFast: {sumsFoundFast.Count()}");
            Console.WriteLine("missed by fast:");
            var missedByFast = sumsFoundWithReadable.Except(sumsFoundFast);
            foreach (var sum in missedByFast)
            {
                Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
            }

            Console.WriteLine("missed by readable:");
            var missedByReadable = sumsFoundFast.Except(sumsFoundWithReadable);
            foreach (var sum in missedByReadable)
            {
                Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
            }
        }
    }
}
