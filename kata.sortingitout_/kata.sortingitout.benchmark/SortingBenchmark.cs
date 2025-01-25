using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace kata.sortingitout.bemchmark
{
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvMeasurementsExporter, RPlotExporter]
    public class SortingBenchmark
    {
        protected internal string _text;

        public SortingBenchmark()
        {
            _text = RandomString(1000);
        }

        private static string RandomString(int length)
        {
            var random = new Random(DateTimeOffset.UtcNow.Millisecond);
            byte[] data = new byte[length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte) random.Next('A', 'z');
            }
            var text = Encoding.UTF8.GetString(data);
            return text;
        }

        [Benchmark]
        public string TestSortUsingLinqu() => CharacterSorterUsingLinqu.Sort(_text);

        [Benchmark]
        public string TestCustomSort() => CharacterSorter.Sort(_text);
    }
}