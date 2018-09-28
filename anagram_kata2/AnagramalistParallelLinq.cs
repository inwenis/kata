using System.Linq;

namespace anagram_kata2
{
    public class AnagramalistParallelLinq : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var anagrams = words
                .AsParallel()
                .GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
                .Where(g => g.Count() > 1)
                .Select(x => string.Join(" ", x))
                .ToArray();
            return anagrams.ToArray();
        }
    }
}