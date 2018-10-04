namespace test_string_vs_struct
{
    public class Math
    {
        public static ulong Pow(int num, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }

            var numAsULong = (ulong) num;
            ulong temp = numAsULong;
            for (int i = 1; i < pow; i++)
            {
                temp *= numAsULong;
            }
            return temp;
        }
    }
}