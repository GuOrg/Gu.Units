namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.LengthPerUnitless"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(LengthPerUnitlessUnitTypeConverter))]
    public struct LengthPerUnitlessUnit : IUnit, IUnit<LengthPerUnitless>, IEquatable<LengthPerUnitlessUnit>
    {
        /// <summary>
        /// The MetresPerUnitless unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MetresPerUnitless = new LengthPerUnitlessUnit(metresPerUnitless => metresPerUnitless, metresPerUnitless => metresPerUnitless, "m/ul");

        /// <summary>
        /// The MillimetresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MillimetresPerPercent = new LengthPerUnitlessUnit(millimetresPerPercent => millimetresPerPercent / 10, metresPerUnitless => 10 * metresPerUnitless, "mm/%");

        /// <summary>
        /// The MicrometresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MicrometresPerPercent = new LengthPerUnitlessUnit(micrometresPerPercent => micrometresPerPercent / 10000, metresPerUnitless => 10000 * metresPerUnitless, "\u00B5m/%");

        /// <summary>
        /// The MetresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MetresPerPercent = new LengthPerUnitlessUnit(metresPerPercent => 100 * metresPerPercent, metresPerUnitless => metresPerUnitless / 100, "m/%");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.LengthPerUnitlessUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toMetresPerUnitless;
        private readonly Func<double, double> fromMetresPerUnitless;

        /// <summary>
        /// Initializes a new instance of the <see cref="LengthPerUnitlessUnit"/> struct.
        /// </summary>
        /// <param name="toMetresPerUnitless">The conversion to <see cref="MetresPerUnitless"/></param>
        /// <param name="fromMetresPerUnitless">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="MetresPerUnitless"/></param>
        public LengthPerUnitlessUnit(Func<double, double> toMetresPerUnitless, Func<double, double> fromMetresPerUnitless, string symbol)
        {
            this.toMetresPerUnitless = toMetresPerUnitless;
            this.fromMetresPerUnitless = fromMetresPerUnitless;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.LengthPerUnitlessUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.LengthPerUnitlessUnit"/>
        /// </summary>
        public LengthPerUnitlessUnit SiUnit => MetresPerUnitless;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => MetresPerUnitless;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LengthPerUnitless"/> that is the result from the multiplication.</returns>
        public static LengthPerUnitless operator *(double left, LengthPerUnitlessUnit right)
        {
            return LengthPerUnitless.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthPerUnitlessUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitlessUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitlessUnit"/>.</param>
        public static bool operator ==(LengthPerUnitlessUnit left, LengthPerUnitlessUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthPerUnitlessUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitlessUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitlessUnit"/>.</param>
        public static bool operator !=(LengthPerUnitlessUnit left, LengthPerUnitlessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="LengthPerUnitlessUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="LengthPerUnitlessUnit"/></returns>
        public static LengthPerUnitlessUnit Parse(string text)
        {
            return UnitParser<LengthPerUnitlessUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitlessUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitlessUnit"/></param>
        /// <param name="result">The parsed <see cref="LengthPerUnitlessUnit"/></param>
        /// <returns>True if an instance of <see cref="LengthPerUnitlessUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out LengthPerUnitlessUnit result)
        {
            return UnitParser<LengthPerUnitlessUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerUnitless.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerUnitless(value);
        }

        /// <summary>
        /// Converts a value from metresPerUnitless.
        /// </summary>
        /// <param name="metresPerUnitless">The value in MetresPerUnitless</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerUnitless)
        {
            return this.fromMetresPerUnitless(metresPerUnitless);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new LengthPerUnitless(<paramref name="value"/>, this)</returns>
        public LengthPerUnitless CreateQuantity(double value)
        {
            return new LengthPerUnitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerUnitless
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(LengthPerUnitless quantity)
        {
            return this.FromSiUnit(quantity.metresPerUnitless);
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
            LengthPerUnitlessUnit unit;
            var paddedFormat = UnitFormatCache<LengthPerUnitlessUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<LengthPerUnitlessUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LengthPerUnitlessUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.LengthPerUnitlessUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LengthPerUnitlessUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(LengthPerUnitlessUnit other)
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

            return obj is LengthPerUnitlessUnit && this.Equals((LengthPerUnitlessUnit)obj);
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