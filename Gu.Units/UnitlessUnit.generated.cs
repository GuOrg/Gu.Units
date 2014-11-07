namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.UnitlessUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct UnitlessUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Scalar"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Scalar = new UnitlessUnit(1.0, "ul");
        /// <summary>
        /// The <see cref="T:Gu.Units.Scalar"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit ul = Scalar;

        /// <summary>
        /// The <see cref="T:Gu.Units.PartsPerMillion"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit PartsPerMillion = new UnitlessUnit(1E-06, "ppm");
        /// <summary>
        /// The <see cref="T:Gu.Units.PartsPerMillion"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit ppm = PartsPerMillion;

        /// <summary>
        /// The <see cref="T:Gu.Units.Promilles"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Promilles = new UnitlessUnit(0.001, "‰");

        /// <summary>
        /// The <see cref="T:Gu.Units.Percents"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Percents = new UnitlessUnit(0.01, "%");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public UnitlessUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Scalar"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Unitless operator *(double left, UnitlessUnit right)
        {
            return Unitless.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Scalar"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Scalar.
        /// </summary>
        /// <param name="value">The value in Scalar</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Scalar.Symbol);
        }
    }
}