using System.Collections.Generic;

namespace checkout
{
    public class Checkout
    {
        public Checkout(IEnumerable<PricingRule> pricingRules)
        {

        }

        public void Scan(char item)
        {
        }

        public decimal Total => 0;
    }

    public class PricingRule
    {
    }
}
