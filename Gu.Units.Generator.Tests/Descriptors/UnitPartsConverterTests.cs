namespace Gu.Units.Generator.Tests.Descriptors
{
    using System.Collections.Generic;
    using System.Linq;
    using Gu.Units.Generator.WpfStuff;
    using NUnit.Framework;

    public static class UnitPartsConverterTests
    {
        private static readonly TestCase[] TestCases = CreateTestCases();

        [TestCaseSource(nameof(TestCases))]
        public static void ConvertFrom(TestCase testCase)
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
                new TestCase("s^-1", "s⁻¹", UnitAndPower.Create(seconds, -1)),
                ////new Data("J/s",UnitAndPower.Create(Joules, 1),UnitAndPower.Create(Seconds, -1)),
            };
        }

#pragma warning disable CA1034 // Nested types should not be visible
        public class TestCase
#pragma warning restore CA1034 // Nested types should not be visible
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
