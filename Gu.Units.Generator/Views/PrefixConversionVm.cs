namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;
    using WpfStuff;

    public class PrefixConversionVm : INotifyPropertyChanged
    {
        public PrefixConversionVm(Prefix prefix, IUnit unit)
        {
            this.Unit = unit;
            Prefix = prefix;
            this.Conversion = new Conversion
            {
                BaseUnit = unit,
                Prefix = prefix
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IUnit Unit { get; }

        public Prefix Prefix { get; }

        public Conversion Conversion { get; }

        public bool IsUsed
        {
            get
            {
                if (this.Unit == null)
                {
                    return false;
                }
                return this.Unit.Conversions.Any(x => x.Formula.ConversionFactor == this.Conversion.Formula.ConversionFactor && x.Symbol == this.Conversion.Symbol);
            }
            set
            {
                if (value.Equals(IsUsed))
                {
                    return;
                }
                if (value)
                {
                    this.Unit.Conversions.Add(new Conversion { Prefix = Prefix });
                }
                else
                {
                    this.Unit.Conversions.InvokeRemove(x => x.Prefix != null && x.Prefix.Name == Prefix.Name);
                }
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}