using System;

namespace kata02.karate.chop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Chop(5, new []{1,3,5});
            Chop(3, new int []{});
            Chop(3, new int []{1});
            Chop(1, new int []{1});
            //
            Chop(1, new int []{1, 3, 5});
            Chop(3, new int []{1, 3, 5});
            Chop(5, new int []{1, 3, 5});
            Chop(0, new int []{1, 3, 5});
            Chop(2, new int []{1, 3, 5});
            Chop(4, new int []{1, 3, 5});
            Chop(6, new int []{1, 3, 5});
            //
            Chop(1, new int []{1, 3, 5, 7});
            Chop(3, new int []{1, 3, 5, 7});
            Chop(5, new int []{1, 3, 5, 7});
            Chop(7, new int []{1, 3, 5, 7});
            Chop(0, new int []{1, 3, 5, 7});
            Chop(2, new int []{1, 3, 5, 7});
            Chop(4, new int []{1, 3, 5, 7});
            Chop(6, new int []{1, 3, 5, 7});
            Chop(8, new int []{1, 3, 5, 7});
        }

        public static int Chop(int searchFor, int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right)/2;

                if (array[mid] == searchFor)
                {
                    return mid;
                }
                else if (array[mid] > searchFor)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}
