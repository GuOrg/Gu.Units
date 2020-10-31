#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Power"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(PowerUnitTypeConverter))]
    public struct PowerUnit : IUnit, IUnit<Power>, IEquatable<PowerUnit>
    {
        /// <summary>
        /// The Watts unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly PowerUnit Watts = new PowerUnit(watts => watts, watts => watts, "W");

        /// <summary>
        /// The Nanowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Nanowatts = new PowerUnit(nanowatts => nanowatts / 1000000000, watts => 1000000000 * watts, "nW");

        /// <summary>
        /// The Microwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Microwatts = new PowerUnit(microwatts => microwatts / 1000000, watts => 1000000 * watts, "μW");

        /// <summary>
        /// The Milliwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Milliwatts = new PowerUnit(milliwatts => milliwatts / 1000, watts => 1000 * watts, "mW");

        /// <summary>
        /// The Kilowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Kilowatts = new PowerUnit(kilowatts => 1000 * kilowatts, watts => watts / 1000, "kW");

        /// <summary>
        /// The Megawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Megawatts = new PowerUnit(megawatts => 1000000 * megawatts, watts => watts / 1000000, "MW");

        /// <summary>
        /// The Gigawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Gigawatts = new PowerUnit(gigawatts => 1000000000 * gigawatts, watts => watts / 1000000000, "GW");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.PowerUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toWatts;
        private readonly Func<double, double> fromWatts;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerUnit"/> struct.
        /// </summary>
        /// <param name="toWatts">The conversion to <see cref="Watts"/></param>
        /// <param name="fromWatts">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Watts"/></param>
        public PowerUnit(Func<double, double> toWatts, Func<double, double> fromWatts, string symbol)
        {
            this.toWatts = toWatts;
            this.fromWatts = fromWatts;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.PowerUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.PowerUnit"/>
        /// </summary>
        public PowerUnit SiUnit => Watts;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Watts;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(double left, PowerUnit right)
        {
            return Power.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.PowerUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.PowerUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.PowerUnit"/>.</param>
        public static bool operator ==(PowerUnit left, PowerUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.PowerUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.PowerUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.PowerUnit"/>.</param>
        public static bool operator !=(PowerUnit left, PowerUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="PowerUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="PowerUnit"/></returns>
        public static PowerUnit Parse(string text)
        {
            return UnitParser<PowerUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.PowerUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.PowerUnit"/></param>
        /// <param name="result">The parsed <see cref="PowerUnit"/></param>
        /// <returns>True if an instance of <see cref="PowerUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out PowerUnit result)
        {
            return UnitParser<PowerUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Watts.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toWatts(value);
        }

        /// <summary>
        /// Converts a value from watts.
        /// </summary>
        /// <param name="watts">The value in Watts</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double watts)
        {
            return this.fromWatts(watts);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Power(<paramref name="value"/>, this)</returns>
        public Power CreateQuantity(double value)
        {
            return new Power(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Watts
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Power quantity)
        {
            return this.FromSiUnit(quantity.watts);
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
            PowerUnit unit;
            var paddedFormat = UnitFormatCache<PowerUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<PowerUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.PowerUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.PowerUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same PowerUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(PowerUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is PowerUnit other && this.Equals(other);
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
