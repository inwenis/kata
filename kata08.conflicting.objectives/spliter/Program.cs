using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace spliter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            
            Console.WriteLine($"Running {nameof(ProgramReadable)}");
            sw.Start();
            ProgramReadable.Run(args);
            var readableRunningTime = sw.Elapsed;
            
            Console.WriteLine($"Running {nameof(ProgramFast)}");
            sw.Restart();
            ProgramFast.Run(args);
            var fastRunningTime = sw.Elapsed;

            Console.WriteLine($"Readable was running for: {readableRunningTime}");
            Console.WriteLine($"Fast was running for: {fastRunningTime}");

            Console.WriteLine("Running both version again to compare output");

            var words = File.ReadAllLines("wordlist.txt");
            var sumsFoundWithReadable = ProgramReadable.FindSums(words).ToArray();
            var sumsFoundFast = ProgramFast.FindSums(words).ToArray();
            Console.WriteLine($"sums found with readable: {sumsFoundWithReadable.Count()}");
            Console.WriteLine($"sums found with fast: {sumsFoundFast.Count()}");
            
            var missedByFast = sumsFoundWithReadable.Except(sumsFoundFast);
            Console.WriteLine($"missed by fast: {missedByFast.Count()}");
            Console.WriteLine("here are the first 10:");
            foreach (var sum in missedByFast.Take(10))
            {
                Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
            }

            Console.WriteLine("missed by readable:");
            var missedByReadable = sumsFoundFast.Except(sumsFoundWithReadable);
            if (missedByReadable.Any())
            {
                foreach (var sum in missedByReadable)
                {
                    Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
                }
            }
            else
            {
                Console.WriteLine("None missed");
            }
        }
    }
}
