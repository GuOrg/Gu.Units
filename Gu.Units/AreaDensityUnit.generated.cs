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
        /// The AreaDensityUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AreaDensityUnit KilogramsPerSquareMetre = new AreaDensityUnit(kilogramsPerSquareMetre => kilogramsPerSquareMetre, kilogramsPerSquareMetre => kilogramsPerSquareMetre, "kg/m²");

        private readonly Func<double, double> toKilogramsPerSquareMetre;
        private readonly Func<double, double> fromKilogramsPerSquareMetre;
        internal readonly string symbol;

        public AreaDensityUnit(Func<double, double> toKilogramsPerSquareMetre, Func<double, double> fromKilogramsPerSquareMetre, string symbol)
        {
            this.toKilogramsPerSquareMetre = toKilogramsPerSquareMetre;
            this.fromKilogramsPerSquareMetre = fromKilogramsPerSquareMetre;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AreaDensityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AreaDensityUnit"/>
        /// </summary>
        public AreaDensityUnit SiUnit => KilogramsPerSquareMetre;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AreaDensityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => KilogramsPerSquareMetre;

        public static AreaDensity operator *(double left, AreaDensityUnit right)
        {
            return AreaDensity.From(left, right);
        }

        public static bool operator ==(AreaDensityUnit left, AreaDensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AreaDensityUnit left, AreaDensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AreaDensityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AreaDensityUnit"/></returns>
        public static AreaDensityUnit Parse(string text)
        {
            return UnitParser<AreaDensityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out AreaDensityUnit value)
        {
            return UnitParser<AreaDensityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerSquareMetre.
        /// </summary>
        /// <param name="value"></param>
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
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AreaDensity quantity)
        {
            return FromSiUnit(quantity.kilogramsPerSquareMetre);
        }

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<AreaDensityUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(AreaDensityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AreaDensityUnit && Equals((AreaDensityUnit)obj);
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