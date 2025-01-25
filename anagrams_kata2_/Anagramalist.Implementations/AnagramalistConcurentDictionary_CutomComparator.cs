using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anagramalist.Implementations
{
    public class AnagramalistConcurentDictionary_CutomComparator : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var comparer = new CharArrayComparer();

            var dic = new ConcurrentDictionary<char[], string>(comparer);

            var parallelLoopResult = Parallel.ForEach(words, word =>
            {
                var ordered = word.OrderBy(c => c).ToArray();
                dic.AddOrUpdate(ordered, word, (key, currentValue) => currentValue + " " + word);
            });
            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }
    }

    public class CharArrayComparer : IEqualityComparer<char[]>
    {
        public bool Equals(char[] x, char[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] != y[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public int GetHashCode(char[] obj)
        {
            int numPtr = 0;
            int num1 = 352654597;
            int num2 = num1;
            int length = obj.Length;
            while (length > 2)
            {
                num1 = (num1 << 5) + num1 + (num1 >> 27) ^ obj[numPtr];
                num2 = (num2 << 5) + num2 + (num2 >> 27) ^ obj[numPtr + 2];
                numPtr += 1;
                length -= 4;
            }

            if (length > 0)
                num1 = (num1 << 5) + num1 + (num1 >> 27) ^ obj[numPtr];
            return num1 + num2 * 1566083941;
        }
    }
}