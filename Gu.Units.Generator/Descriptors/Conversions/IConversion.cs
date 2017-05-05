namespace Gu.Units.Generator
{
    using System.Threading.Tasks;

    public interface IConversion : INameAndSymbol
    {
        string ToSi { get; }

        string FromSi { get; }

        string SymbolConversion { get; }

        Unit Unit { get; }

        bool CanRoundtrip { get; }

        Task<bool> CanRoundtripAsync();
    }
}