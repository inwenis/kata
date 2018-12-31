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
            BloomFilter bm = new BloomFilter(8 * 64 * 1024, 5);
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
            System.Console.WriteLine();
            System.Console.WriteLine($"{"bitmap size",-11}|false positives");
            System.Console.WriteLine($"---------------------------");
            for (int i = 1; i <= 10; i++)
            {
                int bitmapSize = 64 * 1024 * i;
                bm = new BloomFilter(bitmapSize, 5);
                foreach(var word in words)
                {
                    bm.Add(word);
                }
                double falsePositives = TestUsingRandom5LetterWords(bm, words, 1000);
                System.Console.WriteLine($"{bitmapSize,-11}|{falsePositives}");
            }

            // System.Console.WriteLine("Gimmie a word and I'll check if it is in the dictionary");
            // System.Console.WriteLine("type `q!` (without the backticks) to exit");
            // System.Console.WriteLine("type `d!` (without the backticks) to dump bitmap as binary");
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

        private static double TestUsingRandom5LetterWords(BloomFilter bm, string[] words, int repeatCount)
        {
            Random random = new Random();
            int falsePositive = 0;
            for(int i = 0 ; i < repeatCount; i++)
            {
                string word = random.NextLowerCaseWord(5);
                if(bm.Check(word) && !words.Any(x => x == word))
                {
                    falsePositive++;
                }
            }
            return (double)falsePositive/repeatCount;
        }
    }
}
