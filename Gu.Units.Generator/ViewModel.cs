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
        private string _nameSpace;

        private readonly Settings _settings;

        public ViewModel()
        {
            this._settings = Settings.Instance;
            NameSpace = Settings.ProjectName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Quantity> Composites
        {
            get
            {
                return _settings.Composites;
            }
        }

        public ObservableCollection<Prefix> Prefixes
        {
            get { return _settings.Prefixes; }
        }

        public ObservableCollection<SiUnit> SiUnits
        {
            get { return _settings.SiUnitTypes; }
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

        public static void Save(string nameSpace, IEnumerable<Quantity> data, IEnumerable<Prefix> prefixes, IEnumerable<SiUnit> siUnits)
        {
            var settings = new Settings();
            //var nonEmpty = data.Where(x => x != null && x.Unit != null && !x.Unit.IsEmpty && !string.IsNullOrEmpty(x.ValueTypeName))
            //                       .ToArray();
            //var quantityNames = nonEmpty.Select(x => x.ValueTypeName)
            //                         .Distinct()
            //                         .ToArray();
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
            //settings.Prefixes.AddRange(prefixes.Where(x => !(string.IsNullOrEmpty(x.Name) && string.IsNullOrEmpty(x.Symbol))));
            //settings.SiUnitTypes.AddRange(siUnits);
            Settings.Save(settings, Settings.FullFileName);
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
