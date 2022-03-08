namespace Gu.Units.Tests
{
    using System.Globalization;

    using NUnit.Framework;

    public class TemperatureTests
    {
        [TestCase("0.01°C", "273.16K", false)]
        [TestCase("32.018°F", "273.16K", false)]
        [TestCase("-40°F", "-40°C", false)]
        public void Conversion(string x, string y, bool exact)
        {
            var t1 = Temperature.Parse(x, CultureInfo.InvariantCulture);
            var t2 = Temperature.Parse(y, CultureInfo.InvariantCulture);
            if (exact)
            {
                Assert.AreEqual(t1, t2);
                Assert.AreEqual(t2, t1);
            }
            else
            {
                Assert.AreEqual(t1.ToString(CultureInfo.InvariantCulture), t2.ToString(CultureInfo.InvariantCulture));
                Assert.AreEqual(t2.ToString(CultureInfo.InvariantCulture), t1.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
