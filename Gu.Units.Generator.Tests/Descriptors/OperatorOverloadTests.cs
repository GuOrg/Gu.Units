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
            this.settings = MockSettings.Create();
            this.length = this.settings.Length;
            this.speed = this.settings.Speed;
            this.time = this.settings.Time;
            this.area = this.settings.Area;
            this.volume = this.settings.Volume;
        }

        [TearDown]
        public void TearDown()
        {
            this.settings?.Dispose();
        }

        [Test]
        public void LengthDividedBySpeedEqualsTime()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateDivision(this.length, this.speed, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Divide, overload.Operator);
            Assert.AreEqual(this.length, overload.Left);
            Assert.AreEqual(this.speed, overload.Right);
            Assert.AreEqual(this.time, overload.Result);
        }

        [Test]
        public void LengthDividedByTimeEqualsSpeed()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateDivision(this.length, this.time, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Divide, overload.Operator);
            Assert.AreEqual(this.length, overload.Left);
            Assert.AreEqual(this.time, overload.Right);
            Assert.AreEqual(this.speed, overload.Result);
        }

        [Test]
        public void SpeedTimesTimeEqualsLength()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateMultiplication(this.speed, this.time, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Multiply, overload.Operator);
            Assert.AreEqual(this.speed, overload.Left);
            Assert.AreEqual(this.time, overload.Right);
            Assert.AreEqual(this.length, overload.Result);
        }

        [Test]
        public void TimeTimesSpeedEqualsLength()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateMultiplication(this.time, this.speed, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Multiply, overload.Operator);
            Assert.AreEqual(this.time, overload.Left);
            Assert.AreEqual(this.speed, overload.Right);
            Assert.AreEqual(this.length, overload.Result);
        }

        [Test]
        public void LengthTimesLengthEqualsArea()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateMultiplication(this.length, this.length, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Multiply, overload.Operator);
            Assert.AreEqual(this.length, overload.Left);
            Assert.AreEqual(this.length, overload.Right);
            Assert.AreEqual(this.area, overload.Result);
        }

        [Test]
        public void AreaDividedByLengthEqualsLength()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateDivision(this.area, this.length, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Divide, overload.Operator);
            Assert.AreEqual(this.area, overload.Left);
            Assert.AreEqual(this.length, overload.Right);
            Assert.AreEqual(this.length, overload.Result);
        }

        [Test]
        public void LengthTimesAreaEqualsVolume()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateMultiplication(this.length, this.area, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Multiply, overload.Operator);
            Assert.AreEqual(this.length, overload.Left);
            Assert.AreEqual(this.area, overload.Right);
            Assert.AreEqual(this.volume, overload.Result);
        }

        [Test]
        public void VolumeDividedByAreaAreaEqualsLength()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateDivision(this.volume, this.area, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Divide, overload.Operator);
            Assert.AreEqual(this.volume, overload.Left);
            Assert.AreEqual(this.area, overload.Right);
            Assert.AreEqual(this.length, overload.Result);
        }

        [Test]
        public void VolumeDividedByLengthAreaEqualsArea()
        {
            Assert.AreEqual(true, OperatorOverload.TryCreateDivision(this.volume, this.length, this.settings.AllUnits, out var overload));
            Assert.AreEqual(OperatorOverload.Divide, overload.Operator);
            Assert.AreEqual(this.volume, overload.Left);
            Assert.AreEqual(this.length, overload.Right);
            Assert.AreEqual(this.area, overload.Result);
        }
    }
}
