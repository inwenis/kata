﻿using System;
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

            for (int i = 0; i < count/2; i++)
            {
                var leftString = strings[i];
                var rightString = strings[count - i - 1];
                var leftStringOrdered = new string(leftString.OrderBy(c => c).ToArray());
                var rightStringOrdered = new string(rightString.OrderBy(c => c).ToArray());
                var leftStringAsAtruct = IRepresentOrderdString.FromString(leftString);
                var rightStringAsStruct = IRepresentOrderdString.FromString(rightString);
                var stringComp = leftStringOrdered == rightStringOrdered;
                var structComp = leftStringAsAtruct == rightStringAsStruct;
                if (structComp != stringComp)
                {
                    Console.WriteLine(leftStringOrdered + " " + rightStringOrdered);
                    Console.WriteLine($"{leftStringOrdered} == {rightStringOrdered} = {stringComp}");
                    Console.WriteLine($"IRepresentOrderdString.FromString({leftStringOrdered}) == IRepresentOrderdString.FromString({rightStringOrdered}) = {structComp}");
                    Console.WriteLine($"{leftStringAsAtruct}");
                    Console.WriteLine($"{rightStringAsStruct}");
                    Console.WriteLine();
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                }
            }


            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }

    public class Math
    {
        public static ulong Pow(int num, int pow)
        {
            var numAsULong = (ulong) num;
            ulong temp = numAsULong;
            for (int i = 1; i < pow; i++)
            {
                temp *= numAsULong;
            }
            return temp;
        }
    }

    public struct IRepresentOrderdString
    {
        public ulong one;
        public ulong two;
        public ulong three;

        public override string ToString()
        {
            return $"{one:D21}{two:D21}{three:D21}";
        }

        public static bool operator ==(IRepresentOrderdString c1, IRepresentOrderdString c2)
        {
            return c1.one == c2.one && c1.two == c2.two && c1.three == c2.three;
        }

        public static bool operator !=(IRepresentOrderdString c1, IRepresentOrderdString c2)
        {
            return !(c1 == c2);
        }

        public static IRepresentOrderdString FromString(string word)
        {
            IRepresentOrderdString x = new IRepresentOrderdString();

            for (int i = 0; i < word.Length; i++)
            {
                var index = word[i] - 65;
                if (index <= 21)
                {
                    x.one += Math.Pow(10, index);
                }
                else if(index <= 41)
                {
                    index -= 21;
                    x.one += Math.Pow(10, index);
                }
                else
                {
                    index -= 41;
                    x.three += Math.Pow(10, index);
                }
            }

            return x;
        }
    }

}
