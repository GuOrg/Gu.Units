namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MagneticFieldStrength"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MagneticFieldStrengthUnitTypeConverter))]
    public struct MagneticFieldStrengthUnit : IUnit, IUnit<MagneticFieldStrength>, IEquatable<MagneticFieldStrengthUnit>
    {
        /// <summary>
        /// The Teslas unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MagneticFieldStrengthUnit Teslas = new MagneticFieldStrengthUnit(teslas => teslas, teslas => teslas, "T");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MagneticFieldStrengthUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toTeslas;
        private readonly Func<double, double> fromTeslas;

        /// <summary>
        /// Initializes a new instance of the <see cref="MagneticFieldStrengthUnit"/> struct.
        /// </summary>
        /// <param name="toTeslas">The conversion to <see cref="Teslas"/></param>
        /// <param name="fromTeslas">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Teslas"/></param>
        public MagneticFieldStrengthUnit(Func<double, double> toTeslas, Func<double, double> fromTeslas, string symbol)
        {
            this.toTeslas = toTeslas;
            this.fromTeslas = fromTeslas;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MagneticFieldStrengthUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.MagneticFieldStrengthUnit"/>
        /// </summary>
        public MagneticFieldStrengthUnit SiUnit => Teslas;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Teslas;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFieldStrength"/> that is the result from the multiplication.</returns>
        public static MagneticFieldStrength operator *(double left, MagneticFieldStrengthUnit right)
        {
            return MagneticFieldStrength.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFieldStrengthUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFieldStrengthUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFieldStrengthUnit"/>.</param>
        public static bool operator ==(MagneticFieldStrengthUnit left, MagneticFieldStrengthUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFieldStrengthUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFieldStrengthUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFieldStrengthUnit"/>.</param>
        public static bool operator !=(MagneticFieldStrengthUnit left, MagneticFieldStrengthUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MagneticFieldStrengthUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="MagneticFieldStrengthUnit"/></returns>
        public static MagneticFieldStrengthUnit Parse(string text)
        {
            return UnitParser<MagneticFieldStrengthUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFieldStrengthUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFieldStrengthUnit"/></param>
        /// <param name="result">The parsed <see cref="MagneticFieldStrengthUnit"/></param>
        /// <returns>True if an instance of <see cref="MagneticFieldStrengthUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MagneticFieldStrengthUnit result)
        {
            return UnitParser<MagneticFieldStrengthUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Teslas.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toTeslas(value);
        }

        /// <summary>
        /// Converts a value from teslas.
        /// </summary>
        /// <param name="teslas">The value in Teslas</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double teslas)
        {
            return this.fromTeslas(teslas);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new MagneticFieldStrength(<paramref name="value"/>, this)</returns>
        public MagneticFieldStrength CreateQuantity(double value)
        {
            return new MagneticFieldStrength(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Teslas
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(MagneticFieldStrength quantity)
        {
            return this.FromSiUnit(quantity.teslas);
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
            MagneticFieldStrengthUnit unit;
            var paddedFormat = UnitFormatCache<MagneticFieldStrengthUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MagneticFieldStrengthUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MagneticFieldStrengthUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.MagneticFieldStrengthUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MagneticFieldStrengthUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(MagneticFieldStrengthUnit other)
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

            return obj is MagneticFieldStrengthUnit && this.Equals((MagneticFieldStrengthUnit)obj);
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