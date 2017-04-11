namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.SpecificVolume"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SpecificVolumeUnitTypeConverter))]
    public struct SpecificVolumeUnit : IUnit, IUnit<SpecificVolume>, IEquatable<SpecificVolumeUnit>
    {
        /// <summary>
        /// The CubicMetresPerKilogram unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly SpecificVolumeUnit CubicMetresPerKilogram = new SpecificVolumeUnit(cubicMetresPerKilogram => cubicMetresPerKilogram, cubicMetresPerKilogram => cubicMetresPerKilogram, "m³/kg");

        /// <summary>
        /// The CubicMetresPerGram unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpecificVolumeUnit CubicMetresPerGram = new SpecificVolumeUnit(cubicMetresPerGram => 1000 * cubicMetresPerGram, cubicMetresPerKilogram => cubicMetresPerKilogram / 1000, "m³/g");

        /// <summary>
        /// The CubicCentimetresPerGram unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpecificVolumeUnit CubicCentimetresPerGram = new SpecificVolumeUnit(cubicCentimetresPerGram => cubicCentimetresPerGram / 1000, cubicMetresPerKilogram => 1000 * cubicMetresPerKilogram, "cm³/g");

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.SpecificVolumeUnit"/>.
        /// </summary>
        internal readonly string symbol;

        private readonly Func<double, double> toCubicMetresPerKilogram;
        private readonly Func<double, double> fromCubicMetresPerKilogram;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificVolumeUnit"/> struct.
        /// </summary>
        /// <param name="toCubicMetresPerKilogram">The conversion to <see cref="CubicMetresPerKilogram"/></param>
        /// <param name="fromCubicMetresPerKilogram">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="CubicMetresPerKilogram"/></param>
        public SpecificVolumeUnit(Func<double, double> toCubicMetresPerKilogram, Func<double, double> fromCubicMetresPerKilogram, string symbol)
        {
            this.toCubicMetresPerKilogram = toCubicMetresPerKilogram;
            this.fromCubicMetresPerKilogram = fromCubicMetresPerKilogram;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.SpecificVolumeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.SpecificVolumeUnit"/>
        /// </summary>
        public SpecificVolumeUnit SiUnit => CubicMetresPerKilogram;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => CubicMetresPerKilogram;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificVolume"/> that is the result from the multiplication.</returns>
        public static SpecificVolume operator *(double left, SpecificVolumeUnit right)
        {
            return SpecificVolume.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificVolumeUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolumeUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolumeUnit"/>.</param>
        public static bool operator ==(SpecificVolumeUnit left, SpecificVolumeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificVolumeUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolumeUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolumeUnit"/>.</param>
        public static bool operator !=(SpecificVolumeUnit left, SpecificVolumeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="SpecificVolumeUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="SpecificVolumeUnit"/></returns>
        public static SpecificVolumeUnit Parse(string text)
        {
            return UnitParser<SpecificVolumeUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolumeUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolumeUnit"/></param>
        /// <param name="result">The parsed <see cref="SpecificVolumeUnit"/></param>
        /// <returns>True if an instance of <see cref="SpecificVolumeUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out SpecificVolumeUnit result)
        {
            return UnitParser<SpecificVolumeUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to CubicMetresPerKilogram.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toCubicMetresPerKilogram(value);
        }

        /// <summary>
        /// Converts a value from cubicMetresPerKilogram.
        /// </summary>
        /// <param name="cubicMetresPerKilogram">The value in CubicMetresPerKilogram</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double cubicMetresPerKilogram)
        {
            return this.fromCubicMetresPerKilogram(cubicMetresPerKilogram);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new SpecificVolume(<paramref name="value"/>, this)</returns>
        public SpecificVolume CreateQuantity(double value)
        {
            return new SpecificVolume(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in CubicMetresPerKilogram
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(SpecificVolume quantity)
        {
            return this.FromSiUnit(quantity.cubicMetresPerKilogram);
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
            SpecificVolumeUnit unit;
            var paddedFormat = UnitFormatCache<SpecificVolumeUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<SpecificVolumeUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificVolumeUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificVolumeUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificVolumeUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(SpecificVolumeUnit other)
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

            return obj is SpecificVolumeUnit && this.Equals((SpecificVolumeUnit)obj);
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