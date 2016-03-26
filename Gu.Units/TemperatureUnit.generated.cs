namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Temperature"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(TemperatureUnitTypeConverter))]
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

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TemperatureUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.TemperatureUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.TemperatureUnit"/>.</param>
	    public static bool operator ==(TemperatureUnit left, TemperatureUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TemperatureUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.TemperatureUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.TemperatureUnit"/>.</param>
        public static bool operator !=(TemperatureUnit left, TemperatureUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="TemperatureUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="TemperatureUnit"/></returns>
        public static TemperatureUnit Parse(string text)
        {
            return UnitParser<TemperatureUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.TemperatureUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.TemperatureUnit"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="TemperatureUnit"/></param>
        /// <returns>True if an instance of <see cref="TemperatureUnit"/> could be parsed from <paramref name="text"/></returns>	
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
        /// Converts a value from kelvin.
        /// </summary>
        /// <param name="kelvin">The value in Kelvin</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kelvin)
        {
            return this.fromKelvin(kelvin);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Temperature(<paramref name="value"/>, this)</returns>
        public Temperature CreateQuantity(double value)
        {
            return new Temperature(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Kelvin
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Temperature quantity)
        {
            return FromSiUnit(quantity.kelvin);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.symbol;
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="format">The format to use when convereting</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string format)
        {
            TemperatureUnit unit;
            var paddedFormat = UnitFormatCache<TemperatureUnit>.GetOrCreate(format, out unit);
            if (unit != this)
            {
                return format;
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<TemperatureUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.TemperatureUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.TemperatureUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same TemperatureUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(TemperatureUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TemperatureUnit && Equals((TemperatureUnit)obj);
        }

        /// <inheritdoc />
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