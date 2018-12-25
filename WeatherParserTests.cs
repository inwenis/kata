using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class WeatherParserTests
    {
        [Test]
        public void Parse_EmptyInput_ReturnsEmptyList()
        {
            // arrange
            // act
            var result = WeatherParser.Parse("");

            // assert
            Assert.IsNotNull(result);
        }

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
    }
}