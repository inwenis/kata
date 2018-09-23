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
            var additionalWords = "document ing nig tnemucod tuned coming" +
                "ceding mount document gin condign mute induct gnome coming tuned gnomic tuned cumin tonged cum denoting";
            var splitted = additionalWords.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var words = ReadFromFile("wordlist.txt");

            var allWords = words.Union(splitted).ToArray();

            var anagramalist = new Anagramalist(allWords);
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
            var words = withoutHeader.SelectMany(line => line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
            return words.ToArray();
        }
    }
}
