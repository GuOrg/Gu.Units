namespace GeneratorBox.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using GeneratorBox.Generator.Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<MetaDataViewModel> _unitData = new ObservableCollection<MetaDataViewModel>();

        private string _nameSpace;

        public ViewModel()
        {
            var settings = Settings.FromFile(Settings.FullFileName);
            if (settings != null)
            {
                foreach (var unit in settings.ValueTypes)
                {
                    this.UnitData.Add(new MetaDataViewModel(unit, unit.SiUnit) { IsSiUnit = true });
                    foreach (var u in unit.Units)
                    {
                        this.UnitData.Add(new MetaDataViewModel(unit, u));
                    }
                    var emptyUnit = new MetaDataViewModel(unit, UnitMetaData.Empty);
                    emptyUnit.PropertyChanged += this.EmptyOnPropertyChanged;
                    this.UnitData.Add(emptyUnit);
                }
            }
            var empty = new MetaDataViewModel(ValueMetaData.Empty, UnitMetaData.Empty);
            empty.PropertyChanged += EmptyOnPropertyChanged;
            this.UnitData.Add(empty);
            NameSpace = Settings.ProjectName;
        }

        private void EmptyOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var i = UnitData.IndexOf((MetaDataViewModel)sender);
            var empty = new MetaDataViewModel(ValueMetaData.Empty, UnitMetaData.Empty);
            empty.PropertyChanged += EmptyOnPropertyChanged;
            UnitData.Insert(i + 1, empty);
            ((INotifyPropertyChanged)sender).PropertyChanged -= this.EmptyOnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MetaDataViewModel> UnitData
        {
            get
            {
                return this._unitData;
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

        public void Save()
        {
            var settings = new Settings();
            var unitNames = UnitData.Where(x => !string.IsNullOrEmpty(x.ValueTypeName))
                                    .Select(x => x.ValueTypeName)
                                    .Distinct()
                                    .ToArray();
            foreach (var unitName in unitNames)
            {
                var units = this.UnitData.Where(x => x != null && x.ValueTypeName == unitName)
                                             .ToArray();
                var metaDatas = units.Where(x => !x.IsSiUnit).Select(x => new UnitMetaData(unitName, NameSpace, x.ValueTypeName, 0, x.UnitName)).ToArray();
                var unitValueMetaData = new ValueMetaData(units.Single(x => x.IsSiUnit).UnitMetaData, NameSpace, unitName, metaDatas);
                settings.ValueTypes.Add(unitValueMetaData);
            }

            Settings.Save(settings, Settings.FullFileName);
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
