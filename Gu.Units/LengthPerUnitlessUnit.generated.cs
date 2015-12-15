namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.LengthPerUnitless"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(LengthPerUnitlessUnitTypeConverter))]
    public struct LengthPerUnitlessUnit : IUnit, IUnit<LengthPerUnitless>, IEquatable<LengthPerUnitlessUnit>
    {
        /// <summary>
        /// The LengthPerUnitlessUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MetresPerUnitless = new LengthPerUnitlessUnit(metresPerUnitless => metresPerUnitless, metresPerUnitless => metresPerUnitless, "m/ul");

        /// <summary>
        /// The MillimetresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MillimetresPerPercent = new LengthPerUnitlessUnit(millimetresPerPercent => millimetresPerPercent / 10, metresPerUnitless => 10 * metresPerUnitless, "mm/%");

        /// <summary>
        /// The MicrometresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MicrometresPerPercent = new LengthPerUnitlessUnit(micrometresPerPercent => micrometresPerPercent / 10000, metresPerUnitless => 10000 * metresPerUnitless, "µm/%");

        /// <summary>
        /// The MetresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MetresPerPercent = new LengthPerUnitlessUnit(metresPerPercent => 100 * metresPerPercent, metresPerUnitless => metresPerUnitless / 100, "m/%");

        private readonly Func<double, double> toMetresPerUnitless;
        private readonly Func<double, double> fromMetresPerUnitless;
        internal readonly string symbol;

        public LengthPerUnitlessUnit(Func<double, double> toMetresPerUnitless, Func<double, double> fromMetresPerUnitless, string symbol)
        {
            this.toMetresPerUnitless = toMetresPerUnitless;
            this.fromMetresPerUnitless = fromMetresPerUnitless;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.LengthPerUnitlessUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.LengthPerUnitlessUnit"/>
        /// </summary>
        public LengthPerUnitlessUnit SiUnit => MetresPerUnitless;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.LengthPerUnitlessUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MetresPerUnitless;

        public static LengthPerUnitless operator *(double left, LengthPerUnitlessUnit right)
        {
            return LengthPerUnitless.From(left, right);
        }

        public static bool operator ==(LengthPerUnitlessUnit left, LengthPerUnitlessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LengthPerUnitlessUnit left, LengthPerUnitlessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="LengthPerUnitlessUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="LengthPerUnitlessUnit"/></returns>
        public static LengthPerUnitlessUnit Parse(string text)
        {
            return UnitParser<LengthPerUnitlessUnit>.Parse(text);
        }

        public static bool TryParse(string text, out LengthPerUnitlessUnit value)
        {
            return UnitParser<LengthPerUnitlessUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerUnitless.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerUnitless(value);
        }

        /// <summary>
        /// Converts a value from metresPerUnitless.
        /// </summary>
        /// <param name="MetresPerUnitless">The value in MetresPerUnitless</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerUnitless)
        {
            return this.fromMetresPerUnitless(metresPerUnitless);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new LengthPerUnitless(<paramref name="value"/>, this)</returns>
        public LengthPerUnitless CreateQuantity(double value)
        {
            return new LengthPerUnitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerUnitless
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(LengthPerUnitless quantity)
        {
            return FromSiUnit(quantity.metresPerUnitless);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            LengthPerUnitlessUnit unit;
            var paddedFormat = UnitFormatCache<LengthPerUnitlessUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<LengthPerUnitlessUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(LengthPerUnitlessUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LengthPerUnitlessUnit && Equals((LengthPerUnitlessUnit)obj);
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