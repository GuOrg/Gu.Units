namespace Gu.Units.Tests
{
    using System;
    using System.Diagnostics;
    using Internals.Parsing;
    using NUnit.Framework;

    // run benchmarks in release build
    [Explicit(Benchmarks.LongRunning)]
    public class SubstringCacheBenchmarks
    {
        // 2015-12-02| cache.TryFind(text, 4, out cached) 1 000 000 times with cache took: 29 ms
        // 2015-12-02| text.Substring(3, 4)               1 000 000 times            took: 16 ms
        [Test]
        public void TryFindSubStringWorstCase()
        {
            // this is not a really meaningful comparison as Find does much more work
            // finding the end while substring gets the end for free.
            // interesting as a base line.
            var cache = new StringMap<string>();
            cache.Add("abc0", "d");
            cache.Add("abc01", "e");
            cache.Add("abc1", "e");
            cache.Add("abc11", "e");
            cache.Add("abc2", "f");
            cache.Add("abc21", "f");

            const string text0 = "   abc0   ";
            const string text1 = "   abc1   ";
            const string text2 = "   abc2   ";
            string cached;
            cache.TryGetBySubString(text0, 4, out cached);

            var subString = text0.Substring(3, 4);

            var sw = Stopwatch.StartNew();
            var n = 1000000;
            for (int i = 0; i < n; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        cache.TryGetBySubString(text0, 4, out cached);
                        continue;
                    case 1:
                        cache.TryGetBySubString(text1, 4, out cached);
                        continue;
                    case 2:
                        cache.TryGetBySubString(text2, 4, out cached);
                        continue;
                    default:
                        throw new Exception();
                }
            }

            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| cache.TryFind(text, 4, out cached) {n:N0} times with cache took: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        subString = text0.Substring(3, 4);
                        continue;
                    case 1:
                        subString = text1.Substring(3, 4);
                        continue;
                    case 2:
                        subString = text2.Substring(3, 4);
                        continue;
                    default:
                        throw new Exception();
                }
            }

            sw.Stop();
            Console.WriteLine($"// {DateTime.Today.ToShortDateString()}| text.Substring(3, 4)               {n:N0} times            took: {sw.ElapsedMilliseconds} ms");
        }
    }
}
