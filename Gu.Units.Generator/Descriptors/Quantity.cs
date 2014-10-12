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
        private readonly ObservableCollection<UnitAndPower> _units = new ObservableCollection<UnitAndPower>();

        public Quantity()
        {
        }

        public Quantity(string ns, string className, params UnitAndPower[] units)
            : base(className)
        {
            Namespace = ns;
            Type = new TypeMetaData(className);
            var unitAndPowers = units.OrderBy(x => x.Unit).ThenBy(x => x.Power).ToList();
            foreach (var unitAndPower in unitAndPowers)
            {
                _units.Add(unitAndPower);
            }
            if (units.Length == 0)
            {
                throw new ArgumentException("No units", "units");
            }
            if (units.Length != units.Select(x => x.Unit.ClassName).Distinct().Count())
            {
                throw new ArgumentException("Units must be distinct", "units");
            }
        }
        public Quantity(string ns, string className, SiUnit unit)
            : this(ns, className, new[] { new UnitAndPower(unit) })
        {
        }

        public static Quantity Empty
        {
            get
            {
                return new Quantity("", "");
            }
        }

        /// <summary>
        /// DummyData for the template
        /// </summary>
        public static Quantity DummyBase
        {
            get
            {
                var siUnit = new SiUnit { ClassName = "Length" };
                var quantity = new Quantity("", "Metres", siUnit);
                return quantity;
            }
        }

        public string Namespace { get; set; }

        public TypeMetaData Type { get; set; }

        public ObservableCollection<UnitAndPower> Units
        {
            get { return _units; }
        }

        [XmlIgnore]
        public string UiName
        {
            get
            {
                if (!_units.Any())
                {
                    return "ERROR No Units";
                }
                var args = string.Join(", ",
                    Units.Select(u => string.Format("I{0}{1}<{2}>",
                        u.Power < 0 ? "Neg" : "",
                        u.Power < 0 ? -1 * u.Power : u.Power,
                        u.Unit.ClassName)));
                return args;
            }
        }
        
        [XmlIgnore]
        public string Interface
        {
            get
            {
                if (!_units.Any())
                {
                    return "ERROR No Units";
                }
                var args = string.Join(", ",
                    Units.Select(u => string.Format("I{0}{1}<{2}>",
                        u.Power < 0 ? "Neg" : "",
                        u.Power<0 ?-1*u.Power:u.Power ,
                        u.Unit.ClassName)));
                return string.Format("IQuantity<IUnit{0}<{1}>>", Units.Count,args );
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Units: {1}", Type.ClassName, string.Join("*", this.Units.Select(x => x.ToString())));
        }
    }
}
