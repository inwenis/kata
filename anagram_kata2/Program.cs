using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                new AnagramalistLinq(),
                new AnagramalistParallelLinq(),
                new AnagramalistConcurentDictionary()
            };

            foreach (var sut in allImplementations)
            {
                var time = Tester.RunMultileTests(sut, words, 5, expectedNumberOfAnagrams);
                Console.WriteLine($"average time: {time}s    {sut.GetType()}");
            }

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}