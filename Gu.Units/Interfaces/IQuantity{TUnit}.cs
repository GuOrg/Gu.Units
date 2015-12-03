namespace Gu.Units
{
    public interface IQuantity<in TUnit> : IQuantity
        where TUnit : IUnit
    {
        double GetValue(TUnit unit);
    }
}