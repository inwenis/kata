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
        public readonly decimal Price;

        public PricingRule(char item, decimal price)
        {
            Item = item;
            Price = price;
        }
    }
}
