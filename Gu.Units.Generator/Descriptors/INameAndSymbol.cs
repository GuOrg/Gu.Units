namespace Gu.Units.Generator
{
    public interface INameAndSymbol
    {
        string Name { get; }

        string ParameterName { get; }

        string XDocParameterName { get; }

        string Symbol { get; }
    }
}