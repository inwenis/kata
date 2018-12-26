using NUnit.Framework;
using System.Linq;
using kata04.data.munging;

namespace Tests
{
    public class FootballParserTests
    {
        [Test]
        public void Parse_InputWithSingleDataRow_ReturnsParsedRow()
        {
            // arrange
            string input = 
"       Team            P     W    L   D    F      A     Pts" + "\n" +
"    1. Arsenal         38    26   9   3    79  -  36    87"  + "\n";

            // act
            var result = FootballParser.Parse(input);

            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Arsenal", result.Single().Team);
            Assert.AreEqual(36, result.Single().AgainstScore);
            Assert.AreEqual(79, result.Single().ForScore);
        }
    }
}