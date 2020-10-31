#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Jerk"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(JerkUnitTypeConverter))]
    public struct JerkUnit : IUnit, IUnit<Jerk>, IEquatable<JerkUnit>
    {
        /// <summary>
        /// The MetresPerSecondCubed unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly JerkUnit MetresPerSecondCubed = new JerkUnit(metresPerSecondCubed => metresPerSecondCubed, metresPerSecondCubed => metresPerSecondCubed, "m/s³");

        /// <summary>
        /// The MillimetresPerSecondCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MillimetresPerSecondCubed = new JerkUnit(millimetresPerSecondCubed => millimetresPerSecondCubed / 1000, metresPerSecondCubed => 1000 * metresPerSecondCubed, "mm⋅s⁻³");

        /// <summary>
        /// The CentimetresPerSecondCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit CentimetresPerSecondCubed = new JerkUnit(centimetresPerSecondCubed => centimetresPerSecondCubed / 100, metresPerSecondCubed => 100 * metresPerSecondCubed, "cm⋅s⁻³");

        /// <summary>
        /// The MillimetresPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MillimetresPerHourCubed = new JerkUnit(millimetresPerHourCubed => millimetresPerHourCubed / 46656000000000, metresPerSecondCubed => 46656000000000 * metresPerSecondCubed, "mm⋅h⁻³");

        /// <summary>
        /// The MillimetresPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MillimetresPerMinuteCubed = new JerkUnit(millimetresPerMinuteCubed => millimetresPerMinuteCubed / 216000000, metresPerSecondCubed => 216000000 * metresPerSecondCubed, "mm⋅min⁻³");

        /// <summary>
        /// The MetresPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MetresPerHourCubed = new JerkUnit(metresPerHourCubed => metresPerHourCubed / 46656000000, metresPerSecondCubed => 46656000000 * metresPerSecondCubed, "m⋅h⁻³");

        /// <summary>
        /// The MetresPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MetresPerMinuteCubed = new JerkUnit(metresPerMinuteCubed => metresPerMinuteCubed / 216000, metresPerSecondCubed => 216000 * metresPerSecondCubed, "m⋅min⁻³");

        /// <summary>
        /// The CentimetresPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit CentimetresPerHourCubed = new JerkUnit(centimetresPerHourCubed => centimetresPerHourCubed / 4665600000000, metresPerSecondCubed => 4665600000000 * metresPerSecondCubed, "cm⋅h⁻³");

        /// <summary>
        /// The CentimetresPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit CentimetresPerMinuteCubed = new JerkUnit(centimetresPerMinuteCubed => centimetresPerMinuteCubed / 21600000, metresPerSecondCubed => 21600000 * metresPerSecondCubed, "cm⋅min⁻³");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.JerkUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toMetresPerSecondCubed;
        private readonly Func<double, double> fromMetresPerSecondCubed;

        /// <summary>
        /// Initializes a new instance of the <see cref="JerkUnit"/> struct.
        /// </summary>
        /// <param name="toMetresPerSecondCubed">The conversion to <see cref="MetresPerSecondCubed"/></param>
        /// <param name="fromMetresPerSecondCubed">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="MetresPerSecondCubed"/></param>
        public JerkUnit(Func<double, double> toMetresPerSecondCubed, Func<double, double> fromMetresPerSecondCubed, string symbol)
        {
            this.toMetresPerSecondCubed = toMetresPerSecondCubed;
            this.fromMetresPerSecondCubed = fromMetresPerSecondCubed;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.JerkUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.JerkUnit"/>
        /// </summary>
        public JerkUnit SiUnit => MetresPerSecondCubed;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => MetresPerSecondCubed;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Jerk"/> that is the result from the multiplication.</returns>
        public static Jerk operator *(double left, JerkUnit right)
        {
            return Jerk.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.JerkUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.JerkUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.JerkUnit"/>.</param>
        public static bool operator ==(JerkUnit left, JerkUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.JerkUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.JerkUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.JerkUnit"/>.</param>
        public static bool operator !=(JerkUnit left, JerkUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="JerkUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="JerkUnit"/></returns>
        public static JerkUnit Parse(string text)
        {
            return UnitParser<JerkUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.JerkUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.JerkUnit"/></param>
        /// <param name="result">The parsed <see cref="JerkUnit"/></param>
        /// <returns>True if an instance of <see cref="JerkUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out JerkUnit result)
        {
            return UnitParser<JerkUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerSecondCubed.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerSecondCubed(value);
        }

        /// <summary>
        /// Converts a value from metresPerSecondCubed.
        /// </summary>
        /// <param name="metresPerSecondCubed">The value in MetresPerSecondCubed</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerSecondCubed)
        {
            return this.fromMetresPerSecondCubed(metresPerSecondCubed);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Jerk(<paramref name="value"/>, this)</returns>
        public Jerk CreateQuantity(double value)
        {
            return new Jerk(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerSecondCubed
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Jerk quantity)
        {
            return this.FromSiUnit(quantity.metresPerSecondCubed);
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
            JerkUnit unit;
            var paddedFormat = UnitFormatCache<JerkUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<JerkUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.JerkUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.JerkUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same JerkUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(JerkUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is JerkUnit other && this.Equals(other);
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
