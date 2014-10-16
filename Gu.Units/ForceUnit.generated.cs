namespace Gu.Units
{
    using System;

    [Serializable]
    public struct ForceUnit : IUnit
    {
        public static readonly ForceUnit Newtons = new ForceUnit(1.0, "N");
        public static readonly ForceUnit N = Newtons;

        public static readonly ForceUnit Nanonewtons = new ForceUnit(1E-09, "nN");
        public static readonly ForceUnit nN = Nanonewtons;

        public static readonly ForceUnit Micronewtons = new ForceUnit(1E-06, "µN");
        public static readonly ForceUnit µN = Micronewtons;

        public static readonly ForceUnit Millinewtons = new ForceUnit(0.001, "mN");
        public static readonly ForceUnit mN = Millinewtons;

        public static readonly ForceUnit Kilonewtons = new ForceUnit(1000, "kN");
        public static readonly ForceUnit kN = Kilonewtons;

        public static readonly ForceUnit Meganewtons = new ForceUnit(1000000, "MN");
        public static readonly ForceUnit MN = Meganewtons;

        public static readonly ForceUnit Giganewtons = new ForceUnit(1000000000, "GN");
        public static readonly ForceUnit GN = Giganewtons;


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public ForceUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Force operator *(double left, ForceUnit right)
        {
            return Force.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Force "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Newtons "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Newtons.Symbol);
        }
    }
}
