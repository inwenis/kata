using checkout;
using System.Collections.Generic;
using NUnit.Framework;

public class CheckoutTests
{
    [Test]
    public void ScanNoItems_TotalIs0()
    {
        // arrange
        Checkout sut = new Checkout(new List<PricingRule>());

        // act

        Assert.AreEqual(0, sut.Total);
    }

    [Test]
    public void ScanSingleItemWithSimplePrice_TotalIsEqualItemPrice()
    {
        // arrange
        var rules = new List<PricingRule>()
        {
            new PricingRule('A', 50)
        };
        Checkout sut = new Checkout(rules);

        // act
        sut.Scan('A');

        Assert.AreEqual(50, sut.Total);
    }
}