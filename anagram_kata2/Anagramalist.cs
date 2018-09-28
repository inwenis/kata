using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace anagram_kata2
{
    public class Anagramalist : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var i = 20000;
            var batches = words.Length/i;
            batches += 1;

            var dic = new ConcurrentDictionary<string, string>();

            Parallel.For(0, batches, (batch) =>
            {
                var from = batch * i;
                var to = (batch + 1) * i;
                for (int j = from; j < to && j < words.Length; j++)
                {
                    string word = words[j];
                    //var key = KeyFrom(word);
                    //dic.AddOrUpdate(key, word, (_, curVal) => curVal + " " + word);
                }
            });

//            var parallelLoopResult = Parallel.ForEach(words, word =>
//            {
//                string ordered = new string(word.OrderBy(c => c).ToArray());
//                dic.AddOrUpdate(ordered, word, (s, s1) => s + " " + s1);
//                
//            });

//            foreach (var word in words.Where(x => x.Length > 1))
//            {
//                string ordered = new string(word.OrderBy(c => c).ToArray());
//
//                if (dic.ContainsKey(ordered))
//                {
//                    dic[ordered] += " " + word;
//                }
//                else
//                {
//                    dic[ordered] = word;
//                }
//            }

            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }

//        private static int KeyFrom(string word)
//        {
//            
//        }
    }
}