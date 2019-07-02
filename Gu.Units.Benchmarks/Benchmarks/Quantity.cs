namespace Gu.Units.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class Quantity
    {
        [Benchmark(Baseline = true)]
        public double DoubleMultiply()
        {
            return 1.2 * 3.4;
        }

        [Benchmark]
        public Area LengthMultiplyLength()
        {
            return Length.FromMillimetres(1.2) * Length.FromMillimetres(3.4);
        }
    }
}
