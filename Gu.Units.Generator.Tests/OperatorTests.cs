namespace Gu.Units.Generator.Tests
{
    using NUnit.Framework;

    public class OperatorTests
    {
        private MockSettings _settings;
        private Quantity _length;
        private Quantity _speed;
        private Quantity _time;
        private Quantity _area;
        private Quantity _volume;

        [SetUp]
        public void SetUp()
        {
            _settings = new MockSettings();
            _length = _settings.Length;
            _speed = _settings.Speed;
            _time = _settings.Time;
            _area = _settings.Area;
            _volume = _settings.Volume;
        }

        [Test]
        public void LengthSpeed()
        {
            var @operator = new OperatorOverload(_length, _speed, _settings);
            Assert.AreEqual(OperatorOverload.Divide, @operator.Operator);
            Assert.AreEqual(_length, @operator.Left);
            Assert.AreEqual(_time, @operator.Right);
            Assert.AreEqual(_speed, @operator.Result);
        }

        [Test]
        public void SpeedTime()
        {
            var @operator = new OperatorOverload(_speed, _length, _settings);
            Assert.AreEqual(OperatorOverload.Multiply, @operator.Operator);
            Assert.AreEqual(_speed, @operator.Left);
            Assert.AreEqual(_time, @operator.Right);
            Assert.AreEqual(_length, @operator.Result);
        }

        [Test]
        public void LengthArea()
        {
            var @operator = new OperatorOverload(_length, _area, _settings);
            Assert.AreEqual(OperatorOverload.Multiply, @operator.Operator);
            Assert.AreEqual(_length, @operator.Left);
            Assert.AreEqual(_length, @operator.Right);
            Assert.AreEqual(_area, @operator.Result);
        }

        [Test]
        public void AreaLength()
        {
            var @operator = new OperatorOverload(_area, _length, _settings);
            Assert.AreEqual(OperatorOverload.Divide, @operator.Operator);
            Assert.AreEqual(_area, @operator.Left);
            Assert.AreEqual(_length, @operator.Right);
            Assert.AreEqual(_length, @operator.Result);
        }

        [Test]
        public void LengthVolume()
        {
            var @operator = new OperatorOverload(_length, _volume, _settings);
            Assert.AreEqual(OperatorOverload.Multiply, @operator.Operator);
            Assert.AreEqual(_length, @operator.Left);
            Assert.AreEqual(_area, @operator.Right);
            Assert.AreEqual(_volume, @operator.Result);
        }
    }
}
