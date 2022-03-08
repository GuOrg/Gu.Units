namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class CustomConversion : IConversion, INotifyPropertyChanged
    {
        private string name;
        private string symbol;
        private Unit unit;
        private string toSi;
        private string fromSi;

        public CustomConversion(string name, string symbol, string toSi, string fromSi)
        {
            this.name = name;
            this.symbol = symbol;
            this.toSi = toSi;
            this.fromSi = fromSi;
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

        public string ToSi
        {
            get => this.toSi;
            set
            {
                if (value == this.toSi)
                {
                    return;
                }

                this.toSi = value;
                this.OnPropertyChanged();
            }
        }

        public string FromSi
        {
            get => this.fromSi;
            set
            {
                if (value == this.fromSi)
                {
                    return;
                }

                this.fromSi = value;
                this.OnPropertyChanged();
            }
        }

        public Unit Unit => this.unit ??= this.GetUnit();

        public Task<bool> CanRoundtripAsync() => this.CanRoundtripCoreAsync();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
