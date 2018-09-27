using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

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

            double sumSeconds = 0;

            for (int i = 0; i < 10; i++)
            {
                var result = TestAnagramalist(words);
                sumSeconds += result.Time.TotalSeconds;
                if (result.Anagrams.Length != 20683)
                {
                    throw new Exception("wrong number of anagrams");
                }
            }

            Console.WriteLine("mean time:");
            Console.WriteLine(sumSeconds/10);

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }

        private static TestResult TestAnagramalist(string[] words)
        {
            var sw = new Stopwatch();
            sw.Start();
            var allAnagrams = Anagramalist.FindAllAnagrams(words);
            sw.Stop();
            return new TestResult
            {
                Anagrams = allAnagrams,
                Time = sw.Elapsed
            };
        }
    }

    internal class TestResult
    {
        public string[] Anagrams { get; set; }
        public TimeSpan Time { get; set; }
    }

    public class Anagramalist
    {
        public static string[] FindAllAnagrams(string[] words)
        {
            var anagrams = words
                .GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
                .Where(g => g.Count() > 1)
                .Select(x => string.Join(" ", x))
                .ToArray();

            return anagrams;
        }
    }
}
