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
        private readonly SubUnit[] _subParts;
        public PartConversionVm(IUnit unit, params SubUnit[] subParts)
        {
            _unit = unit;
            _subParts = subParts;
            Temp = new SubUnit { BaseUnit = unit };
            Temp.SetParts(subParts);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SubUnit Temp { get; set; }

        public bool IsUsed
        {
            get
            {
                return _unit.SubUnits.Any(x => x.ConversionFactor == Temp.ConversionFactor);
            }
            set
            {
                if (value.Equals(IsUsed))
                {
                    return;
                }
                if (value)
                {
                    var subUnit = new SubUnit { BaseUnit = _unit };
                    subUnit.SetParts(_subParts);
                    _unit.SubUnits.Add(subUnit);
                }
                else
                {
                    _unit.SubUnits.InvokeRemove(x => x.ConversionFactor == Temp.ConversionFactor);
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
