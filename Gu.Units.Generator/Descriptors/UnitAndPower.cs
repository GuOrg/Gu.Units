namespace Gu.Units.Generator
{
    using System;
    using System.Xml.Serialization;

    public class UnitAndPower
    {
        public UnitAndPower()
        {
            Unit = new SiUnit();
        }

        public UnitAndPower(SiUnit unit)
        {
            Unit = unit;
            Power = 1;
        }
        public UnitAndPower(SiUnit unit, int power)
        {
            if (power == 0)
            {
                throw new ArgumentException("power == 0", "power");
            }
            Unit = unit;
            Power = power;
        }
        [XmlIgnore]
        public SiUnit Unit { get; set; }

        public string UnitName
        {
            get
            {
                return Unit.ClassName;
            }
            set
            {
                Unit = new SiUnit { ClassName = value };
            }
        }

        public int Power { get; set; }
        public override string ToString()
        {
            if (Power == 1)
            {
                return Unit.ClassName;
            }
            return string.Format("{0}^{1}", Unit.ClassName, Power);
        }
    }
}
