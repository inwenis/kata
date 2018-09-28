using System;
using System.Diagnostics;

namespace anagram_kata2
{
    public class Tester
    {
        public static double RunMultileTests(IAnagramalist sut, string[] words, int testRepeats, int expectedNumberOfAnagrams)
        {
            // run the anagramalist here so the JITer will compile all code
            var resultLost = RunSingleTest(sut, words);

            double sumSeconds = 0;
            for (int i = 0; i < testRepeats; i++)
            {
                var result = RunSingleTest(sut, words);
                sumSeconds += result.Time.TotalSeconds;
                if (result.Anagrams.Length != expectedNumberOfAnagrams)
                {
                    Console.WriteLine("Wrong Number of anagrams!");
                }
            }

            var average = sumSeconds / testRepeats;
            return average;
        }

        private static TestResult RunSingleTest(IAnagramalist sut, string[] words)
        {
            var sw = new Stopwatch();
            sw.Start();
            var allAnagrams = sut.FindAllAnagrams(words);
            sw.Stop();
            return new TestResult
            {
                Anagrams = allAnagrams,
                Time = sw.Elapsed
            };
        }

        private class TestResult
        {
            public string[] Anagrams { get; set; }
            public TimeSpan Time { get; set; }
        }
    }
}