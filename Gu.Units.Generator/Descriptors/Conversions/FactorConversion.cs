namespace Gu.Units.Generator
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class FactorConversion : IFactorConversion, INotifyPropertyChanged
    {
        private string name;
        private string symbol;
        private double factor;
        private Unit unit;

        public FactorConversion(string name, string symbol, double factor)
        {
            this.name = name;
            this.symbol = symbol;
            this.factor = factor;
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

        public string Symbol
        {
            get => this.symbol;
            set
            {
                if (value == this.symbol)
                {
                    return;
                }

                this.symbol = value;
                this.OnPropertyChanged();
            }
        }

        public double Factor
        {
            get => this.factor;
            set
            {
                if (value.Equals(this.factor))
                {
                    return;
                }

                this.factor = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.ToSi));
                this.OnPropertyChanged(nameof(this.FromSi));
            }
        }

        public string ToSi => this.GetToSi();

        public string FromSi => this.GetFromSi();

        public Unit Unit => this.unit ??= this.GetUnit();

        public ObservableCollection<PrefixConversion> PrefixConversions { get; } = new();

        public Task<bool> CanRoundtripAsync() => this.CanRoundtripCoreAsync();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}