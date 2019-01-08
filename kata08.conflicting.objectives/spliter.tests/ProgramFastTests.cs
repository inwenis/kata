using NUnit.Framework;
using System.Collections.Generic;
using spliter;
using System.Linq;

namespace Tests
{
    public class ProgramFastTests
    {
        [Test]
        public void FindSums_EmptyInput_ReturnsEmptyList()
        {
            // arrange
            var list = new List<string>()
            {
            };

            // act
            var result = ProgramFast.FindSums(list);

            // assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void FindSums_ListContaininValidTrio_ReturnsTrio()
        {
            // arrange
            var list = new List<string>()
            {
                "aaa",
                "bbb",
                "aaabbb"
            };

            // act
            var result = ProgramFast.FindSums(list);

            // assert
            Assert.AreEqual(("aaa", "bbb", "aaabbb"), result.ToArray()[0]);
        }

        [Test]
        public void FindSums_ListContainin2ValidTrios_Returns2Trios()
        {
            // arrange
            var list = new List<string>()
            {
                "aaa",
                "bbb",
                "aaabbb",
                "xxx",
                "yyy",
                "xxxyyy",
            };

            // act
            var result = ProgramFast.FindSums(list);

            // assert
            Assert.Contains(("aaa", "bbb", "aaabbb"), result.ToArray());
            Assert.Contains(("xxx", "yyy", "xxxyyy"), result.ToArray());
        }

        [Test]
        public void FindSums_ListContainin1ValidTrioAndSomeExtraWord_Returns1Trio()
        {
            // arrange
            var list = new List<string>()
            {
                "aaa",
                "wha",
                "bbb",
                "aaabbb",
            };

            // act
            var result = ProgramFast.FindSums(list);

            // assert
            Assert.Contains(("aaa", "bbb", "aaabbb"), result.ToArray());
        }

        [Test]
        public void FindSums_ListContainingNoValidTrio_ReturnsEmptyList()
        {
            // arrange
            var list = new List<string>()
            {
                "ABC's",
                "a",
                "A'asia",
            };

            // act
            var result = ProgramFast.FindSums(list);

            // assert
            Assert.IsEmpty(result);
        }
    }
}