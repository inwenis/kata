using System.Collections.Generic;
using System.IO;

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
            string input;
            do
            {
                input = System.Console.ReadLine();
                if(input == "d!")
                {
                    System.Console.WriteLine(bm.DumpBitMapToBinary());
                }
                else
                {
                    System.Console.WriteLine($"Checking if {input} belongs to dictionary");
                    var check = bm.Check(input);
                    System.Console.WriteLine(check);
                }
            }while(input != "q!");
        }
    }
}
