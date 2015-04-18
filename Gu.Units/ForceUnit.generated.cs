namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.ForceUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct ForceUnit : IUnit, IUnit<Force>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Newtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Newtons = new ForceUnit(1.0, "N");
        /// <summary>
        /// The <see cref="T:Gu.Units.Newtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit N = Newtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanonewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Nanonewtons = new ForceUnit(1E-09, "nN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanonewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit nN = Nanonewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Micronewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Micronewtons = new ForceUnit(1E-06, "µN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Micronewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit µN = Micronewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millinewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Millinewtons = new ForceUnit(0.001, "mN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millinewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit mN = Millinewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilonewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Kilonewtons = new ForceUnit(1000, "kN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilonewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit kN = Kilonewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Meganewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Meganewtons = new ForceUnit(1000000, "MN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Meganewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit MN = Meganewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Giganewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Giganewtons = new ForceUnit(1000000000, "GN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Giganewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit GN = Giganewtons;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public ForceUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Newtons"/>.
        /// </summary>
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
        /// Converts a value to <see cref="T:Gu.Units.Newtons"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Newtons.
        /// </summary>
        /// <param name="value">The value in Newtons</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public Force CreateQuantity(double value)
        {
            return new Force(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Newtons.Symbol);
        }
    }
}