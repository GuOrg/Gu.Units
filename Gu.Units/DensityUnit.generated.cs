namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Density"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(DensityUnitTypeConverter))]
    public struct DensityUnit : IUnit, IUnit<Density>, IEquatable<DensityUnit>
    {
        /// <summary>
        /// The KilogramsPerCubicMetre unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly DensityUnit KilogramsPerCubicMetre = new DensityUnit(kilogramsPerCubicMetre => kilogramsPerCubicMetre, kilogramsPerCubicMetre => kilogramsPerCubicMetre, "kg/m³");

        /// <summary>
        /// The GramsPerCubicMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit GramsPerCubicMillimetre = new DensityUnit(gramsPerCubicMillimetre => 1000000 * gramsPerCubicMillimetre, kilogramsPerCubicMetre => kilogramsPerCubicMetre / 1000000, "g/mm³");

        /// <summary>
        /// The GramsPerCubicCentimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit GramsPerCubicCentimetre = new DensityUnit(gramsPerCubicCentimetre => 1000 * gramsPerCubicCentimetre, kilogramsPerCubicMetre => kilogramsPerCubicMetre / 1000, "g/cm³");

        /// <summary>
        /// The MilligramsPerCubicMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit MilligramsPerCubicMillimetre = new DensityUnit(milligramsPerCubicMillimetre => 1000 * milligramsPerCubicMillimetre, kilogramsPerCubicMetre => kilogramsPerCubicMetre / 1000, "mg/mm³");

        /// <summary>
        /// The GramsPerCubicMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit GramsPerCubicMetre = new DensityUnit(gramsPerCubicMetre => gramsPerCubicMetre / 1000, kilogramsPerCubicMetre => 1000 * kilogramsPerCubicMetre, "g/m³");

        /// <summary>
        /// The MilligramsPerCubicMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit MilligramsPerCubicMetre = new DensityUnit(milligramsPerCubicMetre => milligramsPerCubicMetre / 1000000, kilogramsPerCubicMetre => 1000000 * kilogramsPerCubicMetre, "mg/m³");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.DensityUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toKilogramsPerCubicMetre;
        private readonly Func<double, double> fromKilogramsPerCubicMetre;

        /// <summary>
        /// Initializes a new instance of the <see cref="DensityUnit"/> struct.
        /// </summary>
        /// <param name="toKilogramsPerCubicMetre">The conversion to <see cref="KilogramsPerCubicMetre"/></param>
        /// <param name="fromKilogramsPerCubicMetre">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="KilogramsPerCubicMetre"/></param>
        public DensityUnit(Func<double, double> toKilogramsPerCubicMetre, Func<double, double> fromKilogramsPerCubicMetre, string symbol)
        {
            this.toKilogramsPerCubicMetre = toKilogramsPerCubicMetre;
            this.fromKilogramsPerCubicMetre = fromKilogramsPerCubicMetre;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.DensityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.DensityUnit"/>
        /// </summary>
        public DensityUnit SiUnit => KilogramsPerCubicMetre;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => KilogramsPerCubicMetre;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Density"/> that is the result from the multiplication.</returns>
        public static Density operator *(double left, DensityUnit right)
        {
            return Density.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.DensityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.DensityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.DensityUnit"/>.</param>
        public static bool operator ==(DensityUnit left, DensityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.DensityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.DensityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.DensityUnit"/>.</param>
        public static bool operator !=(DensityUnit left, DensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="DensityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="DensityUnit"/></returns>
        public static DensityUnit Parse(string text)
        {
            return UnitParser<DensityUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.DensityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.DensityUnit"/></param>
        /// <param name="result">The parsed <see cref="DensityUnit"/></param>
        /// <returns>True if an instance of <see cref="DensityUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out DensityUnit result)
        {
            return UnitParser<DensityUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerCubicMetre.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKilogramsPerCubicMetre(value);
        }

        /// <summary>
        /// Converts a value from kilogramsPerCubicMetre.
        /// </summary>
        /// <param name="kilogramsPerCubicMetre">The value in KilogramsPerCubicMetre</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kilogramsPerCubicMetre)
        {
            return this.fromKilogramsPerCubicMetre(kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Density(<paramref name="value"/>, this)</returns>
        public Density CreateQuantity(double value)
        {
            return new Density(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in KilogramsPerCubicMetre
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Density quantity)
        {
            return this.FromSiUnit(quantity.kilogramsPerCubicMetre);
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
            DensityUnit unit;
            var paddedFormat = UnitFormatCache<DensityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<DensityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.DensityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.DensityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same DensityUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(DensityUnit other)
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

            return obj is DensityUnit && this.Equals((DensityUnit)obj);
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
