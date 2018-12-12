using NUnit.Framework;

namespace kata.sortingitout.Tests
{
    [TestFixture]
    public class RackTests
    {
        [Test]
        public static void Test1()
        {
            // arrange
            var sut = new Rack();

            // act
            sut.Add(12);

            // assert
            CollectionAssert.AreEqual(new []{12}, sut.Balls);
        }
    }
}
