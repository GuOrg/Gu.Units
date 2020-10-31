#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Momentum"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MomentumUnitTypeConverter))]
    public struct MomentumUnit : IUnit, IUnit<Momentum>, IEquatable<MomentumUnit>
    {
        /// <summary>
        /// The NewtonSecond unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MomentumUnit NewtonSecond = new MomentumUnit(newtonSecond => newtonSecond, newtonSecond => newtonSecond, "N⋅s");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MomentumUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toNewtonSecond;
        private readonly Func<double, double> fromNewtonSecond;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentumUnit"/> struct.
        /// </summary>
        /// <param name="toNewtonSecond">The conversion to <see cref="NewtonSecond"/></param>
        /// <param name="fromNewtonSecond">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="NewtonSecond"/></param>
        public MomentumUnit(Func<double, double> toNewtonSecond, Func<double, double> fromNewtonSecond, string symbol)
        {
            this.toNewtonSecond = toNewtonSecond;
            this.fromNewtonSecond = fromNewtonSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MomentumUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.MomentumUnit"/>
        /// </summary>
        public MomentumUnit SiUnit => NewtonSecond;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => NewtonSecond;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the multiplication.</returns>
        public static Momentum operator *(double left, MomentumUnit right)
        {
            return Momentum.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MomentumUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MomentumUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MomentumUnit"/>.</param>
        public static bool operator ==(MomentumUnit left, MomentumUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MomentumUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MomentumUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MomentumUnit"/>.</param>
        public static bool operator !=(MomentumUnit left, MomentumUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MomentumUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="MomentumUnit"/></returns>
        public static MomentumUnit Parse(string text)
        {
            return UnitParser<MomentumUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MomentumUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MomentumUnit"/></param>
        /// <param name="result">The parsed <see cref="MomentumUnit"/></param>
        /// <returns>True if an instance of <see cref="MomentumUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MomentumUnit result)
        {
            return UnitParser<MomentumUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to NewtonSecond.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toNewtonSecond(value);
        }

        /// <summary>
        /// Converts a value from newtonSecond.
        /// </summary>
        /// <param name="newtonSecond">The value in NewtonSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double newtonSecond)
        {
            return this.fromNewtonSecond(newtonSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Momentum(<paramref name="value"/>, this)</returns>
        public Momentum CreateQuantity(double value)
        {
            return new Momentum(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in NewtonSecond
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Momentum quantity)
        {
            return this.FromSiUnit(quantity.newtonSecond);
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
            MomentumUnit unit;
            var paddedFormat = UnitFormatCache<MomentumUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MomentumUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MomentumUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.MomentumUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MomentumUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(MomentumUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is MomentumUnit other && this.Equals(other);
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
