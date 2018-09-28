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

            var averageTimeSeconds = Tester.RunMultileTests(linq, words, 100, expectedNumberOfAnagrams);

            Console.WriteLine("mean time:");
            Console.WriteLine(averageTimeSeconds);

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}