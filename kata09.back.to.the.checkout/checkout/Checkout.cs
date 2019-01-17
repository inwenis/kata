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

                var simpleRules = _pricingRules.Where(r => r.Count == 1);

                foreach(var @group in itemsGroups)
                {
                    var simpleRule = _pricingRules.SingleOrDefault(r => r.Item == @group.Key && r.Count == 1);
                    var specialRule = _pricingRules.SingleOrDefault(r => r.Item == @group.Key && r.Count == 2);

                    if(@group.Count() == 1)
                    {
                        total += simpleRule.Price;
                    }
                    else if(@group.Count() == 2 && specialRule != null)
                    {
                        total += specialRule.Price;
                    }
                    else
                    {
                        total += simpleRule.Price * @group.Count();
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
