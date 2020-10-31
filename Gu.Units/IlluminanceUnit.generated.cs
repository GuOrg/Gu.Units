#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Illuminance"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(IlluminanceUnitTypeConverter))]
    public struct IlluminanceUnit : IUnit, IUnit<Illuminance>, IEquatable<IlluminanceUnit>
    {
        /// <summary>
        /// The Lux unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly IlluminanceUnit Lux = new IlluminanceUnit(lux => lux, lux => lux, "lx");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.IlluminanceUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toLux;
        private readonly Func<double, double> fromLux;

        /// <summary>
        /// Initializes a new instance of the <see cref="IlluminanceUnit"/> struct.
        /// </summary>
        /// <param name="toLux">The conversion to <see cref="Lux"/></param>
        /// <param name="fromLux">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Lux"/></param>
        public IlluminanceUnit(Func<double, double> toLux, Func<double, double> fromLux, string symbol)
        {
            this.toLux = toLux;
            this.fromLux = fromLux;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.IlluminanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.IlluminanceUnit"/>
        /// </summary>
        public IlluminanceUnit SiUnit => Lux;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Lux;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Illuminance"/> that is the result from the multiplication.</returns>
        public static Illuminance operator *(double left, IlluminanceUnit right)
        {
            return Illuminance.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.IlluminanceUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
        public static bool operator ==(IlluminanceUnit left, IlluminanceUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.IlluminanceUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
        public static bool operator !=(IlluminanceUnit left, IlluminanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="IlluminanceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="IlluminanceUnit"/></returns>
        public static IlluminanceUnit Parse(string text)
        {
            return UnitParser<IlluminanceUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.IlluminanceUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.IlluminanceUnit"/></param>
        /// <param name="result">The parsed <see cref="IlluminanceUnit"/></param>
        /// <returns>True if an instance of <see cref="IlluminanceUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out IlluminanceUnit result)
        {
            return UnitParser<IlluminanceUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Lux.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toLux(value);
        }

        /// <summary>
        /// Converts a value from lux.
        /// </summary>
        /// <param name="lux">The value in Lux</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double lux)
        {
            return this.fromLux(lux);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Illuminance(<paramref name="value"/>, this)</returns>
        public Illuminance CreateQuantity(double value)
        {
            return new Illuminance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Lux
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Illuminance quantity)
        {
            return this.FromSiUnit(quantity.lux);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.symbol;
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="format">The format to use when converting</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string format)
        {
            IlluminanceUnit unit;
            var paddedFormat = UnitFormatCache<IlluminanceUnit>.GetOrCreate(format, out unit);
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
        public string ToString(SymbolFormat symbolFormat)
        {
            var paddedFormat = UnitFormatCache<IlluminanceUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.IlluminanceUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.IlluminanceUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same IlluminanceUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(IlluminanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is IlluminanceUnit other && this.Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            if (this.symbol is null)
            {
                return 0; // Needed due to default constructor
            }

            return this.symbol.GetHashCode();
        }
    }
}
