namespace Gu.Units.Tests
{
    using Moq;
    using NUnit.Framework;

    public class ArithmeticsTests
    {
        private Mock<IQuantity<I1<ILengthUnit>, ILengthUnit>> _lengthMock1;
        private Mock<IQuantity<I1<ILengthUnit>, ILengthUnit>> _lengthMock2;
        [SetUp]
        public void Setup()
        {
            _lengthMock1 = new Mock<IQuantity<I1<ILengthUnit>, ILengthUnit>>();
            _lengthMock1.SetupGet(x => x.SiValue).Returns(2);
            _lengthMock2 = new Mock<IQuantity<I1<ILengthUnit>, ILengthUnit>>();
            _lengthMock2.SetupGet(x => x.SiValue).Returns(3); 
        }

        [Test]
        public void MultiplyOnceTest()
        {
            var multiply = Arithmetics.Multiply(_lengthMock1.Object, _lengthMock2.Object);
            Assert.IsInstanceOf<IQuantity<I2<ILengthUnit>, ILengthUnit>>(multiply);
            Assert.AreEqual(6, multiply.SiValue);
        }

        [Test]
        public void MultiplyTwiceTest()
        {
            var multiply = Arithmetics.Multiply(_lengthMock1.Object, _lengthMock2.Object);
            Assert.IsInstanceOf<IQuantity<I2<ILengthUnit>, ILengthUnit>>(multiply);
            Arithmetics.Multiply(multiply, _lengthMock1.Object);
            Assert.IsInstanceOf<IQuantity<I3<ILengthUnit>, ILengthUnit>>(multiply);
            Assert.AreEqual(12, multiply.SiValue);

        }
    }
}
