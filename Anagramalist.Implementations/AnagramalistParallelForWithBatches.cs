using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Anagramalist.Implementations
{
    public class AnagramalistParallelForWithBatches : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var batchSize = 20000;
            var batches = words.Length/batchSize;
            batches += 1;

            var dic = new ConcurrentDictionary<string, string>();

            Parallel.For(0, batches, (batch) =>
            {
                var from = batch * batchSize;
                var to = (batch + 1) * batchSize;
                for (int i = from; i < to && i < words.Length; i++)
                {
                    var word = words[i];
                    var ordered = new string(word.OrderBy(c => c).ToArray());
                    dic.AddOrUpdate(ordered, word, (key, curVal) => curVal + " " + word);
                }
            });

            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }
    }
}