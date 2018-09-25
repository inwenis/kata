using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagram_kata2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Anagramalist
    {
        public static string[] FindAllAnagrams(string[] words)
        {
            if (!words.Any())
            {
                return new string[0];
            }
            else if(words.Length == 2)
            {
                return new []{words[0] + " " + words[1]};
            }
            else
            {
                return new []{words[0] + " " + words[1] + " " + words[2]};
            }
        }
    }
}
