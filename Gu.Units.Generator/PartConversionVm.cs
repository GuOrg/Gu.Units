namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;
    using WpfStuff;

    public class PartConversionVm : INotifyPropertyChanged
    {
        private readonly IUnit _unit;
        private readonly Conversion[] _subParts;
        public PartConversionVm(IUnit unit, params Conversion[] subParts)
        {
            _unit = unit;
            _subParts = subParts;
            Temp = new Conversion { BaseUnit = unit };
            Temp.SetParts(subParts);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Conversion Temp { get; set; }

        public bool IsUsed
        {
            get
            {
                return _unit.Conversions.Any(x => x.Formula.ConversionFactor == Temp.Formula.ConversionFactor);
            }
            set
            {
                if (value.Equals(IsUsed))
                {
                    return;
                }
                if (value)
                {
                    var subUnit = new Conversion { BaseUnit = _unit };
                    subUnit.SetParts(_subParts);
                    _unit.Conversions.Add(subUnit);
                }
                else
                {
                    _unit.Conversions.InvokeRemove(x => x.Formula.ConversionFactor == Temp.Formula.ConversionFactor);
                }
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Temp.Symbol;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
