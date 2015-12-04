namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;

    using WpfStuff;

    [Serializable]
    public class Quantity : TypeMetaData
    {
        private IUnit unit;
        private string unitName;

        public Quantity(IUnit unit)
            : base(null)
        {
            this.unit = unit;
            this.unit.Quantity = this;
            if (this.unit.Settings == null)
            {
                this.unit.PropertyChanged += (_, e) =>
                {
                    if (e.PropertyName == nameof(this.unit.Settings))
                    {
                        this.unit.Settings.SiUnits.CollectionChanged += (__, _e) => OnPropertyChanged(nameof(OperatorOverloads));
                        this.unit.Settings.DerivedUnits.CollectionChanged += (__, _e) => OnPropertyChanged(nameof(OperatorOverloads));
                    }
                };
            }
            else
            {
                this.unit.Settings.SiUnits.CollectionChanged += (_, e) => OnPropertyChanged(nameof(OperatorOverloads));
                this.unit.Settings.DerivedUnits.CollectionChanged += (_, e) => OnPropertyChanged(nameof(OperatorOverloads));
            }
            this.unit.PropertyChanged += (_, e) => OnPropertyChanged(nameof(Interface));
        }

        public string UnitName
        {
            get
            {
                if (Unit != null)
                {
                    return Unit.ClassName;
                }
                return this.unitName;
            }
            set
            {
                if (Unit != null)
                {
                    Unit.ClassName = value;
                }
                else
                {
                    this.unitName = value;
                }
            }
        }

        [XmlIgnore]
        public IUnit Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                if (Equals(value, this.unit))
                {
                    return;
                }
                this.unit = value;
                if (this.unit != null)
                {
                    this.unit.Quantity = this;
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(UnitName));
                OnPropertyChanged(nameof(Interface));
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
                        if (eventArgs.PropertyName == nameof(siUnit.QuantityName))
                        {
                            OnPropertyChanged();
                        }
                    };
                    return $"IQuantity<{siUnit.Quantity.ClassName}Unit, I1>";
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
                    flattened.Select(u => $"{u.Unit.Quantity.ClassName}Unit, I{(u.Power < 0 ? "Neg" : "")}{(u.Power < 0 ? -1 * u.Power : u.Power)}"));
                return $"IQuantity<{args}>";
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
        public Settings Settings => Unit.Settings;

        public override string ToString()
        {
            return $"{ClassName} ({Unit.ToString()})";
        }
    }
}
