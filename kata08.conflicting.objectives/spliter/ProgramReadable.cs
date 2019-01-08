using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace spliter
{
    public class ProgramReadable
    {
        public static void Run(string[] args)
        {
            var words = File.ReadAllLines("wordlist.txt");
            var sums = FindSums(words);
            foreach(var sum in sums)
            {
                Console.WriteLine($"{sum.Item1} + {sum.Item2} => {sum.Item3}");
            }
        }

        public static IEnumerable<(string, string, string)> FindSums(IEnumerable<string> words)
        {
            var result = new List<(string, string, string)>();

            string[] sumCandidates = words.Where(w => w.Length == 6).ToArray();
            HashSet<string> summands = words.Where(w => w.Length < 6).ToHashSet();

            foreach (string sumCandidate in sumCandidates)
            {
                var augends = summands.Where(s => sumCandidate.StartsWith(s));

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
