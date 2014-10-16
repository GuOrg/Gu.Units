namespace Gu.Units.Generator.Tests
{
    using System.Linq;
    using NUnit.Framework;

    public class OperatorTests
    {
        private const string Namespace = "Gu.Units";
        private SiUnit _metres;
        private SiUnit _seconds;
        private Quantity _length;
        private Quantity _time;
        private Quantity _speed;
        private Quantity[] _quantities;
        private DerivedUnit _metresPerSecond;
        [SetUp]
        public void SetUp()
        {
            _metres = (SiUnit)UnitBase.AllUnitsStatic.SingleOrDefault(x => x.ClassName == "Metres") ??
                            new SiUnit(Namespace, "Metres", "m");
            _seconds = (SiUnit)UnitBase.AllUnitsStatic.SingleOrDefault(x => x.ClassName == "Seconds") ??
                            new SiUnit(Namespace, "Seconds", "s");
            _length = new Quantity(Namespace, "Length", _metres);
            _time = new Quantity(Namespace, "Time", _seconds);
            _metresPerSecond = (DerivedUnit)UnitBase.AllUnitsStatic.SingleOrDefault(x => x.ClassName == "MetresPerSecond") ??
                                    new DerivedUnit(Namespace,
                                                    "MetresPerSecond",
                                                    "m/s",
                                                    new UnitAndPower(_metres, 1),
                                                    new UnitAndPower(_seconds, -1));
            _speed = new Quantity(Namespace, "Speed", _metresPerSecond);
            _quantities = new[] { _length, _time, _speed };
        }

        [Test]
        public void LengthSpeed()
        {
            var @operator = new OperatorOverload(_length, _speed);
            Assert.AreEqual(OperatorOverload.Divide, @operator.Operator);
            Assert.AreEqual(_length, @operator.Left);
            Assert.AreEqual(_time, @operator.Right);
            Assert.AreEqual(_speed, @operator.Result);
        }

        [Test]
        public void SpeedTime()
        {
            var @operator = new OperatorOverload(_speed, _length);
            Assert.AreEqual(OperatorOverload.Multiply, @operator.Operator);
            Assert.AreEqual(_speed, @operator.Left);
            Assert.AreEqual(_time, @operator.Right);
            Assert.AreEqual(_length, @operator.Result);
        }
    }
}
