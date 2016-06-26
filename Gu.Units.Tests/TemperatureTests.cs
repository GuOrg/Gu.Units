namespace Gu.Units.Tests
{
    using System.Collections.Generic;
    using System.Globalization;

    using NUnit.Framework;

    public class TemperatureTests
    {
        public static IReadOnlyList<ConversionData> ConversionSource { get; } = new[]
                                                                                    {
                                                                                        new ConversionData("0.01°C", "273.16K", false),
                                                                                        new ConversionData("32.018°F", "273.16K", false),
                                                                                        new ConversionData("-40°F", "-40°C", false),
                                                                                    };

        [TestCaseSource(nameof(ConversionSource))]
        public void Conversion(ConversionData data)
        {
            if (data.Status == ConversionData.GenerationStatus.NotGenerated)
            {
                Assert.Inconclusive(data.ToString());
            }

            var t1 = Temperature.Parse(data.From, CultureInfo.InvariantCulture);
            var t2 = Temperature.Parse(data.To, CultureInfo.InvariantCulture);
            if (data.Exactly)
            {
                Assert.AreEqual(t1, t2);
            }
            else
            {
                Assert.AreEqual(t1.ToString(), t2.ToString());
            }
        }
    }
}