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
            var result = Parser.ParseFootball(input);

            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Arsenal", result.Single().Name);
            Assert.AreEqual(79, result.Single().ValueA);
            Assert.AreEqual(36, result.Single().ValueB);
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
            var result = Parser.ParseFootball(input);

            // assert
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual("Arsenal", result[0].Name);
            Assert.AreEqual("Liverpool", result[1].Name);
            Assert.AreEqual("Manchester_U", result[2].Name);
            Assert.AreEqual("Ipswich", result[3].Name);
            Assert.AreEqual("Derby", result[4].Name);
            Assert.AreEqual("Leicester", result[5].Name);
        }
    }
}