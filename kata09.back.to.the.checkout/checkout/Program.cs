using System;

namespace checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            assert_equal(  0, price(""));
            assert_equal( 50, price("A"));
            assert_equal( 80, price("AB"));
            assert_equal(115, price("CDBA"));

            assert_equal(100, price("AA"));
            assert_equal(130, price("AAA"));
            assert_equal(180, price("AAAA"));
            assert_equal(230, price("AAAAA"));
            assert_equal(260, price("AAAAAA"));

            assert_equal(160, price("AAAB"));
            assert_equal(175, price("AAABB"));
            assert_equal(190, price("AAABBD"));
            assert_equal(190, price("DABABA"));

            PricingRule[] rules = new PricingRule[]
            {
                new PricingRule('A', 50),
                new PricingRule('B', 30),
                new PricingRule('C', 20),
                new PricingRule('D', 15),
                new PricingRule('A', 3, 130),
                new PricingRule('B', 2, 45),
            };

            Checkout co = new Checkout(rules);
            assert_equal(  0, co.Total);
            co.Scan('A');  assert_equal( 50, co.Total);
            co.Scan('B');  assert_equal( 80, co.Total);
            co.Scan('A');  assert_equal(130, co.Total);
            co.Scan('A');  assert_equal(160, co.Total);
            co.Scan('B');  assert_equal(175, co.Total);
        }

        public static void assert_equal(decimal expected, decimal actual)
        {
            if(expected == actual)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("not ok");
                Console.ResetColor();
            }
        }

        public static decimal price(string items)
        {
            char[] itemsArray = items.ToCharArray();
            PricingRule[] rules = new PricingRule[]
            {
                new PricingRule('A', 50),
                new PricingRule('B', 30),
                new PricingRule('C', 20),
                new PricingRule('D', 15),
                new PricingRule('A', 3, 130),
                new PricingRule('B', 2, 45),
            };
            Checkout checkout = new Checkout(rules);
            foreach(char item in itemsArray)
            {
                checkout.Scan(item);
            }
            return checkout.Total;
        }
    }
}
