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

        [Test]
        public void Parse_MultipleDataRowsWithSeparatorRow_ReturnsPrsedRowsAndIgnoredSeparator()
        {
            string input = 
"       Team            P     W    L   D    F      A     Pts" + "\n" +
"    1. Arsenal         38    26   9   3    79  -  36    87"  + "\n" +
"    2. Liverpool       38    24   8   6    67  -  30    80"  + "\n" +
"    3. Manchester_U    38    24   5   9    87  -  45    77"  + "\n" +
"   -------------------------------------------------------"  + "\n" +
"   18. Ipswich         38     9   9  20    41  -  64    36"  + "\n" +
"   19. Derby           38     8   6  24    33  -  63    30"  + "\n" +
"   20. Leicester       38     5  13  20    30  -  64    28"  + "\n";

            // act
            var result = FootballParser.Parse(input);

            // assert
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual("Arsenal", result[0].Team);
            Assert.AreEqual("Liverpool", result[1].Team);
            Assert.AreEqual("Manchester_U", result[2].Team);
            Assert.AreEqual("Ipswich", result[3].Team);
            Assert.AreEqual("Derby", result[4].Team);
            Assert.AreEqual("Leicester", result[5].Team);
        }
    }
}