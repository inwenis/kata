using NUnit.Framework;
using System.Linq;
using kata04.data.munging;

namespace Tests
{
    public class ParserTests
    {
        [Test]
        public void ParseWeather_InputWithSingleDataRowAndTotalRowAtEnd_ReturnsParsedRowAndIgnoredTotalRow()
        {
            // arrange
            string input =
"  Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP" + "\n" +
""                                                                                          + "\n" +
"   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5" + "\n" +
"  mo  82.9  60.5  71.7    16  58.8       0.00              6.9          5.3"               + "\n";

            // act
            var result = Parser.ParseWeather(input);

            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("1", result.Single().Name);
            Assert.AreEqual(59, result.Single().ValueB);
            Assert.AreEqual(88, result.Single().ValueA);
        }

        [Test]
        public void ParseWeather_InputWithMultipleDataRowsAndTotalRowAtEnd_ReturnsParsedRowsAndIgnoresTotalRow()
        {
            // arrange
            string input =
"  Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP" + "\n" +
""                                                                                          + "\n" +
"   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5" + "\n" +
"   2  79    63    71          46.5       0.00         330  8.7 340  23  3.3  70 28 1004.5" + "\n" +
"   3  77    55    66          39.6       0.00         350  5.0 350   9  2.8  59 24 1016.8" + "\n" +
"  mo  82.9  60.5  71.7    16  58.8       0.00              6.9          5.3"               + "\n";

            // act
            var result = Parser.ParseWeather(input);

            // assert
            Assert.AreEqual(3, result.Count);

            Assert.AreEqual("1", result[0].Name);
            Assert.AreEqual(59, result[0].ValueB);
            Assert.AreEqual(88, result[0].ValueA);

            Assert.AreEqual("2", result[1].Name);
            Assert.AreEqual(63, result[1].ValueB);
            Assert.AreEqual(79, result[1].ValueA);

            Assert.AreEqual("3", result[2].Name);
            Assert.AreEqual(55, result[2].ValueB);
            Assert.AreEqual(77, result[2].ValueA);
        }

        [Test]
        public void ParseFootball_InputWithSingleDataRow_ReturnsParsedRow()
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
        public void ParseFootball_MultipleDataRowsWithSeparatorRow_ReturnsPrsedRowsAndIgnoredSeparator()
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