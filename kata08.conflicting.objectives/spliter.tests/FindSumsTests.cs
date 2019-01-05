using NUnit.Framework;
using System.Collections.Generic;
using spliter;

namespace Tests
{
    public class FindSumsTests
    {
        [Test]
        public void FindSums_EmptyInput_ReturnsEmptyList()
        {
            // arrange
            var list = new List<string>()
            {
            };

            // act
            List<(string, string, string)> result = FindSums.In(list);

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
            List<(string, string, string)> result = FindSums.In(list);

            // assert
            Assert.AreEqual(("aaa", "bbb", "aaabbb"), result[0]);
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
            List<(string, string, string)> result = FindSums.In(list);

            // assert
            Assert.Contains(("aaa", "bbb", "aaabbb"), result);
            Assert.Contains(("xxx", "yyy", "xxxyyy"), result);
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
            List<(string, string, string)> result = FindSums.In(list);

            // assert
            Assert.Contains(("aaa", "bbb", "aaabbb"), result);
        }
    }
}