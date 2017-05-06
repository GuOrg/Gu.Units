namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public abstract class ConversionVm : INotifyPropertyChanged
    {
        private string symbolConversion = "Unknown";
        private bool? canRoundtrip;

        protected ConversionVm(IConversion conversion)
        {
            this.Conversion = conversion;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IConversion Conversion { get; }

        public string SymbolConversion
        {
            get => this.symbolConversion;

            private set
            {
                if (value == this.symbolConversion)
                {
                    return;
                }

                this.symbolConversion = value;
                this.OnPropertyChanged();
            }
        }

        public bool? CanRoundtrip
        {
            get => this.canRoundtrip;

            private set
            {
                if (value == this.canRoundtrip)
                {
                    return;
                }

                this.canRoundtrip = value;
                this.OnPropertyChanged();
            }
        }

        protected async Task UpdateAsync()
        {
            this.SymbolConversion = await this.Conversion.GetSymbolConversionAsync().ConfigureAwait(false);
            this.CanRoundtrip = await this.Conversion.CanRoundtripAsync().ConfigureAwait(false);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}