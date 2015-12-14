namespace Gu.Units.Generator.Tests.Descriptors
{
    using System.Linq;
    using NUnit.Framework;

    public class QuantityTests
    {
        private MockSettings settings;
        [SetUp]
        public void SetUp()
        {
            this.settings = MockSettings.Create();
        }

        [Test]
        public void LengthOverloads()
        {
            var actual = this.settings.Length.OperatorOverloads.ToArray();
            var expected = new[]
                               {
                                   new OperatorOverload(this.settings.Length, Operator.Multiply, this.settings.Length, this.settings.Area),
                                   new OperatorOverload(this.settings.Length,Operator.Divide, this.settings.Time,this.settings.Speed),
                                   new OperatorOverload(this.settings.Length,Operator.Divide, this.settings.Speed, this.settings.Time),
                                   new OperatorOverload(this.settings.Length,Operator.Multiply, this.settings.Force, this.settings.Energy),
                                   new OperatorOverload(this.settings.Length, Operator.Multiply, this.settings.Area, this.settings.Volume),
                                   new OperatorOverload(this.settings.Length,Operator.Multiply, this.settings.Frequency, this.settings.Speed),
                               };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimeOverloads()
        {
            var actual = this.settings.Time.OperatorOverloads.ToArray();
            var expected = new[]
            {
                new OperatorOverload(this.settings.Time, Operator.Multiply, this.settings.Current, this.settings.ElectricCharge),
                new OperatorOverload(this.settings.Time, Operator.Multiply, this.settings.Speed, this.settings.Length),
                new OperatorOverload(this.settings.Time, Operator.Multiply, this.settings.Acceleration, this.settings.Speed),
                new OperatorOverload(this.settings.Time, Operator.Multiply, this.settings.Power, this.settings.Energy),
            };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Inversions()
        {
            var actual = this.settings.Time.Inverse;
            Assert.AreEqual("1 / Time = Frequency", actual.ToString());
            actual = this.settings.Frequency.Inverse;
            Assert.AreEqual("1 / Frequency = Time", actual.ToString());
            Assert.IsNull(this.settings.Length.Inverse);
        }
    }
}
