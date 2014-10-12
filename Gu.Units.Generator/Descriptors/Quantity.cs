namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class Quantity : TypeMetaData
    {
        private List<UnitAndPower> _units = new List<UnitAndPower>();
        private Quantity()
        {
        }

        public Quantity(string ns, string className, params UnitAndPower[] units)
            : base(className)
        {
            Namespace = ns;
            Type = new TypeMetaData(className);
            Units = units == null ? new List<UnitAndPower>() : units.OrderBy(x => x.Unit).ThenBy(x => x.Power).ToList();
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

        public List<UnitAndPower> Units
        {
            get { return _units; }
            set { _units = value; }
        }

        public string Interface
        {
            get
            {
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
