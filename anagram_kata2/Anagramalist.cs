using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace anagram_kata2
{
    public class AnagramalistWithOutSorting : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var dic = new ConcurrentDictionary<int, string>();

            var parallelLoopResult = Parallel.ForEach(words, word =>
            {
                var key = KeyFrom(word);
                dic.AddOrUpdate(key, word, (_, currentValue) => currentValue + " " + word);
            });
            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }

        private static int KeyFrom(string word)
        {
            //return a good hash here
            return new Random().Next();
        }
    }
}