namespace Gu.Units.Tests.Samples
{
    using System.Globalization;
    using NUnit.Framework;

    public class Samples
    {
#pragma warning disable SA1311 // Static readonly fields should begin with upper-case letter
        private static readonly LengthUnit m = LengthUnit.Metres;
        private static readonly TimeUnit s = TimeUnit.Seconds;
#pragma warning restore SA1311 // Static readonly fields should begin with upper-case letter

        [Test]
        public void ArithmeticSample()
        {
            var length = 1 * m;
            var time = 2 * s;
            var speed = length / time;
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
