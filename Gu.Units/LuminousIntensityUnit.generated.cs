namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.LuminousIntensity"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(LuminousIntensityUnitTypeConverter))]
    public struct LuminousIntensityUnit : IUnit, IUnit<LuminousIntensity>, IEquatable<LuminousIntensityUnit>
    {
        /// <summary>
        /// The LuminousIntensityUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly LuminousIntensityUnit Candelas = new LuminousIntensityUnit(candelas => candelas, candelas => candelas, "cd");

        private readonly Func<double, double> toCandelas;
        private readonly Func<double, double> fromCandelas;
        internal readonly string symbol;

        public LuminousIntensityUnit(Func<double, double> toCandelas, Func<double, double> fromCandelas, string symbol)
        {
            this.toCandelas = toCandelas;
            this.fromCandelas = fromCandelas;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.LuminousIntensityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.LuminousIntensityUnit"/>
        /// </summary>
        public LuminousIntensityUnit SiUnit => Candelas;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.LuminousIntensityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Candelas;

        public static LuminousIntensity operator *(double left, LuminousIntensityUnit right)
        {
            return LuminousIntensity.From(left, right);
        }

        public static bool operator ==(LuminousIntensityUnit left, LuminousIntensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LuminousIntensityUnit left, LuminousIntensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="LuminousIntensityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="LuminousIntensityUnit"/></returns>
        public static LuminousIntensityUnit Parse(string text)
        {
            return UnitParser<LuminousIntensityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out LuminousIntensityUnit value)
        {
            return UnitParser<LuminousIntensityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Candelas.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toCandelas(value);
        }

        /// <summary>
        /// Converts a value from candelas.
        /// </summary>
        /// <param name="Candelas">The value in Candelas</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double candelas)
        {
            return this.fromCandelas(candelas);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new LuminousIntensity(<paramref name="value"/>, this)</returns>
        public LuminousIntensity CreateQuantity(double value)
        {
            return new LuminousIntensity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Candelas
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(LuminousIntensity quantity)
        {
            return FromSiUnit(quantity.candelas);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            LuminousIntensityUnit unit;
            var paddedFormat = UnitFormatCache<LuminousIntensityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<LuminousIntensityUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(LuminousIntensityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LuminousIntensityUnit && Equals((LuminousIntensityUnit)obj);
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