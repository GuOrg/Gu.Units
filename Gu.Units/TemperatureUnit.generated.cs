namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Temperature"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(TemperatureUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{TemperatureUnit.symbol}")]
    public struct TemperatureUnit : IUnit, IUnit<Temperature>, IEquatable<TemperatureUnit>
    {
        /// <summary>
        /// The TemperatureUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly TemperatureUnit Kelvin = new TemperatureUnit(kelvin => kelvin, kelvin => kelvin, "K");

        /// <summary>
        /// The Celsius unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TemperatureUnit Celsius = new TemperatureUnit(celsius => celsius + 273.15, kelvin => kelvin - 273.15, "°C");

        /// <summary>
        /// The Fahrenheit unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TemperatureUnit Fahrenheit = new TemperatureUnit(fahrenheit => (fahrenheit + 459.67) / 1.8, kelvin => 1.8 * kelvin - 459.67, "°F");

        private readonly Func<double, double> toKelvin;
        private readonly Func<double, double> fromKelvin;
        internal readonly string symbol;

        public TemperatureUnit(Func<double, double> toKelvin, Func<double, double> fromKelvin, string symbol)
        {
            this.toKelvin = toKelvin;
            this.fromKelvin = fromKelvin;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.TemperatureUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.TemperatureUnit"/>
        /// </summary>
        public TemperatureUnit SiUnit => Kelvin;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.TemperatureUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Kelvin;

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

        public static TemperatureUnit Parse(string text)
        {
            return UnitParser<TemperatureUnit>.Parse(text);
        }

        public static bool TryParse(string text, out TemperatureUnit value)
        {
            return UnitParser<TemperatureUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Kelvin.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKelvin(value);
        }

        /// <summary>
        /// Converts a value from Kelvin.
        /// </summary>
        /// <param name="value">The value in Kelvin</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kelvin)
        {
            return this.fromKelvin(kelvin);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Temperature(value, this)</returns>
        public Temperature CreateQuantity(double value)
        {
            return new Temperature(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in TemperatureUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Temperature quantity)
        {
            return FromSiUnit(quantity.kelvin);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(TemperatureUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TemperatureUnit && Equals((TemperatureUnit)obj);
        }

        public override int GetHashCode()
        {
            if (this.symbol == null)
            {
                return 0; // Needed due to default ctor
            }

            return this.symbol.GetHashCode();
        }
    }
}