using System;

namespace kata02.karate.chop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ChopUnsafe(5, new []{1,3,5});
            ChopUnsafe(3, new int []{});
            ChopUnsafe(3, new int []{1});
            ChopUnsafe(1, new int []{1});
            //
            ChopUnsafe(1, new int []{1, 3, 5});
            ChopUnsafe(3, new int []{1, 3, 5});
            ChopUnsafe(5, new int []{1, 3, 5});
            ChopUnsafe(0, new int []{1, 3, 5});
            ChopUnsafe(2, new int []{1, 3, 5});
            ChopUnsafe(4, new int []{1, 3, 5});
            ChopUnsafe(6, new int []{1, 3, 5});
            //
            ChopUnsafe(1, new int []{1, 3, 5, 7});
            ChopUnsafe(3, new int []{1, 3, 5, 7});
            ChopUnsafe(5, new int []{1, 3, 5, 7});
            ChopUnsafe(7, new int []{1, 3, 5, 7});
            ChopUnsafe(0, new int []{1, 3, 5, 7});
            ChopUnsafe(2, new int []{1, 3, 5, 7});
            ChopUnsafe(4, new int []{1, 3, 5, 7});
            ChopUnsafe(6, new int []{1, 3, 5, 7});
            ChopUnsafe(8, new int []{1, 3, 5, 7});
        }

        public static int ChopUnsafe(int searchFor, int[] array)
        {
            unsafe
            {
                fixed(int* left = array)
                {
                    return ChopUnsafe(searchFor, left, array.Length);
                }
            }
        }

        private static unsafe int ChopUnsafe(int searchFor, int* left, int length)
        {
            int mid = (length)/2;

            if (length == 0)
            {
                return -1;
            }
            else if (*(left + mid) == searchFor)
            {
                return mid;
            }
            else if (*(left + mid) > searchFor)
            {
                length = length - mid - 1;
            }
            else
            {
                left = left + mid + 1;
                length = length - mid - 1;
            }
            return ChopUnsafe(searchFor, left, length);
        }

        public static int ChopRec2(int searchFor, int[] array)
        {
            int ChopRec(int left, int right)
            {
                int mid = (left + right)/2;

                if (left > right)
                {
                    return -1;
                }
                else if (array[mid] == searchFor)
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
                return ChopRec(left, right);
            }

            return ChopRec(0, array.Length - 1);
        }

        public static int ChopRec(int searchFor, int[] array)
        {
            return ChopRec(searchFor, array, 0, array.Length - 1);
        }

        private static int ChopRec(int searchFor, int[] array, int left, int right)
        {
            int mid = (left + right)/2;

            if (left > right)
            {
                return -1;
            }
            else if (array[mid] == searchFor)
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
            return ChopRec(searchFor, array, left, right);
        }

        public static int ChopIterative(int searchFor, int[] array)
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
