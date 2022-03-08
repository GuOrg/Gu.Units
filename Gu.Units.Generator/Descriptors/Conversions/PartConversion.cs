namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class PartConversion : IFactorConversion, INotifyPropertyChanged
    {
        private Unit unit;
        private string name;

        public PartConversion(string name, string symbol, double factor)
        {
            this.name = name;
            this.Symbol = symbol;
            this.Factor = factor;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => this.name;
            set
            {
                if (value == this.name)
                {
                    return;
                }

                this.name = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.ToSi));
                this.OnPropertyChanged(nameof(this.FromSi));
                this.OnPropertyChanged(nameof(this.ParameterName));
                this.OnPropertyChanged(nameof(this.XDocParameterName));
            }
        }

        public string ParameterName => this.Name.ToParameterName();

        public string XDocParameterName => this.Name.FirstCharLower();

        public string Symbol { get; }

        public double Factor { get; }

        public string ToSi => this.GetToSi();

        public string FromSi => this.GetFromSi();

        public Unit Unit => this.unit ??= this.GetUnit();

        public static PartConversion Create(Unit unit, PowerPart c1)
        {
            var name = c1.FirstName;
            var symbol = c1.Symbol;
            var factor = c1.Factor;
            return new PartConversion(name, symbol, factor) { unit = unit }; // hacking unit like this for simpler serialization
        }

        public static PartConversion Create(Unit unit, PowerPart c1, PowerPart c2)
        {
            string name;
            if (c1.Power > 0 &&
                c2.Power > 0)
            {
                name = $"{c1.FirstName}{c2.LastName}";
            }
            else if (c1.Power > 0 && c2.Power < 0)
            {
                name = $"{c1.FirstName}Per{c2.LastName}";
            }
            else
            {
                throw new InvalidOperationException("Not handling this case.");
            }

            var symbolAndPowers = c1.AsSymbolAndPowers().Concat(c2.AsSymbolAndPowers());
            var symbol = symbolAndPowers.AsSymbol();
            var factor = c1.Factor * c2.Factor;
            //// hacking unit like this for simpler serialization
            return new PartConversion(name, symbol, factor) { unit = unit };
        }

        public static PowerPart CreatePart(int power, IFactorConversion conversion)
        {
            return new PowerPart(power, conversion);
        }

        public static PowerPart CreatePart(int power, Unit unit)
        {
            return new PowerPart(power, new IdentityConversion(unit));
        }

        public Task<bool> CanRoundtripAsync() => this.CanRoundtripCoreAsync();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
