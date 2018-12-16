using BenchmarkDotNet.Running;

namespace MyBenchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SortingBenchmark>();
        }
    }
}