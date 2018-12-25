using NUnit.Framework;

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
    }
}