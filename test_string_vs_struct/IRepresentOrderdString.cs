namespace test_string_vs_struct
{
    public struct IRepresentOrderdString
    {
        public ulong one;
        public ulong two;
        public ulong three;

        public override string ToString()
        {
            return $"{one:D21}{two:D21}{three:D21}";
        }

        public static bool operator ==(IRepresentOrderdString c1, IRepresentOrderdString c2)
        {
            return c1.one == c2.one && c1.two == c2.two && c1.three == c2.three;
        }

        public static bool operator !=(IRepresentOrderdString c1, IRepresentOrderdString c2)
        {
            return !(c1 == c2);
        }

        public static IRepresentOrderdString FromString(string word)
        {
            IRepresentOrderdString x = new IRepresentOrderdString();

            for (int i = 0; i < word.Length; i++)
            {
                var index = word[i] - 65;
                if (index <= 19)
                {
                    x.one += Math.Pow(10, index);
                }
                else if(index <= (19 * 2))
                {
                    index -= 19;
                    x.one += Math.Pow(10, index);
                }
                else
                {
                    index -= (19 * 2);
                    x.three += Math.Pow(10, index);
                }
            }

            return x;
        }
    }
}