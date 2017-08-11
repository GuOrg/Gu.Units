namespace Gu.Units.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using NUnit.Framework;

    public class QuantityParseTests
    {
        private static readonly CultureInfo Sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly IReadOnlyList<TestCase> TestCases = new[]
        {
            new TestCase("1.2 m", s => Length.Parse(s, CultureInfo.InvariantCulture), Length.FromMetres(1.2)),
            new TestCase("1.2 μm", s => Length.Parse(s, CultureInfo.InvariantCulture), Length.FromMicrometres(1.2)),
            new TestCase("1.2 m^2", s => Area.Parse(s, CultureInfo.InvariantCulture), Area.FromSquareMetres(1.2)),
            new TestCase("1,2 m^2", s => Area.Parse(s, Sv), Area.FromSquareMetres(1.2)),
            new TestCase("1.2m²", s => Area.Parse(s, CultureInfo.InvariantCulture), Area.FromSquareMetres(1.2)),
            new TestCase("1.2s", s => Time.Parse(s, CultureInfo.InvariantCulture), Time.FromSeconds(1.2)),
            new TestCase("1.2h", s => Time.Parse(s, CultureInfo.InvariantCulture), Time.FromHours(1.2)),
            new TestCase("1.2ms", s => Time.Parse(s, CultureInfo.InvariantCulture), Time.FromMilliseconds(1.2)),
            new TestCase("1.2kg", s => Mass.Parse(s, CultureInfo.InvariantCulture), Mass.FromKilograms(1.2)),
            new TestCase("1.2g", s => Mass.Parse(s, CultureInfo.InvariantCulture), Mass.FromGrams(1.2)),
            new TestCase("1.2m³", s => Volume.Parse(s, CultureInfo.InvariantCulture), Volume.FromCubicMetres(1.2)),
            new TestCase("1.2m^3", s => Volume.Parse(s, CultureInfo.InvariantCulture), Volume.FromCubicMetres(1.2)),
            new TestCase("1.2m/s", s => Speed.Parse(s, CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            new TestCase("1.2m⋅s⁻¹", s => Speed.Parse(s, CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            new TestCase("1.2m*s⁻¹", s => Speed.Parse(s, CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            new TestCase("1.2m¹⋅s⁻¹", s => Speed.Parse(s,  CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            new TestCase("1.2m^1⋅s⁻¹", s => Speed.Parse(s,  CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            new TestCase("1.2m^1⋅s^-1", s => Speed.Parse(s,  CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            new TestCase("1.2m^1/s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            new TestCase("1.2m/s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            new TestCase("1.2 m/s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            new TestCase("1.2 m / s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            new TestCase("1.2 m / s²", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            new TestCase("1.2 mm / s²", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMillimetresPerSecondSquared(1.2)),
        };

        [TestCaseSource(nameof(TestCases))]
        public void Parse(TestCase testCase)
        {
            var actual = testCase.Parse(testCase.StringValue);
            Assert.AreEqual(testCase.Expected, actual);
        }

        public class TestCase
        {
            public TestCase(string stringValue, Func<string, IQuantity> parse, IQuantity expected)
            {
                this.StringValue = stringValue;
                this.Parse = parse;
                this.Expected = expected;
            }

            public string StringValue { get; }

            public Func<string, IQuantity> Parse { get;  }

            public IQuantity Expected { get; }

            public override string ToString()
            {
                return $"\"{this.StringValue}\" -> {this.Expected}";
            }
        }
    }
}