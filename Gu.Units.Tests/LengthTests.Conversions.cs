namespace Gu.Units.Tests
{
    using System.Collections.Generic;
    using System.Globalization;

    using NUnit.Framework;

    public partial class LengthTests
    {
        public static IReadOnlyList<ConversionData> ConversionSource { get; } = new[]
                                                                       {
                                                                                   new ConversionData("25.4 mm", "1 in"),
                                                                                   new ConversionData("0.0254 m", "1 in"),
                                                                                   new ConversionData("12 in", "1 ft", status:ConversionData.GenerationStatus.NotGenerated),
                                                                                   new ConversionData("1 ft", "0.3048 m",status:ConversionData.GenerationStatus.NotGenerated),
                                                                                   new ConversionData("1 m", "100 cm"),
                                                                                   new ConversionData("1 m", "1000 mm"),
                                                                                   new ConversionData("1 km", "1000 m"),
                                                                                   new ConversionData("1 mi", "1.609344 km"),
                                                                                   new ConversionData("1 mi", "1760 yd"),
                                                                               };

        [TestCaseSource(nameof(ConversionSource))]
        public void Conversion(ConversionData data)
        {
            if (data.Status == ConversionData.GenerationStatus.NotGenerated)
            {
                Assert.Inconclusive(data.ToString());
            }

            var l1 = Length.Parse(data.From, CultureInfo.InvariantCulture);
            var l2 = Length.Parse(data.To, CultureInfo.InvariantCulture);
            if (data.Exactly)
            {
                Assert.AreEqual(l1, l2);
            }
            else
            {
                Assert.AreEqual(l1.ToString(), l2.ToString());
            }
        }
    }
}