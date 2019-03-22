using System;
using System.Linq;
using System.Collections.Generic;

namespace kata14.trigrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string text = System.IO.File.ReadAllText("book.txt");
            string noNewLines = text
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Replace("  ", " ");
            string[] sentences = noNewLines.Split(".");
            var dic = sentences
                .Select(x => GetDic(x))
                .SelectMany(x => x)
                .GroupBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Select(y => y.Value).ToArray());
            // foreach (var item in dic)
            // {
            //     System.Console.WriteLine($"{item.Key} => {string.Join(" ", item.Value)}");
            // }
            //string key = dic.Keys.ElementAt(1000);
            //string key = dic.Keys.ElementAt(2000);
            string key = dic.Keys.ElementAt(3004);
            List<string> newSentence = new List<string>();
            string[] split = key.Split(" ");
            string a = split[0];
            string b = split[1];
            newSentence.Add(a);
            newSentence.Add(b);
            while (true)
            {
                key = $"{a} {b}";
                if(dic.ContainsKey(key))
                {
                    string c = dic[key][0];
                    newSentence.Add(c);
                    a = b;
                    b = c;
                }
                else
                {
                    break;
                }
            }
            System.Console.WriteLine(string.Join(" ", newSentence));
        }

        private static List<KeyValuePair<string, string>> GetDic(string sentence)
        {
            string[] words = sentence
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var trigrams = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < words.Length - 3; i++)
            {
                string key = $"{words[i]} {words[i+1]}";
                string value = words[i+2];
                trigrams.Add(new KeyValuePair<string, string>(key, value));
            }
            return trigrams;
        }
    }
}
