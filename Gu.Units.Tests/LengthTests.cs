namespace Gu.Units.Tests
{
    using System.Globalization;
    using System.Threading;
    using Internals.Parsing;
    using NUnit.Framework;

    /// <summary>
    /// Just testing for length assuming the other generated units will work.
    /// </summary>
    public class LengthTests
    {
        [Test]
        public void Equality()
        {
            var metres1 = Length.FromMetres(1.2);
            var metres2 = Length.FromMetres(1.2);
            Assert.AreEqual(metres1, metres2);
            Assert.IsTrue(metres1 == metres2);
            Assert.IsTrue(metres1.Equals(metres2));
            Assert.IsFalse(metres1 != metres2);
        }

        [TestCase(1.0, 2.0)]
        [TestCase(1.0, 1.0)]
        [TestCase(2.0, 1.0)]
        public void Compare(double d1, double d2)
        {
            var metres1 = Length.FromMetres(d1);
            var metres2 = Length.FromMetres(d2);
            Assert.AreEqual(d1 > d2, metres1 > metres2);
            Assert.AreEqual(d1 >= d2, metres1 >= metres2);
            Assert.AreEqual(d1 < d2, metres1 < metres2);
            Assert.AreEqual(d1 <= d2, metres1 <= metres2);
        }

        [Test]
        public void Addition()
        {
            var l1 = Length.FromMetres(1);
            var l2 = Length.FromCentimetres(1);
            var sums = new[]
                           {
                               l1 + l2,
                               l2 + l1
                           };
            var expected = Length.FromCentimetres(101);
            foreach (var sum in sums)
            {
                Assert.IsInstanceOf<Length>(sum);
                Assert.AreEqual(expected, sum);
            }
        }

        [Test]
        public void Subtraction()
        {
            var l1 = Length.FromMetres(1);
            var l2 = Length.FromCentimetres(1);
            var diff = l1 - l2;
            var expected = Length.FromCentimetres(99);
            Assert.IsInstanceOf<Length>(diff);
            Assert.AreEqual(expected, diff);
        }

        [Test]
        public void Multiplication()
        {
            var l = Length.FromMetres(1);
            var prods = new[]
                           {
                               l*2,
                               2*l
                           };
            var expected = Length.FromMetres(2);
            foreach (var prod in prods)
            {
                Assert.IsInstanceOf<Length>(prod);
                Assert.AreEqual(expected, prod);
            }
        }

        [Test]
        public void Division()
        {
            var l = Length.FromMetres(1);
            var divided = l / 2;
            var expected = Length.FromMetres(0.5);
            Assert.IsInstanceOf<Length>(divided);
            Assert.AreEqual(expected, divided);
        }

        [Test]
        public new void ToString()
        {
            var length = Length.FromMetres(1.2);

            using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
            {
                Assert.AreEqual("1.2\u00A0m", length.ToString());
                Assert.AreEqual("120\u00A0cm", length.ToString(LengthUnit.Centimetres));
                Assert.AreEqual(" 1200.0 mm ", length.ToString(" F1 mm "));
                Assert.AreEqual(" F1 {unit: null}", length.ToString(" F1 "));
                Assert.AreEqual("12.0\u00A0dm", length.ToString("F1", LengthUnit.Decimetres));
            }

            var sv = CultureInfo.GetCultureInfo("sv-SE");
            Assert.AreEqual("1,2\u00A0m", length.ToString(sv));
            Assert.AreEqual(" 1200,0 mm ", length.ToString(" F1 mm ", sv));
            Assert.AreEqual("1200,0\u00A0mm", length.ToString("F1", LengthUnit.Millimetres, sv));
        }
    }
}
