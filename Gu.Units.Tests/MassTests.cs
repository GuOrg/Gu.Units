namespace Gu.Units.Tests
{
    using System.Collections.Generic;
    using System.Globalization;

    using NUnit.Framework;

    public class MassTests
    {
        public static IReadOnlyList<ConversionData> ConversionSource { get; } = new[]
                                                                               {
                                                                                   new ConversionData("28.349523125 g", "1 oz"),
                                                                                   new ConversionData("31.1034768 g", "1 troy", false),
                                                                                   new ConversionData("1 lb", "0.45359237 kg"),
                                                                                   new ConversionData("1 gr", "64.79891 mg", false),
                                                                               };

        [TestCaseSource(nameof(ConversionSource))]
        public void Conversion(ConversionData data)
        {
            var m1 = Mass.Parse(data.From, CultureInfo.InvariantCulture);
            var m2 = Mass.Parse(data.To, CultureInfo.InvariantCulture);
            if (data.Exactly)
            {
                Assert.AreEqual(m1, m2);
            }
            else
            {
                Assert.AreEqual(m1.ToString(), m2.ToString());
            }
        }
    }
}
