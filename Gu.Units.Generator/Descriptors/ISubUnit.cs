namespace Gu.Units.Generator
{
    public interface ISubUnit : IUnit
    {
        string Conversion { get; set; }
    }
}