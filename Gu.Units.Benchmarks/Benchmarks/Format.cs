namespace Gu.Units.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class Format
    {
        [Benchmark(Baseline = true)]
        public string StringConcat()
        {
            var speed = Speed.FromMetresPerSecond(1.2);
            return $"{speed.MetresPerSecond:F2} m/s";
        }

        [Benchmark]
        public string ToStringCompositeFormat()
        {
            var speed = Speed.FromMetresPerSecond(1.2);
            return speed.ToString("F2 m/s");
        }

        [Benchmark]
        public string ToStringFormatValueAndUnit()
        {
            var speed = Speed.FromMetresPerSecond(1.2);
            return speed.ToString("F2", "m/s");
        }
    }
}