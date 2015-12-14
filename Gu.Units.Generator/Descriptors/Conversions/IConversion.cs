namespace Gu.Units.Generator
{
    public interface IConversion : INameAndSymbol
    {
        string ToSi { get; }

        string FromSi { get; }

        string SymbolConversion { get; }

        Unit Unit { get; }

        bool CanRoundtrip { get; }
    }
}