using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagram_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new [] { "document", "ing", "nig", "tnemucod"};
//            var words = ReadFromFile("wordlist.txt");
            
            var anagramalist = new Anagramalist(words);
            var anagrams = anagramalist.ComputeAll2WordsAnagrams("documenting");
            foreach (var anagram in anagrams)
            {
                Console.WriteLine(anagram);
            }

            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }

        private static string[] ReadFromFile(string fileName)
        {
            var allLines = File.ReadAllLines("wordlist.txt");
            var withoutHeader = allLines.Skip(1).ToArray();
            var withoutLast = withoutHeader.Take(withoutHeader.Count() - 1);
            var words = withoutLast.SelectMany(line => line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
            return words.ToArray();
        }
    }
}
