namespace Gu.Units.Generator
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;


    public class MainVm : INotifyPropertyChanged
    {
        private readonly Settings _settings;
        private string _nameSpace;
        private readonly ConversionsVm _conversions;

        private ObservableCollection<Prefix> _prefixes;

        private ObservableCollection<SiUnit> _siUnits;

        private ObservableCollection<DerivedUnit> _derivedUnits;

        public MainVm()
        {
            _settings = Settings.Instance;
            NameSpace = Settings.ProjectName;
            _conversions = new ConversionsVm(_settings);
            _prefixes = new ObservableCollection<Prefix>(_prefixes);
            _siUnits = new ObservableCollection<SiUnit>(_siUnits);
            _derivedUnits= new ObservableCollection<DerivedUnit>(_derivedUnits);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Prefix> Prefixes
        {
            get
            {
                return this._prefixes;
            }
        }

        public ObservableCollection<SiUnit> SiUnits
        {
            get
            {
                return this._siUnits;
            }
        }

        public ObservableCollection<DerivedUnit> DerivedUnits
        {
            get
            {
                return this._derivedUnits;
            }
        }

        public string NameSpace
        {
            get
            {
                return _nameSpace;
            }
            set
            {
                if (value == _nameSpace)
                {
                    return;
                }
                _nameSpace = value;
                this.OnPropertyChanged();
            }
        }

        public ConversionsVm Conversions
        {
            get
            {
                return _conversions;
            }
        }

        public void Save()
        {
            _settings.DerivedUnits.Clear();
            _settings.DerivedUnits.AddRange(DerivedUnits.Where(x=>x!=null && !x.IsEmpty));

            _settings.SiUnits.Clear();
            _settings.SiUnits.AddRange(SiUnits.Where(x => x != null && !x.IsEmpty));

            _settings.Prefixes.Clear();
            _settings.Prefixes.AddRange(Prefixes.Where(x => x != null && !x.IsEmpty));
            Settings.Save(_settings, Settings.FullFileName);
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
