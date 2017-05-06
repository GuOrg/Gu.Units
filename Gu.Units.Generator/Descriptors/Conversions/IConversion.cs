namespace Gu.Units.Generator
{
    using System.Threading.Tasks;

    public interface IConversion : INameAndSymbol
    {
        string ToSi { get; }

        string FromSi { get; }

        Unit Unit { get; }

        Task<bool> CanRoundtripAsync();
    }
}