namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.CatalyticActivity"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(CatalyticActivityUnitTypeConverter))]
    public struct CatalyticActivityUnit : IUnit, IUnit<CatalyticActivity>, IEquatable<CatalyticActivityUnit>
    {
        /// <summary>
        /// The CatalyticActivityUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly CatalyticActivityUnit Katals = new CatalyticActivityUnit(katals => katals, katals => katals, "kat");

        private readonly Func<double, double> toKatals;
        private readonly Func<double, double> fromKatals;
        internal readonly string symbol;

        public CatalyticActivityUnit(Func<double, double> toKatals, Func<double, double> fromKatals, string symbol)
        {
            this.toKatals = toKatals;
            this.fromKatals = fromKatals;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.CatalyticActivityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.CatalyticActivityUnit"/>
        /// </summary>
        public CatalyticActivityUnit SiUnit => Katals;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.CatalyticActivityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Katals;

        public static CatalyticActivity operator *(double left, CatalyticActivityUnit right)
        {
            return CatalyticActivity.From(left, right);
        }

        public static bool operator ==(CatalyticActivityUnit left, CatalyticActivityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CatalyticActivityUnit left, CatalyticActivityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="CatalyticActivityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="CatalyticActivityUnit"/></returns>
        public static CatalyticActivityUnit Parse(string text)
        {
            return UnitParser<CatalyticActivityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out CatalyticActivityUnit value)
        {
            return UnitParser<CatalyticActivityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Katals.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKatals(value);
        }

        /// <summary>
        /// Converts a value from katals.
        /// </summary>
        /// <param name="katals">The value in Katals</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double katals)
        {
            return this.fromKatals(katals);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new CatalyticActivity(<paramref name="value"/>, this)</returns>
        public CatalyticActivity CreateQuantity(double value)
        {
            return new CatalyticActivity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Katals
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(CatalyticActivity quantity)
        {
            return FromSiUnit(quantity.katals);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            CatalyticActivityUnit unit;
            var paddedFormat = UnitFormatCache<CatalyticActivityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<CatalyticActivityUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(CatalyticActivityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is CatalyticActivityUnit && Equals((CatalyticActivityUnit)obj);
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