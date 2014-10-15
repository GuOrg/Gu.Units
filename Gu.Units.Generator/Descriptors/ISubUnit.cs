namespace Gu.Units.Generator
{
    public interface ISubUnit : IUnit
    {
        double ConversionFactor { get; set; }
    }
}