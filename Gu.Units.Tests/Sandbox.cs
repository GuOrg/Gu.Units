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
            Length length = 1*m;
            var time = 2 * s;
            var speed = length / time;
            Assert.AreEqual(0.5, speed.MetresPerSecond);
        }

        [Test, Explicit]
        public void PerformanceDoublesThenLengths()
        {
            var sw = Stopwatch.StartNew();
            var n = 10000000;
            double sum1 = 0;
            for (double i = 0; i < n; i++)
            {
                sum1 += i;
            }
            Console.WriteLine("Summing {0:E0} {1}s took: {2} ms", n, sum1.GetType().Name, sw.ElapsedMilliseconds);
            sw.Restart();
            var sum2 = new Length(1, LengthUnit.Metres);
            for (var i = 0; i < n; i++)
            {
                sum2 += new Length(i, LengthUnit.Metres);
            }
            Console.WriteLine("Summing {0:E0} {1}s took: {2} ms", n, sum2.GetType().Name, sw.ElapsedMilliseconds);
            //Summing 1E+007 Doubles took: 11 ms
            //Summing 1E+007 Lengths took: 8 ms
        }

        [Test, Explicit]
        public void PerformanceIntsThenLengths()
        {
            var sw = Stopwatch.StartNew();
            var n = 10000000;
            int sum1 = 0;
            for (int i = 0; i < n; i++)
            {
                sum1 += i;
            }
            Console.WriteLine("Summing {0:E0} {1}s took: {2} ms", n, sum1.GetType().Name, sw.ElapsedMilliseconds);
            sw.Restart();
            var sum2 = new Length(1, LengthUnit.Metres);
            for (var i = 0; i < n; i++)
            {
                sum2 += new Length(i, LengthUnit.Metres);
            }
            Console.WriteLine("Summing {0:E0} {1}s took: {2} ms", n, sum2.GetType().Name, sw.ElapsedMilliseconds);
            //Summing 1E+007 Int32s took: 5 ms
            //Summing 1E+007 Lengths took: 8 ms
        }

        [Test, Explicit]
        public void PerformanceLengthsThenDoubles()
        {
            var sw = Stopwatch.StartNew();
            var n = 10000000;
            var sum2 = new Length(1, LengthUnit.Metres);
            for (var i = 0; i < n; i++)
            {
                sum2 += new Length(i, LengthUnit.Metres);
            }
            Console.WriteLine("Summing {0:E0} {1}s took: {2} ms", n, sum2.GetType().Name, sw.ElapsedMilliseconds);
            sw.Restart();
            double sum1 = 0;
            for (double i = 0; i < n; i++)
            {
                sum1 += i;
            }
            Console.WriteLine("Summing {0:E0} {1}s took: {2} ms", n, sum1.GetType().Name, sw.ElapsedMilliseconds);
            //Summing 1E+007 Lengths took: 8 ms
            //Summing 1E+007 Doubles took: 11 ms
        }
    }
}
