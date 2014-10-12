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
            var lengthMock1 = new Mock<IQuantity<I1<ILengthUnit>>>();
            lengthMock1.Setup(x => x.GetType()).Returns(typeof (IQuantity<I1<ILengthUnit>>));
            var lengthMock2 = new Mock<IQuantity<I1<ILengthUnit>>>();
            lengthMock2.Setup(x => x.GetType()).Returns(typeof(IQuantity<I1<ILengthUnit>>));

            var multiply = Arithmetics.Multiply(lengthMock1.Object, lengthMock2.Object);
            Assert.IsInstanceOf<IQuantity<I2<ILengthUnit>>>(multiply);
        }
    }
}
