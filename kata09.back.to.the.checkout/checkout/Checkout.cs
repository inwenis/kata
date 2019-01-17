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
                var itemsGroup = _items.GroupBy(x => x);
                if(itemsGroup.Any(g => g.Count() == 2))
                {
                    var multipleItems = itemsGroup.Single(g => g.Count() == 2).Key;
                    var pricingRule = _pricingRules.SingleOrDefault(r => r.Item == multipleItems && r.Count == 2);
                    if(pricingRule != null)
                    {
                        total += pricingRule.Price;
                        itemsGroup = itemsGroup.Where(g => g.Key != multipleItems);
                    }
                }

                var simpleRules = _pricingRules.Where(r => r.Count == 1);

                total += itemsGroup
                    .SelectMany(g => g)
                    .Join(simpleRules, x => x, r => r.Item, (g, r) => r)
                    .Sum(r => r.Price);

                return total;
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
