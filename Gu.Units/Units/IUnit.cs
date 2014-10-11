namespace Gu.Units
{
    public interface IUnit
    {
        string Symbol { get; }
      
        double ToSiUnit(double value);
    }
}