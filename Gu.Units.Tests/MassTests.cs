namespace Gu.Units.Tests
{
    using System.Globalization;

    using NUnit.Framework;

    public class MassTests
    {
        [TestCase("28.349523125 g", "1 oz", true)]
        [TestCase("31.1034768 g", "1 troy", false)]
        [TestCase("1 lb", "0.45359237 kg", true)]
        [TestCase("1 gr", "64.79891 mg", false)]
        public void Conversion(string x, string y, bool exact)
        {
            var m1 = Mass.Parse(x, CultureInfo.InvariantCulture);
            var m2 = Mass.Parse(y, CultureInfo.InvariantCulture);
            if (exact)
            {
                Assert.AreEqual(m1, m2);
                Assert.AreEqual(m2, m1);
            }
            else
            {
                Assert.AreEqual(m1.ToString(CultureInfo.InvariantCulture), m2.ToString(CultureInfo.InvariantCulture));
                Assert.AreEqual(m2.ToString(CultureInfo.InvariantCulture), m1.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
