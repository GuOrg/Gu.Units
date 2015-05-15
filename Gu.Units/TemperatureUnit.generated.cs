namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.TemperatureUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct TemperatureUnit : IUnit, IUnit<Temperature>, IEquatable<TemperatureUnit>
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

        public static bool operator ==(TemperatureUnit left, TemperatureUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TemperatureUnit left, TemperatureUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Kelvin"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return (value - _offset) / _conversionFactor;
        }

        /// <summary>
        /// Converts a value from Kelvin.
        /// </summary>
        /// <param name="value">The value in Kelvin</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return _conversionFactor * value + _offset;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public Temperature CreateQuantity(double value)
        {
            return new Temperature(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Temperature quantity)
        {
            return FromSiUnit(quantity.kelvin);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Kelvin.Symbol);
        }

        public bool Equals(TemperatureUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TemperatureUnit && Equals((TemperatureUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}