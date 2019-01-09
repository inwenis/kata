using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Text;

namespace spliter
{
    public class ProgramFast
    {
        public static void Run(string[] args)
        {
            var words = File.ReadAllLines("wordlist.txt");
            var sums = FindSums(words).ToArray();
            StringBuilder output = new StringBuilder();
            foreach(var sum in sums)
            {
                output.AppendFormat("{0} + {1} => {2}\n", sum.Item1, sum.Item2, sum.Item3);
            }
            Console.WriteLine(output);
        }

        public static IEnumerable<(string, string, string)> FindSums(IEnumerable<string> words)
        {
            var result = new ConcurrentBag<(string, string, string)>();

            byte[][] wordsAsBytes = words.Select(word => Encoding.Unicode.GetBytes(word)).ToArray();

            byte[][] sumCandidates = words
                .Where(w => w.Length == 6)
                .Select(w => Encoding.Unicode.GetBytes(w))
                .ToArray();
            HashSet<byte[]> summands = words
                .Where(w => w.Length < 6)
                .Select(w => Encoding.Unicode.GetBytes(w))
                .ToHashSet(new Max6ElementsByteArrayComparer());

            Parallel.ForEach(sumCandidates, sumCandidate =>
            //foreach (var sumCandidate in sumCandidates)
            {
                var augends = summands.Where(s => StartsWith(sumCandidate,s)).ToArray();

                foreach(byte[] augend in augends)
                {
                    byte[] addend = new byte[12 - augend.Length];
                    Array.Copy(sumCandidate, augend.Length, addend, 0, 12 - augend.Length);
                    if(summands.Contains(addend))
                    {
                        result.Add((
                            Encoding.Unicode.GetString(augend),
                            Encoding.Unicode.GetString(addend),
                            Encoding.Unicode.GetString(sumCandidate)));
                    }
                }
            }
            );
            return result;
        }

        private static bool StartsWith(byte[] bigger, byte[] smaller)
        {
            for (int i = 0; i < smaller.Length; i++)
            {
                if (smaller[i] != bigger[i])
                    return false;
            }
            return true;
        }
    }

    public class Max6ElementsByteArrayComparer : IEqualityComparer<byte[]>
    {
        public bool Equals(byte[] x, byte[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] != y[i])
                        return false;
                }
                return true;
            }
        }

        public int GetHashCode(byte[] obj)
        {
            return Encoding.Unicode.GetString(obj).GetHashCode();
        }
    }
}