using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace test_string_vs_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\git\anagram_kata2\anagram_kata2\wordlist.txt";

            var allLines = File.ReadAllLines(path);
            var words = allLines
                .Where(x => x != string.Empty)
                .ToArray();

            var count = 300000;
            var strings = new string[count];
            var structs = new IRepresentOrderdString[count];

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                structs[i].one = (ulong) random.Next();
                structs[i].two = (ulong) random.Next();
                structs[i].three = (ulong) random.Next();

                strings[i] = words[random.Next(words.Length)];
            }

            var results = new bool[count/2];
            Stopwatch structSW = new Stopwatch();
            structSW.Start();
            for (int i = 0; i < count/2; i++)
            {
                results[i] = structs[i] == structs[count - i - 1];
            }
            structSW.Stop();

            Stopwatch stringSW = new Stopwatch();
            stringSW.Start();
            for (int i = 0; i < count/2; i++)
            {
                results[i] = strings[i] == strings[count - i - 1];
            }
            stringSW.Stop();

            Console.WriteLine($"comparing {count} struct:   {structSW.Elapsed}");
            Console.WriteLine($"comparing {count} strings:  {stringSW.Elapsed}");
            Console.WriteLine();

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}
