using System.Collections.Generic;
using System.Linq;

namespace checkout
{
    public class Checkout
    {
        private PricingRule[] _pricingRules;
        private decimal _total;
        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules.ToArray();
        }

        public void Scan(char item)
        {
            _total += _pricingRules.Single(x => x.Item == item).Price;
        }

        public decimal Total
        {
            get => _total;
        }
    }

    public class PricingRule
    {
        public readonly char Item;
        public readonly int Count;
        public readonly decimal Price;

        public PricingRule(char item, decimal price) : this(item, 1, price)
        {
        }

        public PricingRule(char item, int count, decimal price)
        {
            Item = item;
            Count = count;
            Price = price;
        }
    }
}
