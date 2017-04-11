namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class UnitlessTests
    {
        [Test]
        public void LengthTimesUnitlessEqualsLength()
        {
            var l = Length.FromMetres(1.2);
            var percents = Unitless.FromPercents(50);
            var actual = l * percents;
            Assert.IsInstanceOf<Length>(actual);
            Assert.AreEqual(Length.FromMetres(1.2 * 0.5), actual);
        }

        [Test]
        public void CastDouble()
        {
            var unitless = (Unitless)0.5;
            Assert.AreEqual(50, unitless.Percents);
#pragma warning disable SA1131 // Use readable conditions
            Assert.IsTrue(0.5 == unitless);
#pragma warning restore SA1131 // Use readable conditions
        }
    }
}
