namespace Gu.Units.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Just testing for length assuming the other generated units will work.
    /// </summary>
    public class QuantityTests
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

        [TestCase(1, 2)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
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
    }
}
