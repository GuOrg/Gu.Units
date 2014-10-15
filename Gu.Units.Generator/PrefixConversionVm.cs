namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;
    using WpfStuff;

    public class PrefixConversionVm : INotifyPropertyChanged
    {
        private readonly IUnit _unit;
        public PrefixConversionVm(Prefix prefix, IUnit unit)
        {
            _unit = unit;
            Prefix = prefix;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Prefix Prefix { get; private set; }

        public bool IsUsed
        {
            get
            {
                return _unit.SubUnits.Any(x => x.Prefix != null && x.Prefix.Name == Prefix.Name);
            }
            set
            {
                if (value.Equals(IsUsed))
                {
                    return;
                }
                if (value)
                {
                    _unit.SubUnits.Add(new SubUnit { Prefix = Prefix });
                }
                else
                {
                    _unit.SubUnits.InvokeRemove(x => x.Prefix != null && x.Prefix.Name == Prefix.Name);
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