namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class ArithmeticsTests
    {
        [Test]
        public void LengthPerTimeGivesSpeed()
        {
            var l = Length.FromMillimetres(1.2);
            var t = Time.FromMinutes(5);
            var speed = l / t;
            Assert.IsInstanceOf<Speed>(speed);
            Assert.AreEqual(1.2 / 5, speed.MillimetresPerMinute, 1E-6);

            var l2 = speed * t;
            Assert.IsInstanceOf<Length>(l2);
            Assert.AreEqual(l, l2);
        }

        [Test]
        public void LengthTimesLengthGivesArea()
        {
            var l1 = Length.FromMillimetres(1.2);
            var l2 = Length.FromMetres(5);
            var area = l1 * l2;
            Assert.IsInstanceOf<Area>(area);
            Assert.AreEqual(1.2E-3 * 5, area.SquareMetres, 1E-6);

            var length = area / l2;
            Assert.AreEqual(l1, length);
        }

        [Test]
        public void DensityTimesVolumeGivesMass()
        {
            var rho = Density.FromGramsPerCubicCentimetre(1.2);
            var v = Volume.FromCubicCentimetres(2);
            var m = rho * v;
            Assert.IsInstanceOf<Mass>(m);
            Assert.AreEqual(1.2*2, m.Grams, 1E-6);

            var density = m / v;
            Assert.AreEqual(rho, density);
        }
    }
}
