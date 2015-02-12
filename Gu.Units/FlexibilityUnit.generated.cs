namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.FlexibilityUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct FlexibilityUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerNewton"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MetresPerNewton = new FlexibilityUnit(1.0, "m/N");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerNewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerNewton = new FlexibilityUnit(0.001, "mm/N");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerKilonewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerKilonewton = new FlexibilityUnit(1E-06, "kN⁻¹⋅mm");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public FlexibilityUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Flexibility operator *(double left, FlexibilityUnit right)
        {
            return Flexibility.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerNewton.
        /// </summary>
        /// <param name="value">The value in MetresPerNewton</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), MetresPerNewton.Symbol);
        }
    }
}