namespace Gu.Units.Benchmarks
{
    using System.Globalization;

    using BenchmarkDotNet.Attributes;

    // run benchmarks in release build
    public class Parse
    {
        [Benchmark(Baseline = true)]
        public double DoubleParse()
        {
            return double.Parse("1.2", CultureInfo.InvariantCulture);
        }

        [Benchmark]
        public Length LengthParse()
        {
            return Length.Parse("1.2 m", CultureInfo.InvariantCulture);
        }
    }
}
