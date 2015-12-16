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
        /// The DensityUnit unit
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

        private readonly Func<double, double> toKilogramsPerCubicMetre;
        private readonly Func<double, double> fromKilogramsPerCubicMetre;
        internal readonly string symbol;

        public DensityUnit(Func<double, double> toKilogramsPerCubicMetre, Func<double, double> fromKilogramsPerCubicMetre, string symbol)
        {
            this.toKilogramsPerCubicMetre = toKilogramsPerCubicMetre;
            this.fromKilogramsPerCubicMetre = fromKilogramsPerCubicMetre;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.DensityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.DensityUnit"/>
        /// </summary>
        public DensityUnit SiUnit => KilogramsPerCubicMetre;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.DensityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => KilogramsPerCubicMetre;

        public static Density operator *(double left, DensityUnit right)
        {
            return Density.From(left, right);
        }

        public static bool operator ==(DensityUnit left, DensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DensityUnit left, DensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="DensityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="DensityUnit"/></returns>
        public static DensityUnit Parse(string text)
        {
            return UnitParser<DensityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out DensityUnit value)
        {
            return UnitParser<DensityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerCubicMetre.
        /// </summary>
        /// <param name="value"></param>
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
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Density quantity)
        {
            return FromSiUnit(quantity.kilogramsPerCubicMetre);
        }

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<DensityUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(DensityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is DensityUnit && Equals((DensityUnit)obj);
        }

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
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