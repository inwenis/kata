using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class WeatherParserTests
    {
        [Test]
        public void Parse_InputWithSingleDataRow_ReturnsParsedRow()
        {
            // arrange
            string input = 
"  Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP" + "\n" +
""                                                                                          + "\n" +
"   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5" + "\n";

            // act
            var result = WeatherParser.Parse(input);

            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.Single().DayNumber);
            Assert.AreEqual(59, result.Single().MinTemp);
            Assert.AreEqual(88, result.Single().MaxTemp);
        }

        [Test]
        public void Parse_InputWithMultipleDataRows_ReturnsParsedRows()
        {
            // arrange
            string input = 
"  Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP" + "\n" +
""                                                                                          + "\n" +
"   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5" + "\n" +
"   2  79    63    71          46.5       0.00         330  8.7 340  23  3.3  70 28 1004.5" + "\n" +
"   3  77    55    66          39.6       0.00         350  5.0 350   9  2.8  59 24 1016.8" + "\n";

            // act
            var result = WeatherParser.Parse(input);

            // assert
            Assert.AreEqual(3, result.Count);

            Assert.AreEqual(1, result[0].DayNumber);
            Assert.AreEqual(59, result[0].MinTemp);
            Assert.AreEqual(88, result[0].MaxTemp);

            Assert.AreEqual(2, result[1].DayNumber);
            Assert.AreEqual(63, result[1].MinTemp);
            Assert.AreEqual(79, result[1].MaxTemp);

            Assert.AreEqual(3, result[2].DayNumber);
            Assert.AreEqual(55, result[2].MinTemp);
            Assert.AreEqual(77, result[2].MaxTemp);
        }
    }
}