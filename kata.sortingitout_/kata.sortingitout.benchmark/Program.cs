using BenchmarkDotNet.Running;

namespace kata.sortingitout.bemchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SortingBenchmark>();
        }
    }
}