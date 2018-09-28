using System;
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

            var linq = new AnagramalistLinq();
            var concurentDictionary = new AnagramalistConcurentDictionary();

            var time1 = Tester.RunMultileTests(linq, words, 5, expectedNumberOfAnagrams);
            Console.WriteLine($"average time: {time1}");

            var time2 = Tester.RunMultileTests(concurentDictionary, words, 5, expectedNumberOfAnagrams);
            Console.WriteLine($"average time: {time2}");

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}