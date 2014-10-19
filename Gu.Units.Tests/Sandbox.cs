namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class Sandbox
    {
        private static LengthUnit m = LengthUnit.m;
        private static TimeUnit s = TimeUnit.s;

        [Test]
        public void TestNameTest()
        {
            var length = 1*m;
            var time = 2*s;
            var speed = length / time;
            Assert.AreEqual(0.5, speed.MetresPerSecond);
        }
    }
}
