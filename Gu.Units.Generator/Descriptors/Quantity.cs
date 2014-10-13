namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    [Serializable, TypeConverter(typeof(QuantityConverter))]
    public class Quantity : TypeMetaData
    {
        private IUnit _unit;

        public Quantity()
        {
        }

        public Quantity(string @namespace, string className, IUnit unit)
            : base(@namespace, className)
        {
            _unit = unit;
        }

        public static Quantity Empty
        {
            get
            {
                return new Quantity("", "", null);
            }
        }

        /// <summary>
        /// DummyData for the template
        /// </summary>
        public static Quantity DummySiUnit
        {
            get
            {
                var siUnit = new SiUnit("Gu.Units", "Metres", "m");
                var quantity = new Quantity("", "Metres", siUnit);
                return quantity;
            }
        }

        public string UnitName
        {
            get
            {
                return Unit.ClassName;
            }
            set
            {
                _unit = new SiUnit(Namespace, value, null);
            }
        }

        [XmlIgnore]
        public IUnit Unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if (Equals(value, this._unit))
                {
                    return;
                }
                this._unit = value;
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
                    if (string.IsNullOrEmpty(siUnit.Symbol))
                    {
                        return "ERROR: no unit";
                    }
                    return siUnit.Symbol;
                }
                var derivedUnit = Unit as DerivedUnit;
                if (derivedUnit == null)
                {
                    return "Unit == null";
                }
                if (!derivedUnit.Parts.Any())
                {
                    return "ERROR No Units";
                }
                var args = string.Join(", ",
                    derivedUnit.Parts.Select(u => string.Format("I{0}{1}<{2}>",
                        u.Power < 0 ? "Neg" : "",
                        u.Power < 0 ? -1 * u.Power : u.Power,
                        u.Unit.ClassName)));
                return string.Format("IQuantity<IUnit{0}<{1}>>", derivedUnit.Parts.Count, args);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", ClassName, Unit.ToString());
        }
    }
}
