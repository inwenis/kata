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

            for (int i = 0; i < count/2; i++)
            {
                var leftStringOrdered = new string(strings[i].OrderBy(c => c).ToArray());
                var rightStringOrdered = new string(strings[count - i - 1].OrderBy(c => c).ToArray());
                Compare(rightStringOrdered, leftStringOrdered, out var stringComp, out var structComp);
                if (structComp != stringComp)
                {
                    Console.WriteLine(leftStringOrdered + " " + rightStringOrdered);
                    Console.WriteLine($"{leftStringOrdered} == {rightStringOrdered} = {stringComp}");
                    Console.WriteLine($"IRepresentOrderdString.FromString({leftStringOrdered}) == IRepresentOrderdString.FromString({rightStringOrdered}) = {structComp}");
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }

        private static void Compare(string rightString, string leftString, out bool stringComp, out bool structComp)
        {
            var left = IRepresentOrderdString.FromString(leftString);
            var right = IRepresentOrderdString.FromString(rightString);
            stringComp = leftString == rightString;
            structComp = left == right;
        }
    }

    public struct IRepresentOrderdString
    {
        public ulong one;
        public ulong two;
        public ulong three;

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
                    x.one += (ulong) Pow(10, index);
                }
                else if(index <= 41)
                {
                    index -= 21;
                    x.one += (ulong) Pow(10, index);
                }
                else
                {
                    index -= 41;
                    x.three += (ulong) Pow(10, index);
                }
            }

            return x;
        }

        private static int Pow(int num, int pow)
        {
            for (int i = 0; i < pow; i++)
            {
                num *= num;
            }
            return num;
        }
    }

}
