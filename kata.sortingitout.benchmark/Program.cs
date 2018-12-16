using BenchmarkDotNet.Running;

namespace MyBenchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
//            var summary = BenchmarkRunner.Run<Md5VsSha256>();
            var summary = BenchmarkRunner.Run<SortingBenchmark>();
        }
    }
}