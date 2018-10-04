using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace anagram_kata2
{
    public class AnagramalistConcurentDictionary : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var dic = new ConcurrentDictionary<string, string>();

            var parallelLoopResult = Parallel.ForEach(words, word =>
            {
                string ordered = new string(word.OrderBy(c => c).ToArray());
                dic.AddOrUpdate(ordered, word, (key, currentValue) => currentValue + " " + word);
            });
            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }
    }
}