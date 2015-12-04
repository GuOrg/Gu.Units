namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;
    using WpfStuff;

    public class PartConversionVm : INotifyPropertyChanged
    {
        private readonly IUnit unit;
        private readonly Conversion[] subParts;
        public PartConversionVm(IUnit unit, params Conversion[] subParts)
        {
            this.unit = unit;
            this.subParts = subParts;
            Conversion = new Conversion { BaseUnit = unit };
            Conversion.SetParts(subParts);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Conversion Conversion { get; }

        public bool IsUsed
        {
            get
            {
                return this.unit.Conversions.Any(x => x.Formula.ConversionFactor == Conversion.Formula.ConversionFactor && x.Symbol == Conversion.Symbol);
            }
            set
            {
                if (value.Equals(IsUsed))
                {
                    return;
                }
                if (value)
                {
                    var subUnit = new Conversion { BaseUnit = this.unit };
                    subUnit.SetParts(this.subParts);
                    this.unit.Conversions.Add(subUnit);
                }
                else
                {
                    this.unit.Conversions.InvokeRemove(x => x.Formula.ConversionFactor == Conversion.Formula.ConversionFactor);
                }
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Conversion.Symbol;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
