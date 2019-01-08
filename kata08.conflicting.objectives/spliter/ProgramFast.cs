using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace spliter
{
    internal class ProgramFast
    {
        public static void Run(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var words = File.ReadAllLines("wordlist.txt");
            var read = sw.Elapsed;
            Console.WriteLine($"{sw.Elapsed}");
            sw.Restart();
            var sums = FindSums(words).ToArray();
            sw.Stop();
            var find = sw.Elapsed;
            Console.WriteLine($"{sw.Elapsed}");
            sw.Restart();
            foreach(var sum in sums)
            {
                Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
            }
            var write = sw.Elapsed;
            Console.WriteLine($"{sw.Elapsed}");
            Console.WriteLine($"read:{read} find:{find} write:{write}");
        }

        public static IEnumerable<(string, string, string)> FindSums(string[] words)
        {
            var result = new ConcurrentBag<(string, string, string)>();

            string[] sumCandidates = words.Where(w => w.Length == 6).ToArray();
            HashSet<string> summands = words.Where(w => w.Length < 6).ToHashSet();

            Parallel.ForEach(sumCandidates, sumCandidate => {
                var augends = summands.Where(s => sumCandidate.StartsWith(s)).ToArray();

                foreach(string augend in augends)
                {
                    string addend = sumCandidate.Substring(augend.Length);
                    if(summands.Contains(addend))
                    {
                        result.Append((augend, addend, sumCandidate));
                    }
                }
            });
            return result;
        }
    }
}