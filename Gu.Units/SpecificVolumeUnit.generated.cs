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
        /// The SpecificVolumeUnit unit
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

        private readonly Func<double, double> toCubicMetresPerKilogram;
        private readonly Func<double, double> fromCubicMetresPerKilogram;
        internal readonly string symbol;

        public SpecificVolumeUnit(Func<double, double> toCubicMetresPerKilogram, Func<double, double> fromCubicMetresPerKilogram, string symbol)
        {
            this.toCubicMetresPerKilogram = toCubicMetresPerKilogram;
            this.fromCubicMetresPerKilogram = fromCubicMetresPerKilogram;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SpecificVolumeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SpecificVolumeUnit"/>
        /// </summary>
        public SpecificVolumeUnit SiUnit => CubicMetresPerKilogram;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SpecificVolumeUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => CubicMetresPerKilogram;

        public static SpecificVolume operator *(double left, SpecificVolumeUnit right)
        {
            return SpecificVolume.From(left, right);
        }

        public static bool operator ==(SpecificVolumeUnit left, SpecificVolumeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SpecificVolumeUnit left, SpecificVolumeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="SpecificVolumeUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="SpecificVolumeUnit"/></returns>
        public static SpecificVolumeUnit Parse(string text)
        {
            return UnitParser<SpecificVolumeUnit>.Parse(text);
        }

        public static bool TryParse(string text, out SpecificVolumeUnit value)
        {
            return UnitParser<SpecificVolumeUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to CubicMetresPerKilogram.
        /// </summary>
        /// <param name="value"></param>
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
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(SpecificVolume quantity)
        {
            return FromSiUnit(quantity.cubicMetresPerKilogram);
        }

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<SpecificVolumeUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(SpecificVolumeUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SpecificVolumeUnit && Equals((SpecificVolumeUnit)obj);
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