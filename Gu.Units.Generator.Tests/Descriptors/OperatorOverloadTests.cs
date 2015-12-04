namespace Gu.Units.Generator.Tests.Descriptors
{
    using NUnit.Framework;

    public class OperatorOverloadTests
    {
        private MockSettings settings;
        private Quantity length;
        private Quantity speed;
        private Quantity time;
        private Quantity area;
        private Quantity volume;

        [SetUp]
        public void SetUp()
        {
            this.settings = new MockSettings();
            this.length = this.settings.Length;
            this.speed = this.settings.Speed;
            this.time = this.settings.Time;
            this.area = this.settings.Area;
            this.volume = this.settings.Volume;
        }

        [Test]
        public void LengthSpeed()
        {
            var @operator = new OperatorOverload(this.length, this.speed, this.settings);
            Assert.AreEqual(OperatorOverload.Divide, @operator.Operator);
            Assert.AreEqual(this.length, @operator.Left);
            Assert.AreEqual(this.time, @operator.Right);
            Assert.AreEqual(this.speed, @operator.Result);
        }

        [Test]
        public void SpeedTime()
        {
            var @operator = new OperatorOverload(this.speed, this.length, this.settings);
            Assert.AreEqual(OperatorOverload.Multiply, @operator.Operator);
            Assert.AreEqual(this.speed, @operator.Left);
            Assert.AreEqual(this.time, @operator.Right);
            Assert.AreEqual(this.length, @operator.Result);
        }

        [Test]
        public void LengthArea()
        {
            var @operator = new OperatorOverload(this.length, this.area, this.settings);
            Assert.AreEqual(OperatorOverload.Multiply, @operator.Operator);
            Assert.AreEqual(this.length, @operator.Left);
            Assert.AreEqual(this.length, @operator.Right);
            Assert.AreEqual(this.area, @operator.Result);
        }

        [Test]
        public void AreaLength()
        {
            var @operator = new OperatorOverload(this.area, this.length, this.settings);
            Assert.AreEqual(OperatorOverload.Divide, @operator.Operator);
            Assert.AreEqual(this.area, @operator.Left);
            Assert.AreEqual(this.length, @operator.Right);
            Assert.AreEqual(this.length, @operator.Result);
        }

        [Test]
        public void LengthVolume()
        {
            var @operator = new OperatorOverload(this.length, this.volume, this.settings);
            Assert.AreEqual(OperatorOverload.Multiply, @operator.Operator);
            Assert.AreEqual(this.length, @operator.Left);
            Assert.AreEqual(this.area, @operator.Right);
            Assert.AreEqual(this.volume, @operator.Result);
        }
    }
}
