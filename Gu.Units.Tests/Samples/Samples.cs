namespace Gu.Units.Tests.Samples
{
    using System.Globalization;
    using NUnit.Framework;

    public class Samples
    {
        private static LengthUnit m = LengthUnit.Metres;
        private static TimeUnit s = TimeUnit.Seconds;

        [Test]
        public void ArithmeticSample()
        {
            Length length = 1 * m;
            Time time = 2 * s;
            Speed speed = length / time;
            Assert.AreEqual(0.5, speed.MetresPerSecond);
        }

        [Test]
        public void ConversionSample()
        {
            var l = Length.FromCentimetres(1.2);
            Assert.AreEqual(0.012, l.Metres);
        }

        [TestCase("1.2m/s")]
        [TestCase("1.2m^1/s^1")]
        [TestCase("1.2m^1*s^-1")]
        [TestCase("1.2m⋅s⁻¹")]
        [TestCase("1.2m¹/s¹")]
        [TestCase("1.2m^1/s¹")]
        public void ParsingSample(string text)
        {
            var speed = Speed.Parse(text, CultureInfo.InvariantCulture);
            Assert.AreEqual(Speed.FromMetresPerSecond(1.2), speed);

            Assert.IsTrue(Speed.TryParse(text, CultureInfo.InvariantCulture, out speed));
            Assert.AreEqual(Speed.FromMetresPerSecond(1.2), speed);
        }
    }
}
