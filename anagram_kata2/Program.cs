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

            var implementations = new List<IAnagramalist>()
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

            Tester.TestAll(words, expectedNumberOfAnagrams, implementations, testRepeatCount: 50);
        }
    }
}