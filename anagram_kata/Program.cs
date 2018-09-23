using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagram_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var anagramSubject = "documenting";

            var anagramalist = new Anagramalist(new [] { "document", "ing"});
            var anagrams = anagramalist.ComputeAll2WordsAnagrams(anagramSubject);
            foreach (var anagram in anagrams)
            {
                Console.WriteLine(anagram);
            }

            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    public class Anagramalist
    {
        private string[] _words;

        public Anagramalist(string[] words)
        {
            _words = words;
        }

        public IEnumerable<string> ComputeAll2WordsAnagrams(string anagramSubject)
        {
            var possibleFirstWords = _words.Where(word => CharactersAreSubsetOf(word, anagramSubject)).ToArray();

            if (possibleFirstWords.Length >= 2)
            {
                foreach (var firstWord in possibleFirstWords.ToArray())
                {
                    var remainingCharacters = RemoveCharacters(anagramSubject, firstWord);

                    var possibleSecondsWords = possibleFirstWords
                        .SkipWhile(x => x != firstWord)
                        .Where(word => word.All(c => remainingCharacters.Contains(c)))
                        .ToArray();

                    foreach (var secondWord in possibleSecondsWords)
                    {
                        yield return firstWord + " " + secondWord;
                    }
                }
            }
            else
            {
                yield break;
            }
        }

        private static List<char> RemoveCharacters(string left, string right)
        {
            var remainingCharacters = left.ToList();
            foreach (var character in right)
            {
                if (!remainingCharacters.Remove(character))
                {
                    var leftRemaining = string.Join("", remainingCharacters);
                    throw new InvalidOperationException(
                        $"Can not remove {left} - {right}. Remaining characters are: {leftRemaining}. Could not remove {character}");
                }
            }

            return remainingCharacters;
        }

        private static bool CharactersAreSubsetOf(string setToCheck, string setToCheckAgainst)
        {
            var charactersList = setToCheckAgainst.ToList();

            foreach (var character in setToCheck)
            {
                if (!charactersList.Remove(character))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
