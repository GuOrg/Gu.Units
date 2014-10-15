namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using WpfStuff;

    public class ConversionsVm : INotifyPropertyChanged
    {
        private readonly Settings _settings;
        private readonly ObservableCollection<PrefixConversionVm> _prefixes = new ObservableCollection<PrefixConversionVm>();
        private IUnit _baseUnit;
        public ConversionsVm(Settings settings)
        {
            _settings = settings;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IUnit BaseUnit
        {
            get { return _baseUnit; }
            set
            {
                if (Equals(value, _baseUnit))
                {
                    return;
                }
                _baseUnit = value;
                _prefixes.Clear();
                foreach (var prefix in _settings.Prefixes)
                {
                    _prefixes.Add(new PrefixConversionVm(prefix, _baseUnit));
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PrefixConversionVm> Prefixes
        {
            get { return _prefixes; }
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
