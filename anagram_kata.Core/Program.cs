using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Anagramalist.Implementations;

namespace anagram_kata2
{
    class Program
    {
        static void Main(string[] args)
        {
            // the data comes from here http://codekata.com/kata/kata06-anagrams/
            var expectedNumberOfAnagrams = 20683;
            var allLines = File.ReadAllLines("wordlist.txt");
            var words = allLines
                .Where(x => x != string.Empty)
                .ToArray();

            var allImplementations = new List<IAnagramalist>()
            {
                new AnagramalistParrallelGrouping_CustomStruct(),
                new AnagramalistParrallelForEach_CustomStruct(),
                new AnagramalistDictionary_CustomComparator(),
                new AnagramalistLinq(),
                new AnagramalistParallelLinq(),
                new AnagramalistConcurentDictionary(),
                new AnagramalistDictionary(),
                new AnagramalistParallelForWithBatches(),
                new AnagramalistConcurentDictionary_CutomComparator()
            };

            var testRepeatCount = 2;
            var results = new List<dynamic>();
            foreach (var sut in allImplementations)
            {
                var name = sut.GetType().Name;
                Console.WriteLine($"{name}");
                var timeInSeconds = Tester.RunMultileTests(sut, words, testRepeatCount, expectedNumberOfAnagrams);
                results.Add(new {name = name, time = timeInSeconds});
            }

            int index = 1;
            foreach (var result in results.OrderBy(x => x.time))
            {
                Console.WriteLine($"{index}. {result.name, -49} average from {testRepeatCount} tests: {result.time:f6}s");
                index++;
            }
        }
    }
}