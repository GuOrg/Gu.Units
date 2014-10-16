namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class ConversionsVm : INotifyPropertyChanged
    {
        private readonly Settings _settings;
        private readonly ObservableCollection<PrefixConversionVm> _prefixes = new ObservableCollection<PrefixConversionVm>();
        private readonly ObservableCollection<PartConversionVm[]> _subParts = new ObservableCollection<PartConversionVm[]>();

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
                _subParts.Clear();
                if (_baseUnit == null)
                {
                    return;
                }
                foreach (var prefix in _settings.Prefixes)
                {
                    _prefixes.Add(new PrefixConversionVm(prefix, _baseUnit));
                }
                var derivedUnit = _baseUnit as DerivedUnit;
                if (derivedUnit != null)
                {
                    if (derivedUnit.Parts.Count == 1)
                    {
                        _subParts.Add(derivedUnit.Parts.Single().Unit.SubUnits.Select(x => new PartConversionVm(_baseUnit, x)).ToArray());
                    }
                    else if (derivedUnit.Parts.Count == 2)
                    {
                        var partConversionVms = new List<PartConversionVm> { null };
                        partConversionVms.AddRange(derivedUnit.Parts[0].Unit.SubUnits.Select(x => new PartConversionVm(_baseUnit, x)));
                        _subParts.Add(partConversionVms.ToArray());
                        foreach (var u in derivedUnit.Parts[1].Unit.SubUnits)
                        {
                            partConversionVms.Clear();
                            partConversionVms.Add(new PartConversionVm(_baseUnit, u));
                            partConversionVms.AddRange(derivedUnit.Parts[0].Unit.SubUnits.Select(x => new PartConversionVm(_baseUnit, u, x)));
                            _subParts.Add(partConversionVms.ToArray());
                        }
                    }
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PrefixConversionVm> Prefixes
        {
            get { return _prefixes; }
        }

        public ObservableCollection<PartConversionVm[]> SubParts
        {
            get { return _subParts; }
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
