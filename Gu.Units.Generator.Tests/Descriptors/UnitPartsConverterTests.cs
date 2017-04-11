namespace Gu.Units.Generator.Tests.Descriptors
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using NUnit.Framework;
    using WpfStuff;

    public class UnitPartsConverterTests
    {
        //// ReSharper disable UnusedMember.Local
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';
        //// ReSharper restore UnusedMember.Local

        public static TestCase[] TestCases { get; } = CreateTestCases();

        [TestCaseSource(nameof(TestCases))]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void ConvertFrom(TestCase testCase)
        {
            var converter = new UnitPartsConverter();
            Assert.IsTrue(converter.CanConvertFrom(null, typeof(string)));
            var parts = (UnitParts)converter.ConvertFrom(null, null, testCase.Value);
            CollectionAssert.AreEqual(testCase.Parts, parts);
            var convertTo = converter.ConvertTo(null, null, parts, typeof(string));
            Assert.AreEqual(testCase.Formatted, convertTo);
            Assert.AreEqual(testCase.Formatted, parts?.BaseUnitSymbol);
        }

        private static TestCase[] CreateTestCases()
        {
            var settings = MockSettings.Create();
            var metres = settings.Metres;
            var kilograms = settings.Kilograms;
            var seconds = settings.Seconds;
            return new[]
                       {
                           new TestCase("m^2", "m²", UnitAndPower.Create(metres, 2)),
                           new TestCase("m²", "m²", UnitAndPower.Create(metres, 2)),
                           new TestCase("m³", "m³", UnitAndPower.Create(metres, 3)),
                           new TestCase("kg⋅m/s²", "kg⋅m/s²", UnitAndPower.Create(kilograms, 1), UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -2)),
                           new TestCase("kg⋅m⋅s⁻²", "kg⋅m/s²", UnitAndPower.Create(kilograms, 1), UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -2)),
                           new TestCase("kg*m/s²", "kg⋅m/s²", UnitAndPower.Create(kilograms, 1), UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -2)),
                           new TestCase("m/s¹", "m/s", UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -1)),
                           new TestCase("m⋅s⁻¹", "m/s", UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -1)),
                           new TestCase("m¹⋅s^-1", "m/s", UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -1)),
                           new TestCase("m^1⋅s^-1", "m/s", UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -1)),
                           new TestCase("m¹⋅s⁻¹", "m/s", UnitAndPower.Create(metres, 1), UnitAndPower.Create(seconds, -1)),
                           new TestCase("1/s", "s⁻¹", UnitAndPower.Create(seconds, -1)),
                           new TestCase("s^-1", "s⁻¹", UnitAndPower.Create(seconds, -1))
                           ////new Data("J/s",UnitAndPower.Create(Joules, 1),UnitAndPower.Create(Seconds, -1)),
                       };
        }

        public class TestCase
        {
            public TestCase(string value, string formatted, params UnitAndPower[] parts)
            {
                this.Value = value;
                this.Formatted = formatted;
                this.Parts = parts;
            }

            public string Value { get; }

            public string Formatted { get; }

            public IEnumerable<UnitAndPower> Parts { get; }

            public override string ToString()
            {
                var units = string.Join(", ", this.Parts.Select(x => $"{x.Unit.Symbol}^{x.Power}"));
                return $"{this.Value} Formatted: {this.Formatted} Units: {{{units}}}";
            }
        }
    }
}
