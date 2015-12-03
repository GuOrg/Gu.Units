namespace Gu.Units.Tests
{
    public class DummyUnit : IUnit
    {
        public string Symbol { get; private set; }

        public IUnit SiUnit { get; }

        public double ToSiUnit(double value)
        {
            return 10 * value;
        }
        public double FromSiUnit(double value)
        {
            throw new System.NotImplementedException();
        }
    }
}