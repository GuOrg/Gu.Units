#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Current"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(CurrentUnitTypeConverter))]
    public struct CurrentUnit : IUnit, IUnit<Current>, IEquatable<CurrentUnit>
    {
        /// <summary>
        /// The Amperes unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly CurrentUnit Amperes = new CurrentUnit(amperes => amperes, amperes => amperes, "A");

        /// <summary>
        /// The Milliamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Milliamperes = new CurrentUnit(milliamperes => milliamperes / 1000, amperes => 1000 * amperes, "mA");

        /// <summary>
        /// The Kiloamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Kiloamperes = new CurrentUnit(kiloamperes => 1000 * kiloamperes, amperes => amperes / 1000, "kA");

        /// <summary>
        /// The Megaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Megaamperes = new CurrentUnit(megaamperes => 1000000 * megaamperes, amperes => amperes / 1000000, "MA");

        /// <summary>
        /// The Microamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Microamperes = new CurrentUnit(microamperes => microamperes / 1000000, amperes => 1000000 * amperes, "μA");

        /// <summary>
        /// The Nanoamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Nanoamperes = new CurrentUnit(nanoamperes => nanoamperes / 1000000000, amperes => 1000000000 * amperes, "nA");

        /// <summary>
        /// The Gigaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Gigaamperes = new CurrentUnit(gigaamperes => 1000000000 * gigaamperes, amperes => amperes / 1000000000, "GA");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.CurrentUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toAmperes;
        private readonly Func<double, double> fromAmperes;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUnit"/> struct.
        /// </summary>
        /// <param name="toAmperes">The conversion to <see cref="Amperes"/></param>
        /// <param name="fromAmperes">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Amperes"/></param>
        public CurrentUnit(Func<double, double> toAmperes, Func<double, double> fromAmperes, string symbol)
        {
            this.toAmperes = toAmperes;
            this.fromAmperes = fromAmperes;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.CurrentUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.CurrentUnit"/>
        /// </summary>
        public CurrentUnit SiUnit => Amperes;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Amperes;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Current"/> that is the result from the multiplication.</returns>
        public static Current operator *(double left, CurrentUnit right)
        {
            return Current.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CurrentUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
        public static bool operator ==(CurrentUnit left, CurrentUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CurrentUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
        public static bool operator !=(CurrentUnit left, CurrentUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="CurrentUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="CurrentUnit"/></returns>
        public static CurrentUnit Parse(string text)
        {
            return UnitParser<CurrentUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.CurrentUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.CurrentUnit"/></param>
        /// <param name="result">The parsed <see cref="CurrentUnit"/></param>
        /// <returns>True if an instance of <see cref="CurrentUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out CurrentUnit result)
        {
            return UnitParser<CurrentUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Amperes.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toAmperes(value);
        }

        /// <summary>
        /// Converts a value from amperes.
        /// </summary>
        /// <param name="amperes">The value in Amperes</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double amperes)
        {
            return this.fromAmperes(amperes);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Current(<paramref name="value"/>, this)</returns>
        public Current CreateQuantity(double value)
        {
            return new Current(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Amperes
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Current quantity)
        {
            return this.FromSiUnit(quantity.amperes);
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
            CurrentUnit unit;
            var paddedFormat = UnitFormatCache<CurrentUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<CurrentUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.CurrentUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.CurrentUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same CurrentUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(CurrentUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is CurrentUnit other && this.Equals(other);
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
