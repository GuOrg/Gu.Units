namespace Gu.Units.Generator
{
    using System.Threading.Tasks;

    public class IdentityConversion : IFactorConversion
    {
        public IdentityConversion(Unit unit)
        {
            this.Unit = unit;
        }

        public string Name => this.Unit.Name;

        public string ParameterName => this.Name.ToParameterName();

        public string XDocParameterName => this.Name.FirstCharLower();

        public string Symbol => this.Unit.Symbol;

        public double Factor => 1;

        public string ToSi => this.GetToSi();

        public string FromSi => this.GetFromSi();

        public Unit Unit { get; }

        public Task<bool> CanRoundtripAsync() => Task.FromResult(true);
    }
}