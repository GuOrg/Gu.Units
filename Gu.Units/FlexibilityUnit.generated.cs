#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Flexibility"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(FlexibilityUnitTypeConverter))]
    public struct FlexibilityUnit : IUnit, IUnit<Flexibility>, IEquatable<FlexibilityUnit>
    {
        /// <summary>
        /// The MetresPerNewton unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MetresPerNewton = new FlexibilityUnit(metresPerNewton => metresPerNewton, metresPerNewton => metresPerNewton, "m/N");

        /// <summary>
        /// The MillimetresPerNewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerNewton = new FlexibilityUnit(millimetresPerNewton => millimetresPerNewton / 1000, metresPerNewton => 1000 * metresPerNewton, "mm/N");

        /// <summary>
        /// The MillimetresPerKilonewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerKilonewton = new FlexibilityUnit(millimetresPerKilonewton => millimetresPerKilonewton / 1000000, metresPerNewton => 1000000 * metresPerNewton, "mm/kN");

        /// <summary>
        /// The MicrometresPerKilonewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MicrometresPerKilonewton = new FlexibilityUnit(micrometresPerKilonewton => micrometresPerKilonewton / 1000000000, metresPerNewton => 1000000000 * metresPerNewton, "μm/kN");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.FlexibilityUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toMetresPerNewton;
        private readonly Func<double, double> fromMetresPerNewton;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexibilityUnit"/> struct.
        /// </summary>
        /// <param name="toMetresPerNewton">The conversion to <see cref="MetresPerNewton"/></param>
        /// <param name="fromMetresPerNewton">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="MetresPerNewton"/></param>
        public FlexibilityUnit(Func<double, double> toMetresPerNewton, Func<double, double> fromMetresPerNewton, string symbol)
        {
            this.toMetresPerNewton = toMetresPerNewton;
            this.fromMetresPerNewton = fromMetresPerNewton;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.FlexibilityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.FlexibilityUnit"/>
        /// </summary>
        public FlexibilityUnit SiUnit => MetresPerNewton;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => MetresPerNewton;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Flexibility"/> that is the result from the multiplication.</returns>
        public static Flexibility operator *(double left, FlexibilityUnit right)
        {
            return Flexibility.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.FlexibilityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.FlexibilityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.FlexibilityUnit"/>.</param>
        public static bool operator ==(FlexibilityUnit left, FlexibilityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.FlexibilityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.FlexibilityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.FlexibilityUnit"/>.</param>
        public static bool operator !=(FlexibilityUnit left, FlexibilityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="FlexibilityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="FlexibilityUnit"/></returns>
        public static FlexibilityUnit Parse(string text)
        {
            return UnitParser<FlexibilityUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.FlexibilityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.FlexibilityUnit"/></param>
        /// <param name="result">The parsed <see cref="FlexibilityUnit"/></param>
        /// <returns>True if an instance of <see cref="FlexibilityUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out FlexibilityUnit result)
        {
            return UnitParser<FlexibilityUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerNewton.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerNewton(value);
        }

        /// <summary>
        /// Converts a value from metresPerNewton.
        /// </summary>
        /// <param name="metresPerNewton">The value in MetresPerNewton</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerNewton)
        {
            return this.fromMetresPerNewton(metresPerNewton);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Flexibility(<paramref name="value"/>, this)</returns>
        public Flexibility CreateQuantity(double value)
        {
            return new Flexibility(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerNewton
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Flexibility quantity)
        {
            return this.FromSiUnit(quantity.metresPerNewton);
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
            FlexibilityUnit unit;
            var paddedFormat = UnitFormatCache<FlexibilityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<FlexibilityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.FlexibilityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.FlexibilityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same FlexibilityUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(FlexibilityUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is FlexibilityUnit other && this.Equals(other);
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
