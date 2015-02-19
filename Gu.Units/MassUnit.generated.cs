namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.MassUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct MassUnit : IUnit, IUnit<Mass>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilograms"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Kilograms = new MassUnit(1.0, "kg");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilograms"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit kg = Kilograms;

        /// <summary>
        /// The <see cref="T:Gu.Units.Grams"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Grams = new MassUnit(0.001, "g");
        /// <summary>
        /// The <see cref="T:Gu.Units.Grams"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit g = Grams;

        /// <summary>
        /// The <see cref="T:Gu.Units.Milligrams"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Milligrams = new MassUnit(1E-06, "mg");
        /// <summary>
        /// The <see cref="T:Gu.Units.Milligrams"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit mg = Milligrams;

        /// <summary>
        /// The <see cref="T:Gu.Units.Micrograms"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Micrograms = new MassUnit(1E-09, "µg");
        /// <summary>
        /// The <see cref="T:Gu.Units.Micrograms"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit µg = Micrograms;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public MassUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Mass operator *(double left, MassUnit right)
        {
            return Mass.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Kilograms.
        /// </summary>
        /// <param name="value">The value in Kilograms</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public Mass Create(double value)
        {
            return new Mass(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Kilograms.Symbol);
        }
    }
}