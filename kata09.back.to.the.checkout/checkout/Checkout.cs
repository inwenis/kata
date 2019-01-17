using System.Collections.Generic;
using System.Linq;

namespace checkout
{
    public class Checkout
    {
        private PricingRule[] _pricingRules;
        private List<char> _items;

        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules.ToArray();
            _items = new List<char>();
        }

        public void Scan(char item)
        {
            _items.Add(item);
        }

        public decimal Total
        {
            get
            {
                decimal total = 0m;
                var itemsGroups = _items.GroupBy(x => x);

                foreach(var @group in itemsGroups)
                {
                    var rules = _pricingRules.Where(r => r.Item == @group.Key).OrderByDescending(r => r.Count);
                    var itemCount = @group.Count();

                    while(itemCount > 0)
                    {
                        var ruleToApply = rules.First(r => r.Count <= itemCount);
                        total += ruleToApply.Price;
                        itemCount -= ruleToApply.Count;
                    }
                }
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
