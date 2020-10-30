namespace Gu.Units.Tests
{
    using System.Globalization;

    using NUnit.Framework;

    public partial class LengthTests
    {
        [TestCase("25.4 mm", "1 in", true)]
        [TestCase("0.0254 m", "1 in", true)]
        [TestCase("12 in", "1 ft", false)]
        [TestCase("1 ft", "0.3048 m", false)]
        [TestCase("3 ft", "1 yd", false)]
        [TestCase("1 m", "100 cm", true)]
        [TestCase("1 m", "1000 mm", true)]
        [TestCase("1 km", "1000 m", true)]
        [TestCase("1 mi", "1.609344 km", true)]
        [TestCase("1 mi", "1760 yd", true)]
        public void Conversion(string x, string y, bool exact)
        {
            var l1 = Length.Parse(x, CultureInfo.InvariantCulture);
            var l2 = Length.Parse(y, CultureInfo.InvariantCulture);
            if (exact)
            {
                Assert.AreEqual(l1, l2);
                Assert.AreEqual(l2, l1);
            }
            else
            {
                Assert.AreEqual(l1.ToString(CultureInfo.InvariantCulture), l2.ToString(CultureInfo.InvariantCulture));
                Assert.AreEqual(l2.ToString(CultureInfo.InvariantCulture), l1.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}