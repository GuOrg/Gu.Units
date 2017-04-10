namespace Gu.Units.Tests
{
    using System.Collections.Generic;
    using System.Globalization;

    using NUnit.Framework;

    public partial class LengthTests
    {
        public static IReadOnlyList<TestCase> ConversionSource { get; } = new[]
        {
            new TestCase("25.4 mm", "1 in"),
            new TestCase("0.0254 m", "1 in"),
            new TestCase("12 in", "1 ft", false),
            new TestCase("1 ft", "0.3048 m", false),
            new TestCase("3 ft", "1 yd", false),
            new TestCase("1 m", "100 cm"),
            new TestCase("1 m", "1000 mm"),
            new TestCase("1 km", "1000 m"),
            new TestCase("1 mi", "1.609344 km"),
            new TestCase("1 mi", "1760 yd"),
        };

        [TestCaseSource(nameof(ConversionSource))]
        public void Conversion(TestCase data)
        {
            var l1 = Length.Parse(data.X, CultureInfo.InvariantCulture);
            var l2 = Length.Parse(data.Y, CultureInfo.InvariantCulture);
            if (data.Exactly)
            {
                Assert.AreEqual(l1, l2);
                Assert.AreEqual(l2, l1);
            }
            else
            {
                Assert.AreEqual(l1.ToString(), l2.ToString());
                Assert.AreEqual(l2.ToString(), l1.ToString());
            }
        }

        public class TestCase
        {
            public TestCase(string x, string y, bool exactly = true)
            {
                this.X = x;
                this.Y = y;
                this.Exactly = exactly;
            }

            public string X { get; }

            public string Y { get; }

            public bool Exactly { get; }

            public override string ToString()
            {
                var equalitySymbol = this.Exactly
                    ? "=="
                    : "~";
                return $"{this.X} {equalitySymbol} {this.Y}";
            }
        }
    }
}