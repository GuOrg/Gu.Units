namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AngularSpeed"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AngularSpeedUnitTypeConverter))]
    public struct AngularSpeedUnit : IUnit, IUnit<AngularSpeed>, IEquatable<AngularSpeedUnit>
    {
        /// <summary>
        /// The RadiansPerSecond unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit RadiansPerSecond = new AngularSpeedUnit(radiansPerSecond => radiansPerSecond, radiansPerSecond => radiansPerSecond, "rad/s");

        /// <summary>
        /// The RevolutionsPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit RevolutionsPerMinute = new AngularSpeedUnit(revolutionsPerMinute => 0.10471975511966 * revolutionsPerMinute, radiansPerSecond => radiansPerSecond / 0.10471975511966, "rpm");

        /// <summary>
        /// The DegreesPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit DegreesPerSecond = new AngularSpeedUnit(degreesPerSecond => 0.0174532925199433 * degreesPerSecond, radiansPerSecond => radiansPerSecond / 0.0174532925199433, "\u00B0⋅s⁻¹");

        /// <summary>
        /// The DegreesPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit DegreesPerMinute = new AngularSpeedUnit(degreesPerMinute => 0.000290888208665722 * degreesPerMinute, radiansPerSecond => radiansPerSecond / 0.000290888208665722, "min⁻¹⋅\u00B0");

        /// <summary>
        /// The RadiansPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit RadiansPerMinute = new AngularSpeedUnit(radiansPerMinute => radiansPerMinute / 60, radiansPerSecond => 60 * radiansPerSecond, "min⁻¹⋅rad");

        /// <summary>
        /// The DegreesPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit DegreesPerHour = new AngularSpeedUnit(degreesPerHour => 4.84813681109536E-06 * degreesPerHour, radiansPerSecond => radiansPerSecond / 4.84813681109536E-06, "h⁻¹⋅\u00B0");

        /// <summary>
        /// The RadiansPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit RadiansPerHour = new AngularSpeedUnit(radiansPerHour => radiansPerHour / 3600, radiansPerSecond => 3600 * radiansPerSecond, "h⁻¹⋅rad");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.AngularSpeedUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toRadiansPerSecond;
        private readonly Func<double, double> fromRadiansPerSecond;

        /// <summary>
        /// Initializes a new instance of the <see cref="AngularSpeedUnit"/> struct.
        /// </summary>
        /// <param name="toRadiansPerSecond">The conversion to <see cref="RadiansPerSecond"/></param>
        /// <param name="fromRadiansPerSecond">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="RadiansPerSecond"/></param>
        public AngularSpeedUnit(Func<double, double> toRadiansPerSecond, Func<double, double> fromRadiansPerSecond, string symbol)
        {
            this.toRadiansPerSecond = toRadiansPerSecond;
            this.fromRadiansPerSecond = fromRadiansPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.AngularSpeedUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.AngularSpeedUnit"/>
        /// </summary>
        public AngularSpeedUnit SiUnit => RadiansPerSecond;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => RadiansPerSecond;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the multiplication.</returns>
        public static AngularSpeed operator *(double left, AngularSpeedUnit right)
        {
            return AngularSpeed.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularSpeedUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularSpeedUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularSpeedUnit"/>.</param>
        public static bool operator ==(AngularSpeedUnit left, AngularSpeedUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularSpeedUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularSpeedUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularSpeedUnit"/>.</param>
        public static bool operator !=(AngularSpeedUnit left, AngularSpeedUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AngularSpeedUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="AngularSpeedUnit"/></returns>
        public static AngularSpeedUnit Parse(string text)
        {
            return UnitParser<AngularSpeedUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularSpeedUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularSpeedUnit"/></param>
        /// <param name="result">The parsed <see cref="AngularSpeedUnit"/></param>
        /// <returns>True if an instance of <see cref="AngularSpeedUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out AngularSpeedUnit result)
        {
            return UnitParser<AngularSpeedUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to RadiansPerSecond.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toRadiansPerSecond(value);
        }

        /// <summary>
        /// Converts a value from radiansPerSecond.
        /// </summary>
        /// <param name="radiansPerSecond">The value in RadiansPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double radiansPerSecond)
        {
            return this.fromRadiansPerSecond(radiansPerSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new AngularSpeed(<paramref name="value"/>, this)</returns>
        public AngularSpeed CreateQuantity(double value)
        {
            return new AngularSpeed(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in RadiansPerSecond
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(AngularSpeed quantity)
        {
            return this.FromSiUnit(quantity.radiansPerSecond);
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
            AngularSpeedUnit unit;
            var paddedFormat = UnitFormatCache<AngularSpeedUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AngularSpeedUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularSpeedUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularSpeedUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularSpeedUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(AngularSpeedUnit other)
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

            return obj is AngularSpeedUnit && this.Equals((AngularSpeedUnit)obj);
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