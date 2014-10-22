namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;
    using WpfStuff;

    public class PrefixConversionVm : INotifyPropertyChanged
    {
        private readonly IUnit _unit;
        private readonly Conversion _temp;
        public PrefixConversionVm(Prefix prefix, IUnit unit)
        {
            _unit = unit;
            Prefix = prefix;
            _temp = new Conversion
            {
                BaseUnit = unit,
                Prefix = prefix
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Prefix Prefix { get; private set; }

        public bool IsUsed
        {
            get
            {
                if (_unit == null)
                {
                    return false;
                }
                return _unit.Conversions.Any(x => x.Formula.ConversionFactor == _temp.Formula.ConversionFactor && x.Symbol == _temp.Symbol);
            }
            set
            {
                if (value.Equals(IsUsed))
                {
                    return;
                }
                if (value)
                {
                    _unit.Conversions.Add(new Conversion { Prefix = Prefix });
                }
                else
                {
                    _unit.Conversions.InvokeRemove(x => x.Prefix != null && x.Prefix.Name == Prefix.Name);
                }
                OnPropertyChanged();
            }
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