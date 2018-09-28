using System;
using System.Collections.Concurrent;
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

            var resultLost = TestAnagramalist(words);

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
            var i = 20000;
            var batches = words.Length/i;
            batches += 1;

            var dic = new ConcurrentDictionary<string, string>();

            Parallel.For(0, batches, (batch) =>
            {
                var from = batch * i;
                var to = (batch + 1) * i;
                for (int j = from; j < to && j < words.Length; j++)
                {
                    string word = words[j];
                    var key = KeyFrom(word);
                    dic.AddOrUpdate(key, word, (_, curVal) => curVal + " " + word);
                }
            });

//            var parallelLoopResult = Parallel.ForEach(words, word =>
//            {
//                string ordered = new string(word.OrderBy(c => c).ToArray());
//                dic.AddOrUpdate(ordered, word, (s, s1) => s + " " + s1);
//                
//            });

//            foreach (var word in words.Where(x => x.Length > 1))
//            {
//                string ordered = new string(word.OrderBy(c => c).ToArray());
//
//                if (dic.ContainsKey(ordered))
//                {
//                    dic[ordered] += " " + word;
//                }
//                else
//                {
//                    dic[ordered] = word;
//                }
//            }

            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }

        private static int KeyFrom(string word)
        {
            
        }
    }
}
