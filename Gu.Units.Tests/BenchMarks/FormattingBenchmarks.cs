namespace Gu.Units.Tests
{
    using System;
    using System.Diagnostics;
    using Internals.Parsing;
    using NUnit.Framework;

    // run benchmarks in release build
    [Explicit(Benchmarks.LongRunning)]
    public class FormattingBenchmarks
    {
        // 2015-11-28| speed.ToString("F1 m/s")                                   1 000 000 times took: 995 ms
        // 2015-11-28| $"{ speed.metresPerSecond:F1} {SpeedUnit.MetresPerSecond}" 1 000 000 times took: 742 ms
        [Test]
        public void Benchmark()
        {
            // this is not a fair comparison as .ToString parses the arguments. Still interesting as a base line.
            var speed = Speed.FromMetresPerSecond(1.2);
            var toString = speed.ToString("F1 m/s");
            toString = speed.ToString("F0", "s⁻¹⋅mm");
            toString = speed.ToString("F2 m⋅s⁻¹");
            var string_Format = $"{speed.metresPerSecond:F1} {SpeedUnit.MetresPerSecond}";
            // end warmup

            var sw = Stopwatch.StartNew();
            var n = 1000000;
            for (int i = 0; i < n / 3; i++)
            {
                toString = speed.ToString("F1 m/s");
                toString = speed.ToString("F0", "s⁻¹⋅mm");
                toString = speed.ToString("F2 m⋅s⁻¹");
            }

            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| speed.ToString(\"F1 m/s\")                                   {n:N0} times took: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < n / 3; i++)
            {
                string_Format = $"{speed.metresPerSecond:F1} {SpeedUnit.MetresPerSecond}";
                string_Format = $"{speed.metresPerSecond:F0} s⁻¹⋅mm";
                string_Format = $"{speed.metresPerSecond:F2} m⋅s⁻¹";
            }

            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| $\"{{ speed.metresPerSecond:F1}} {{SpeedUnit.MetresPerSecond}}\" {n:N0} times took: {sw.ElapsedMilliseconds} ms");
        }

        [Test]
        public void ForProfiling()
        {
            // this is not a fair comparison as .ToString parses the arguments. Still interesting as a base line.
            var speed = Speed.FromMetresPerSecond(1.2);
            var toString = speed.ToString("F1 m/s");
            toString = speed.ToString("F0", "s⁻¹⋅mm");
            toString = speed.ToString("F2 m⋅s⁻¹");
            var string_Format = $"{speed.metresPerSecond:F1} {SpeedUnit.MetresPerSecond}";
            // end warmup

            var n = 1000000;
            for (int i = 0; i < n/3; i++)
            {
                toString = speed.ToString("F1 m/s");
                toString = speed.ToString("F0", "s⁻¹⋅mm");
                toString = speed.ToString("F2 m⋅s⁻¹");
            }
        }
    }
}