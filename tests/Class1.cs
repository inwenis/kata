using anagram_kata;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ComputeAll2WordsAnagrams_GivenNoWords_ReturnsNoAnagrams()
        {
            var emptList = new string[0];
            var sut = new Anagramalist(emptList);

            var result = sut.ComputeAll2WordsAnagrams("whatever");

            Assert.IsEmpty(result);
        }

        [Test]
        public void ComputeAll2WordsAnagrams_GivenOneMatchingAnagram_ReturnsOneAnagram()
        {
            var wordsWithOnePossibleAnagram = new string[]{"document", "ing"};
            var sut = new Anagramalist(wordsWithOnePossibleAnagram);

            var result = sut.ComputeAll2WordsAnagrams("documenting");

            CollectionAssert.AreEqual(new []{"document ing"} ,result);
        }

        [Test]
        public void ComputeAll2WordsAnagrams_GivenInputWordWithLetterNotPresentInSubject_ReturnsNoAnagrams()
        {
            var wordsWithOnePossibleAnagram = new string[]{"documentX", "ing"};
            var sut = new Anagramalist(wordsWithOnePossibleAnagram);

            var result = sut.ComputeAll2WordsAnagrams("documenting");

            Assert.IsEmpty(result);
        }
    }
}
