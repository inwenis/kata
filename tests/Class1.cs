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
    }
}
