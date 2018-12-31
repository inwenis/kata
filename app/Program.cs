using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            BloomFilter bm = new BloomFilter(64 * 1024, 5);
            var words = File.ReadAllLines("wordlist.txt");
            System.Console.WriteLine("Adding word to bloom filter...");
            foreach(var word in words)
            {
                bm.Add(word);
            }
            System.Console.WriteLine("Done adding word to bloom filter");

            System.Console.WriteLine("Checking if all words belong to dictionary...");
            foreach(var word in words)
            {
                var check = bm.Check(word);
                if(!check)
                {
                    System.Console.WriteLine("we have a problem!");
                    System.Console.WriteLine(word);
                }
            }
            System.Console.WriteLine("Done checking if all words belong to dictionary");

            System.Console.WriteLine("Gimmie a word and I'll check if it is in the dictionary");
            System.Console.WriteLine("type `q!` (without the backticks) to exit");
            System.Console.WriteLine("type `d!` (without the backticks) to dump bitmap as binary");

            TestUsingRandom5LetterWords(bm);

            // string input;
            // do
            // {
            //     input = System.Console.ReadLine();
            //     if(input == "d!")
            //     {
            //         System.Console.WriteLine(bm.DumpBitMapToBinary());
            //     }
            //     else
            //     {
            //         System.Console.WriteLine($"Checking if {input} belongs to dictionary");
            //         var check = bm.Check(input);
            //         System.Console.WriteLine(check);
            //     }
            // }while(input != "q!");
        }

        private static void TestUsingRandom5LetterWords(BloomFilter bm)
        {
            var words = File.ReadAllLines("wordlist.txt");
            Random random = new Random();
            int total = 0;
            int falsePositive = 0;
            while(true)
            {
                char[] chars = Enumerable
                    .Range(1, 5)
                    .Select(x => (char) random.Next('a', 'z'))
                    .ToArray();
                string word = new string(chars);
                if(bm.Check(word) && !words.Any(x => x == word))
                {
                    falsePositive++;
                }
                total++;
                System.Console.WriteLine($"{falsePositive}/{total} = {(double)falsePositive/total}");
            }
        }
    }
}
