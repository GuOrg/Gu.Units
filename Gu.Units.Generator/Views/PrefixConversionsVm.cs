namespace Gu.Units.Generator
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class PrefixConversionsVm : INotifyPropertyChanged
    {
        private readonly Settings settings;
        private readonly ObservableCollection<PrefixConversionVm> prefixes = new ObservableCollection<PrefixConversionVm>();
        private IUnit baseUnit;

        public PrefixConversionsVm(Settings settings)
        {
            this.settings = settings;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PrefixConversionVm> Prefixes => this.prefixes;

        public IUnit BaseUnit
        {
            get { return this.baseUnit; }
            set
            {
                if (Equals(value, this.baseUnit))
                {
                    return;
                }

                this.baseUnit = value;
                OnPropertyChanged();
            }
        }

        public void SetBaseUnit(IUnit value)
        {
            this.BaseUnit = value;
            this.prefixes.Clear();
            var siUnit = this.baseUnit as SiUnit;
            if (siUnit != null)
            {
                foreach (var prefix in this.settings.Prefixes)
                {
                    this.prefixes.Add(new PrefixConversionVm(prefix, this.baseUnit));
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
