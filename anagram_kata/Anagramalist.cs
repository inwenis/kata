using System;
using System.Collections.Generic;
using System.Linq;

namespace anagram_kata
{
    public class Anagramalist
    {
        private string[] _words;

        public Anagramalist(string[] words)
        {
            _words = words;
        }

        public IEnumerable<string> ComputeAll2WordsAnagrams(string anagramSubject)
        {
            var wordsWhichCanBeUsedInAnagrams = _words
                .Where(word => CharactersAreSubsetOf(word, anagramSubject))
                .ToArray();

            foreach (var firstWord in wordsWhichCanBeUsedInAnagrams.ToArray())
            {
                var remainingCharacters = RemoveCharacters(anagramSubject, firstWord);

                var possibleSecondsWords = wordsWhichCanBeUsedInAnagrams
                    .SkipWhile(x => x != firstWord)
                    .Where(word => CharactersAreSubsetOf(word, remainingCharacters))
                    .Where(word => !RemoveCharacters(remainingCharacters, word).Any())
                    .ToArray();

                foreach (var secondWord in possibleSecondsWords)
                {
                    yield return $"{firstWord} {secondWord}";
                }
            }
        }

        private static List<char> RemoveCharacters(string left, string right)
        {
            return RemoveCharacters(left.ToList(), right);
        }

        private static List<char> RemoveCharacters(List<char> left, string right)
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
            return CharactersAreSubsetOf(setToCheck, setToCheckAgainst.ToList());
        }

        private static bool CharactersAreSubsetOf(string setToCheck, List<char> setToCheckAgainst)
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