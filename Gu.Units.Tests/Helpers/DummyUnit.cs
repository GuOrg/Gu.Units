namespace Gu.Units.Tests
{
    public class DummyUnit : IUnit
    {
        public string Symbol { get; private set; }
        public double ToSiUnit(double value)
        {
            return 10 * value;
        }
    }
}