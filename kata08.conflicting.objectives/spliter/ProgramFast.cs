using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace spliter
{
    internal class ProgramFast
    {
        public static void Run(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var words = File.ReadAllLines("wordlist.txt");
            Console.WriteLine($"{sw.Elapsed}");
            sw.Restart();
            var sums = FindSums(words).ToArray();
            sw.Stop();
            Console.WriteLine($"{sw.Elapsed}");
            sw.Restart();
            foreach(var sum in sums)
            {
                Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
            }
            Console.WriteLine($"{sw.Elapsed}");
        }

        public static IEnumerable<(string, string, string)> FindSums(string[] words)
        {
            var result = new List<(string, string, string)>();

            string[] sumCandidates = words.Where(w => w.Length == 6).ToArray();
            HashSet<string> summands = words.Where(w => w.Length < 6).ToHashSet();

            foreach (string sumCandidate in sumCandidates)
            {
                var augends = summands.Where(s => sumCandidate.StartsWith(s)).ToArray();

                foreach(string augend in augends)
                {
                    string addend = sumCandidate.Substring(augend.Length);
                    if(summands.Contains(addend))
                    {
                        yield return (augend, addend, sumCandidate);
                    }
                }
            }
        }
    }
}