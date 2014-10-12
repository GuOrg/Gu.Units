namespace Gu.Units.Tests
{
    using Moq;
    using NUnit.Framework;
    using Utils;

    public class ArithmeticsTests
    {
        [Test]
        public void MultiplyTest()
        {
            var lengthMock1 = new Mock<IQuantity<I1<ILengthUnit>, ILengthUnit>>();
            var lengthMock2 = new Mock<IQuantity<I1<ILengthUnit>, ILengthUnit>>();
            var multiply = Arithmetics.Multiply(lengthMock1.Object, lengthMock2.Object);
            Assert.IsInstanceOf<IQuantity<I2<ILengthUnit>, ILengthUnit>>(multiply);
        }
    }
}
