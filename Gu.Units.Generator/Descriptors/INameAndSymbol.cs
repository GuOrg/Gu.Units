namespace Gu.Units.Generator
{
    public interface INameAndSymbol 
    {
        string Name { get; }

        string ParameterName { get; }

        string Symbol { get; }
    }
}