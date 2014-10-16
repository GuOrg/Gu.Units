namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.FractionUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct FractionUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Fractions"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FractionUnit Fractions = new FractionUnit(1.0, "/x");

        /// <summary>
        /// The <see cref="T:Gu.Units.PartsPerMillion"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FractionUnit PartsPerMillion = new FractionUnit(1E-06, "ppm");
        /// <summary>
        /// The <see cref="T:Gu.Units.PartsPerMillion"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FractionUnit ppm = PartsPerMillion;

        /// <summary>
        /// The <see cref="T:Gu.Units.Promilles"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FractionUnit Promilles = new FractionUnit(0.001, "‰");

        /// <summary>
        /// The <see cref="T:Gu.Units.Percents"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FractionUnit Percents = new FractionUnit(0.01, "%");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public FractionUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Fractions"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Fraction operator *(double left, FractionUnit right)
        {
            return Fraction.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Fractions"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Fractions.
        /// </summary>
        /// <param name="value">The value in Fractions</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Fractions.Symbol);
        }
    }
}