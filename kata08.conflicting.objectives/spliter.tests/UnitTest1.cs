using NUnit.Framework;
using System.Collections.Generic;
using spliter;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EatBanana_EmptyInput_ReturnsEmptyList()
        {
            // arrange
            var list = new List<string>()
            {
            };

            // act
            List<(string, string, string)> result = FunnyMonkey.EatBanana(list);

            // assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void EatBanana_ListContaininValidTrio_ReturnsTrio()
        {
            // arrange
            var list = new List<string>()
            {
                "aaa",
                "bbb",
                "aaabbb"
            };

            // act
            List<(string, string, string)> result = FunnyMonkey.EatBanana(list);

            // assert
            Assert.AreEqual(("aaa", "bbb", "aaabbb"), result[0]);
        }

        [Test]
        public void EatBanana_ListContainin2ValidTrios_Returns2Trios()
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
            List<(string, string, string)> result = FunnyMonkey.EatBanana(list);

            // assert
            Assert.Contains(("aaa", "bbb", "aaabbb"), result);
            Assert.Contains(("xxx", "yyy", "xxxyyy"), result);
        }
    }
}