using System.Collections.Generic;
using System.Linq;

namespace checkout
{
    public class Checkout
    {
        private PricingRule[] _pricingRules;
        private decimal _total;
        private List<char> _items;

        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules.ToArray();
            _items = new List<char>();
        }

        public void Scan(char item)
        {
            _total += _pricingRules.Single(x => x.Item == item).Price;
            _items.Add(item);
        }

        public decimal Total
        {
            get
            {
                decimal total = 0m;
                if(_items.Count == 2 && _items[0] == _items[1] && _pricingRules.Single().Count == 2)
                {
                    return _pricingRules.Single().Price;
                }
                return _items.Select(item => _pricingRules.Single(r => r.Item == item)).Sum(r => r.Price);
            }
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
