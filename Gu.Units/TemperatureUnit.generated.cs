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
        public static readonly TemperatureUnit Kelvin = new TemperatureUnit(1.0, 0, "K");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kelvin"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TemperatureUnit K = Kelvin;

        /// <summary>
        /// The <see cref="T:Gu.Units.Celsius"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TemperatureUnit Celsius = new TemperatureUnit(1, -273.15, "°C");

        /// <summary>
        /// The <see cref="T:Gu.Units.Fahrenheit"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TemperatureUnit Fahrenheit = new TemperatureUnit(1.8, -459.67, "°F");

        private readonly double _conversionFactor;
        private readonly double _offset;
        private readonly string _symbol;

        public TemperatureUnit(double conversionFactor, double offset, string symbol)
        {
            _conversionFactor = conversionFactor;
            _offset = offset;
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
            return _conversionFactor * value + _offset;
        }

        /// <summary>
        /// Converts a value from Kelvin.
        /// </summary>
        /// <param name="value">The value in Kelvin</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return (value - _offset) / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Kelvin.Symbol);
        }
    }
}