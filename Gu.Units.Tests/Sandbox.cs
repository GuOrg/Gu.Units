namespace Gu.Units.Tests
{
    using System;
    using System.Diagnostics;

    using NUnit.Framework;

    public class Sandbox
    {
        private static LengthUnit m = LengthUnit.m;
        private static TimeUnit s = TimeUnit.s;

        [Test]
        public void TestNameTest()
        {
            var length = 1 * m;
            var time = 2 * s;
            var speed = length / time;
            Assert.AreEqual(0.5, speed.MetresPerSecond);
        }

        [Test, Explicit]
        public void PerformanceTest()
        {
            var sw = Stopwatch.StartNew();
            var n = 10000000;
            double sum1 = 0;
            for (double i = 0; i < n; i++)
            {
                sum1 += i;
            }
            Console.WriteLine("Summing {0:E0} doubles took: {1} ms", n, sw.ElapsedMilliseconds);
            sw.Restart();
            var sum2 = new Length(1, LengthUnit.Metres);
            for (var i = 0; i < n; i++)
            {
                sum2 += new Length(i, LengthUnit.Metres);
            }
            Console.WriteLine("Summing {0:E0} Lengths took: {1} ms", n, sw.ElapsedMilliseconds);
        }
    }
}
