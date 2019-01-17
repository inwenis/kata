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

    [Test]
    public void Scan2ItemsWithSimplePrice_TotalIsEqual2TimesItemPrice()
    {
        // arrange
        var rules = new List<PricingRule>()
        {
            new PricingRule('A', 50)
        };
        Checkout sut = new Checkout(rules);

        // act
        sut.Scan('A');
        sut.Scan('A');

        Assert.AreEqual(100, sut.Total);
    }

    [Test]
    public void Scan2DifferentItemsWithSimplePrice_TotalIsEqualSumOfItemPrices()
    {
        // arrange
        var rules = new List<PricingRule>()
        {
            new PricingRule('A', 50),
            new PricingRule('B', 20)
        };
        Checkout sut = new Checkout(rules);

        // act
        sut.Scan('A');
        sut.Scan('B');

        Assert.AreEqual(70, sut.Total);
    }

    [Test]
    public void Scan2ItemsWhichTogetherHaveASpecialPrice_TotalIsEqualToSpecialPrice()
    {
        // arrange
        var rules = new List<PricingRule>()
        {
            new PricingRule('B', 2, 45)
        };
        Checkout sut = new Checkout(rules);

        // act
        sut.Scan('B');
        sut.Scan('B');

        Assert.AreEqual(45, sut.Total);
    }

    [Test]
    public void Scan2ItemsWhichTogetherHaveASpecialPriceAndItemWithSimplePrice_TotalIsCorrect()
    {
        // arrange
        var rules = new List<PricingRule>()
        {
            new PricingRule('B', 2, 45),
            new PricingRule('A', 10),
        };
        Checkout sut = new Checkout(rules);

        // act
        sut.Scan('B');
        sut.Scan('B');
        sut.Scan('A');

        Assert.AreEqual(45 + 10, sut.Total);
    }

    [Test]
    public void Scan3ItemsWhere2HaveASpecialPriceAndThirdHasRegularPrice_TotalIsCorrect()
    {
        // arrange
        var rules = new List<PricingRule>()
        {
            new PricingRule('B', 2, 17),
            new PricingRule('B', 10),
        };
        Checkout sut = new Checkout(rules);

        // act
        sut.Scan('B');
        sut.Scan('B');
        sut.Scan('B');

        Assert.AreEqual(17 + 10, sut.Total);
    }
}