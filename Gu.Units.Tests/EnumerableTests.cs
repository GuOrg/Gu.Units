namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class EnumerableTests
    {
        [Test]
        public void Min()
        {
            var lengths = new[] { Length.FromMetres(1), Length.FromMetres(2) };
            var actual = lengths.Min();
            Assert.AreEqual(Length.FromMetres(1), actual);
        }

        [Test]
        public void MinNan()
        {
            var lengths = new[] { Length.FromMetres(1), Length.FromMetres(double.NaN), Length.FromMetres(2) };
            var actual = lengths.Min();
            Assert.AreEqual(Length.FromMetres(double.NaN), actual);
        }

        [Test]
        public void MinNullable()
        {
            var lengths = new Length?[] { Length.FromMetres(1), null, Length.FromMetres(2) };
            var actual = lengths.Min();
            Assert.AreEqual(Length.FromMetres(1), actual);
        }

        [Test]
        public void Max()
        {
            var lengths = new[] { Length.FromMetres(1), Length.FromMetres(2) };
            var actual = lengths.Max();
            Assert.AreEqual(Length.FromMetres(2), actual);
        }

        [Test]
        public void MaxNan()
        {
            var lengths = new[] { Length.FromMetres(1), Length.FromMetres(double.NaN), Length.FromMetres(2) };
            var actual = lengths.Max();
            Assert.AreEqual(Length.FromMetres(double.NaN), actual);
        }

        [Test]
        public void MaxNullable()
        {
            var lengths = new Length?[] { Length.FromMetres(1), Length.FromMetres(2), null };
            var actual = lengths.Max();
            Assert.AreEqual(Length.FromMetres(2), actual);
        }

        [Test]
        public void Sum()
        {
            var lengths = new[] { Length.FromMetres(1), Length.FromMetres(2) };
            var actual = lengths.Sum();
            Assert.AreEqual(Length.FromMetres(3), actual);
        }

        [Test]
        public void SumNullable()
        {
            var lengths = new Length?[] { Length.FromMetres(1), null, Length.FromMetres(2) };
            var actual = lengths.Sum();
            Assert.AreEqual(Length.FromMetres(3), actual);
        }

        [Test]
        public void Average()
        {
            var lengths = new[] { Length.FromMetres(1), Length.FromMetres(2) };
            var actual = lengths.Average();
            Assert.AreEqual(Length.FromMetres(1.5), actual);
        }

        [Test]
        public void AverageNullable()
        {
            var lengths = new Length?[] { Length.FromMetres(1), null, Length.FromMetres(2) };
            var actual = lengths.Average();
            Assert.AreEqual(Length.FromMetres(1.5), actual);
        }
    }
}
