using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagram_kata2
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("wordlist.txt");
            var words = allLines
                .Where(x => x != string.Empty)
                .ToArray();

            var sw = new Stopwatch();
            sw.Start();
            var allAnagrams = Anagramalist.FindAllAnagrams(words);
            sw.Stop();

            foreach (var anagram in allAnagrams)
            {
                Console.WriteLine(anagram);
            }

            Console.WriteLine($"time: {sw.Elapsed}");
            Console.WriteLine($"anagrams: {allAnagrams.Length} (expected: 20683)");
            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }

    public class Anagramalist
    {
        public static string[] FindAllAnagrams(string[] words)
        {
            var groupBy = words
                .GroupBy(word => word.Length)
                .ToArray();
            var groupByWhereAtLest2 = groupBy
                .Where(groupedByLength => groupedByLength.Count() > 1)
                .ToArray();
            var anagrams = groupByWhereAtLest2
                .SelectMany(x =>
                {
                    return x.GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
                        .Where(g => g.Count() > 1)
                        .Select(g => string.Join(" ", g));
                })
                .ToArray();

            return anagrams;
        }
    }
}
