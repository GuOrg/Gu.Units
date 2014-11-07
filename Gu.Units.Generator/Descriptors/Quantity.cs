namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    [Serializable]
    public class Quantity : TypeMetaData
    {
        private IUnit _unit;
        private string _unitName;

        public Quantity(IUnit unit)
            : base(null)
        {
            _unit = unit;
            _unit.Quantity = this;
            if (_unit.Settings == null)
            {
                _unit.PropertyChanged += (_, e) =>
                {
                    if (e.PropertyName == NameOf.Property(() => _unit.Settings, true))
                    {
                        _unit.Settings.SiUnits.CollectionChanged += (__, _e) => OnPropertyChanged("OperatorOverloads");
                        _unit.Settings.DerivedUnits.CollectionChanged += (__, _e) => OnPropertyChanged("OperatorOverloads");
                    }
                };
            }
            else
            {
                _unit.Settings.SiUnits.CollectionChanged += (_, e) => OnPropertyChanged("OperatorOverloads");
                _unit.Settings.DerivedUnits.CollectionChanged += (_, e) => OnPropertyChanged("OperatorOverloads");
            }
            _unit.PropertyChanged += (_, e) => OnPropertyChanged("Interface");
        }

        public string UnitName
        {
            get
            {
                if (Unit != null)
                {
                    return this.Unit.ClassName;
                }
                return _unitName;
            }
            set
            {
                if (Unit != null)
                {
                    this.Unit.ClassName = value;
                }
                else
                {
                    _unitName = value;
                }
            }
        }

        [XmlIgnore]
        public IUnit Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                if (Equals(value, _unit))
                {
                    return;
                }
                _unit = value;
                if (_unit != null)
                {
                    _unit.Quantity = this;
                }
                this.OnPropertyChanged();
                this.OnPropertyChanged("UnitName");
                this.OnPropertyChanged("Interface");
            }
        }

        [XmlIgnore]
        public string Interface
        {
            get
            {
                var siUnit = Unit as SiUnit;
                if (siUnit != null)
                {
                    siUnit.PropertyChanged += (sender, eventArgs) =>
                    {
                        if (eventArgs.PropertyName == NameOf.Property(() => siUnit.QuantityName, true))
                        {
                            OnPropertyChanged();
                        }
                    };
                    return string.Format("IQuantity<{0}Unit, I1>", siUnit.Quantity.ClassName);
                }
                var derivedUnit = Unit as DerivedUnit;
                if (derivedUnit == null)
                {
                    return null;
                }
                derivedUnit.Parts.CollectionChanged += (o, e) => OnPropertyChanged();
                var flattened = derivedUnit.Parts.Flattened.ToArray();
                if (!flattened.Any())
                {
                    return null;
                }
                var args = string.Join(", ",
                    flattened.Select(u => string.Format("{0}Unit, I{1}{2}",
                        u.Unit.Quantity.ClassName,
                        u.Power < 0 ? "Neg" : "",
                        u.Power < 0 ? -1 * u.Power : u.Power)));
                return string.Format("IQuantity<{0}>", args);
            }
        }

        [XmlIgnore]
        public IEnumerable<OperatorOverload> OperatorOverloads
        {
            get
            {
                if (Settings == null)
                {
                    return Enumerable.Empty<OperatorOverload>();
                }
                return Settings.Quantities.Where(x => x.ClassName != ClassName)
                               .Where(result => OperatorOverload.CanCreate(Settings, this, result))
                               .Select(result => new OperatorOverload(this, result, Settings));
            }
        }

        [XmlIgnore]
        public InverseOverload Inverse
        {
            get
            {
                if (Settings == null || Settings.Quantities == null) // For the template in designtime
                {
                    return null;
                }
                var inverse = Settings.Quantities.FirstOrDefault(x => x != null && InverseOverload.IsInverse(this, x));
                if (inverse == null)
                {
                    return null;
                }
                return new InverseOverload(this, inverse);
            }
        }

        [XmlIgnore]
        public Settings Settings
        {
            get { return Unit.Settings; }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", ClassName, Unit.ToString());
        }
    }
}
