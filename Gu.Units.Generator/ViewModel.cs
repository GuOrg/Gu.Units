namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    using Gu.Units.Generator.WpfStuff;

    public class ViewModel : INotifyPropertyChanged
    {
        private readonly UnitCollection<SiUnit> _siUnits;
        private readonly UnitCollection<DerivedUnit> _derivedUnits;
        private readonly Settings _settings;
        private string _nameSpace;

        private IUnit _selectedUnit;

        public ViewModel()
        {
            this._settings = Settings.Instance;
            _siUnits = new UnitCollection<SiUnit>(_settings.SiUnits, x => SiUnit.Empty);
            _derivedUnits = new UnitCollection<DerivedUnit>(_settings.DerivedUnits, x => DerivedUnit.Empty);
            NameSpace = Settings.ProjectName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Prefix> Prefixes
        {
            get { return _settings.Prefixes; }
        }

        public UnitCollection<SiUnit> SiUnits
        {
            get
            {
                return _siUnits;
            }
        }

        public UnitCollection<DerivedUnit> DerivedUnits
        {
            get
            {
                return _derivedUnits;
            }
        }

        public string NameSpace
        {
            get
            {
                return this._nameSpace;
            }
            set
            {
                if (value == this._nameSpace)
                {
                    return;
                }
                this._nameSpace = value;
                this.OnPropertyChanged();
            }
        }

        public IUnit SelectedUnit
        {
            get
            {
                return this._selectedUnit;
            }
            set
            {
                if (Equals(value, this._selectedUnit))
                {
                    return;
                }
                this._selectedUnit = value;
                this.OnPropertyChanged();
            }
        }

        public void Save()
        {
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
