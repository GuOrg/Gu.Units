namespace Gu.Units
{
    public interface IUnit<out TQuantity> : IUnit
        where TQuantity : IQuantity
    {
        TQuantity Create(double value);
    }
}
