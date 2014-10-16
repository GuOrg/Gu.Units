namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.TemperatureUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct TemperatureUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Kelvin"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TemperatureUnit Kelvin = new TemperatureUnit(1.0, "°K");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public TemperatureUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Kelvin"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Temperature operator *(double left, TemperatureUnit right)
        {
            return Temperature.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Kelvin"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Kelvin.
        /// </summary>
        /// <param name="value">The value in Kelvin</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Kelvin.Symbol);
        }
    }
}