namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<MetaDataViewModel> _unitData = new ObservableCollection<MetaDataViewModel>();
        private readonly ObservableCollection<Prefix> _prefixes = new ObservableCollection<Prefix>();
        private readonly ObservableCollection<SiUnit> _siUnits = new ObservableCollection<SiUnit>();

        private string _nameSpace;

        public ViewModel()
        {
            var settings = Settings.Instance;
            if (settings != null)
            {
                foreach (var quantity in settings.Quantities)
                {
                    //this.UnitData.Add(new MetaDataViewModel(quantity, quantity.SiUnit) { IsSiUnit = true });
                    //foreach (var u in quantity.Units)
                    //{
                    //    this.UnitData.Add(new MetaDataViewModel(quantity, u));
                    //}
                    //var emptyUnit = new MetaDataViewModel(quantity, Unit.Empty);
                    //emptyUnit.PropertyChanged += this.EmptyOnPropertyChanged;
                    //this.UnitData.Add(emptyUnit);
                }
                foreach (var prefix in settings.Prefixes)
                {
                    Prefixes.Add(prefix);
                }
                foreach (var siUnitType in settings.SiUnitTypes)
                {
                    SiUnits.Add(siUnitType);
                }
            }
            //var empty = new MetaDataViewModel(Quantity.Empty, Unit.Empty);
            //empty.PropertyChanged += EmptyOnPropertyChanged;
            //this.UnitData.Add(empty);
            NameSpace = Settings.ProjectName;
        }

        private void EmptyOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var i = UnitData.IndexOf((MetaDataViewModel)sender);
            var empty = new MetaDataViewModel(Quantity.Empty);
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

        public ObservableCollection<Prefix> Prefixes
        {
            get { return _prefixes; }
        }

        public ObservableCollection<SiUnit> SiUnits
        {
            get { return _siUnits; }
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

        public static void Save(IEnumerable<MetaDataViewModel> data, string nameSpace, IEnumerable<Prefix> prefixes, IEnumerable<SiUnit> siUnits)
        {
            var settings = new Settings();
            var nonEmpty = data.Where(x => x != null && x.Unit != null && !x.Unit.IsEmpty && !string.IsNullOrEmpty(x.ValueTypeName))
                                   .ToArray();
            var quantityNames = nonEmpty.Select(x => x.ValueTypeName)
                                     .Distinct()
                                     .ToArray();
            //foreach (var quantityName in quantityNames)
            //{
            //    var quantitys = nonEmpty.Where(x => x.ValueTypeName == quantityName)
            //                                 .ToArray();
            //    var units = quantitys.Where(x => !x.IsSiUnit).Select(x => x.Unit).ToArray();
            //    foreach (var unit in units)
            //    {
            //        unit.Quantity = new TypeMetaData(quantityName);
            //        unit.Namespace = nameSpace;
            //    }
            //    var siUnit = quantitys.Single(x => x.IsSiUnit).Unit;
            //    siUnit.Quantity = new TypeMetaData(quantityName);
            //    siUnit.Namespace = nameSpace;
            //    var unitValueMetaData = new Quantity(siUnit, nameSpace, quantityName, units);
            //    settings.Quantities.Add(unitValueMetaData);
            //}
            settings.Prefixes.AddRange(prefixes.Where(x => !(string.IsNullOrEmpty(x.Name) && string.IsNullOrEmpty(x.Symbol))));
            settings.SiUnitTypes.AddRange(siUnits);
            Settings.Save(settings, Settings.FullFileName);
        }

        public void Save()
        {
            ViewModel.Save(UnitData, NameSpace, Prefixes, SiUnits);
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
