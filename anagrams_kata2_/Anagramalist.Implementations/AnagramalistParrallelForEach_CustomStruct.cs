using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using test_string_vs_struct;

namespace Anagramalist.Implementations
{
    public class AnagramalistParrallelForEach_CustomStruct : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var dic = new ConcurrentDictionary<IRepresentOrderdString, string>();

            var parallelLoopResult = Parallel.ForEach(words, word =>
            {
                var key = IRepresentOrderdString.FromString(word);
                dic.AddOrUpdate(key, word, (_, currentValue) => currentValue + " " + word);
            });
            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }
    }
}