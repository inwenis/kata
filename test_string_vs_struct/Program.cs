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
            var array = new string[count];
            var array2 = new IRepresentOrderdString[count];

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                array2[i].one = (ulong) random.Next();
                array2[i].two = (ulong) random.Next();
                array2[i].three = (ulong) random.Next();

                array[i] = words[random.Next(words.Length)];
            }

            var results = new bool[count/2];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count/2; i++)
            {
                results[i] = array2[i] == array2[count - i - 1];
            }
            sw.Stop();
            Console.WriteLine($"struct:  {sw.Elapsed}");

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 0; i < count/2; i++)
            {
                results[i] = array[i] == array[count - i - 1];
            }
            sw2.Stop();
            Console.WriteLine($"strings: {sw2.Elapsed}");

            for (int i = 0; i < count/2; i++)
            {
                var leftString = array[i];
                var rightString = array[count - i - 1];
                Compare(rightString, leftString, out var structComp, out var stringComp);
                if (structComp != stringComp)
                {
                    Console.WriteLine(leftString + " " + rightString);
                    Console.Write(stringComp);
                    Console.Write(" ");
                    Console.WriteLine(structComp);
                    Console.Beep();
                    Console.ReadLine();
                }
                if (stringComp)
                {
                    Console.WriteLine(leftString + " " + rightString);
                    Console.Write(stringComp);
                    Console.Write(" ");
                    Console.WriteLine(structComp);
                    Console.Beep();
                    Console.ReadLine();
                }

            }

            Compare("asdf", "asfd", out var stringComp2, out var structComp2);

            Console.WriteLine(stringComp2);
            Console.WriteLine(structComp2);
            
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
                    var num = 10;
                    for (int j = 0; j < index; j++)
                    {
                        num *= 10;
                    }

                    x.one += (ulong) (num);
                }
                else if(index <= 41)
                {
                    index -= 21;
                    var num = 10;
                    for (int j = 0; j < index; j++)
                    {
                        num *= 10;
                    }

                    x.two += (ulong) (num);
                }
                else
                {
                    index -= 41;
                    var num = 10;
                    for (int j = 0; j < index; j++)
                    {
                        num *= 10;
                    }

                    x.three += (ulong) (num);
                }
            }

            return x;
        }
    }

}
