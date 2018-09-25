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
            var words = allLines.Where(x => x != string.Empty).ToArray();

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
            var anagrams = words
                .GroupBy(word => word.Length)
                .Where(groupedByLength => groupedByLength.Count() > 1)
                .Where(x =>
                {
                    var ordered = new string(x.First().OrderBy(c => c).ToArray());
                    var sameLetters = x.Where(w => new string(w.OrderBy(c => c).ToArray()) == ordered);
                    return sameLetters.Count() > 1;
                })
                .Select(x =>
                {
                    var ordered = new string(x.First().OrderBy(c => c).ToArray());
                    var sameLetters = x.Where(w => new string(w.OrderBy(c => c).ToArray()) == ordered);
                    return string.Join(" ", sameLetters);
                })
                .ToArray();
            return anagrams;
        }
    }
}
