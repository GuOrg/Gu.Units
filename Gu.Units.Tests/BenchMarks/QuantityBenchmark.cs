namespace Gu.Units.Tests
{
    using System;
    using System.Diagnostics;
    using Internals.Parsing;
    using NUnit.Framework;

    // run benchmarks in release build
    [Explicit(Benchmarks.LongRunning)]
    public class QuantityBenchmark
    {
        private const int n = 1000000;

        // Summing 1E+007 Doubles took: 11 ms
        // Summing 1E+007 Lengths took: 8 ms
        // 2015-11-28|  Summing 1 000 000 doubles took: 1 ms
        // 2015-11-28|  Summing 1 000 000 Lengths took: 6 ms
        [Test]
        public void CompareLengthAndDouble()
        {
            var sw = Stopwatch.StartNew();
            double sum1 = 0;
            for (double i = 0; i < n; i++)
            {
                sum1 += i;
            }

            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| Summing {n:N0} doubles took: {sw.ElapsedMilliseconds} ms");
            sw.Restart();
            var sum2 = Length.FromMetres(1);
            for (var i = 0; i < n; i++)
            {
                sum2 += Length.FromMetres(i);
            }

            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| Summing {n:N0} Lengths took: {sw.ElapsedMilliseconds} ms");
        }

        // Summing 1E+007 Int32s took: 5 ms
        // Summing 1E+007 Lengths took: 8 ms
        // 2015-12-02|  Summing 1 000 000 ints    took: 0 ms
        // 2015-12-02|  Summing 1 000 000 Lengths took: 6 ms
        [Test]
        public void CompareLengthAndInt()
        {
            var sw = Stopwatch.StartNew();
            int sum1 = 0;
            for (int i = 0; i < n; i++)
            {
                sum1 += i;
            }
            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| Summing {n:N0} ints    took: {sw.ElapsedMilliseconds} ms");
            sw.Restart();
            var sum2 = Length.FromMetres(1);
            for (var i = 0; i < n; i++)
            {
                sum2 += Length.FromMetres(i);
            }
            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| Summing {n:N0} Lengths took: {sw.ElapsedMilliseconds} ms");
        }
    }
}
