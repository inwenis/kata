using checkout;
using NUnit.Framework;

public class CheckoutTests
{
    [Test]
    public void ScanNoItems_TotalIs0()
    {
        // arrange
        Checkout sut = new Checkout(null);

        // act

        Assert.AreEqual(0, sut.Total);
    }
}