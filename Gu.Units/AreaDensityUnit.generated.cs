namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AreaDensity"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AreaDensityUnitTypeConverter))]
    public struct AreaDensityUnit : IUnit, IUnit<AreaDensity>, IEquatable<AreaDensityUnit>
    {
        /// <summary>
        /// The KilogramsPerSquareMetre unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AreaDensityUnit KilogramsPerSquareMetre = new AreaDensityUnit(kilogramsPerSquareMetre => kilogramsPerSquareMetre, kilogramsPerSquareMetre => kilogramsPerSquareMetre, "kg/m²");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.AreaDensityUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toKilogramsPerSquareMetre;
        private readonly Func<double, double> fromKilogramsPerSquareMetre;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaDensityUnit"/> struct.
        /// </summary>
        /// <param name="toKilogramsPerSquareMetre">The conversion to <see cref="KilogramsPerSquareMetre"/></param>
        /// <param name="fromKilogramsPerSquareMetre">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="KilogramsPerSquareMetre"/></param>
        public AreaDensityUnit(Func<double, double> toKilogramsPerSquareMetre, Func<double, double> fromKilogramsPerSquareMetre, string symbol)
        {
            this.toKilogramsPerSquareMetre = toKilogramsPerSquareMetre;
            this.fromKilogramsPerSquareMetre = fromKilogramsPerSquareMetre;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.AreaDensityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.AreaDensityUnit"/>
        /// </summary>
        public AreaDensityUnit SiUnit => KilogramsPerSquareMetre;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => KilogramsPerSquareMetre;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the multiplication.</returns>
        public static AreaDensity operator *(double left, AreaDensityUnit right)
        {
            return AreaDensity.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AreaDensityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AreaDensityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AreaDensityUnit"/>.</param>
        public static bool operator ==(AreaDensityUnit left, AreaDensityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AreaDensityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AreaDensityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AreaDensityUnit"/>.</param>
        public static bool operator !=(AreaDensityUnit left, AreaDensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AreaDensityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="AreaDensityUnit"/></returns>
        public static AreaDensityUnit Parse(string text)
        {
            return UnitParser<AreaDensityUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensityUnit"/></param>
        /// <param name="result">The parsed <see cref="AreaDensityUnit"/></param>
        /// <returns>True if an instance of <see cref="AreaDensityUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out AreaDensityUnit result)
        {
            return UnitParser<AreaDensityUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerSquareMetre.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKilogramsPerSquareMetre(value);
        }

        /// <summary>
        /// Converts a value from kilogramsPerSquareMetre.
        /// </summary>
        /// <param name="kilogramsPerSquareMetre">The value in KilogramsPerSquareMetre</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kilogramsPerSquareMetre)
        {
            return this.fromKilogramsPerSquareMetre(kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new AreaDensity(<paramref name="value"/>, this)</returns>
        public AreaDensity CreateQuantity(double value)
        {
            return new AreaDensity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in KilogramsPerSquareMetre
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(AreaDensity quantity)
        {
            return this.FromSiUnit(quantity.kilogramsPerSquareMetre);
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
            AreaDensityUnit unit;
            var paddedFormat = UnitFormatCache<AreaDensityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AreaDensityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AreaDensityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AreaDensityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AreaDensityUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(AreaDensityUnit other)
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

            return obj is AreaDensityUnit && this.Equals((AreaDensityUnit)obj);
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