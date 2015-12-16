namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.LuminousFlux"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(LuminousFluxUnitTypeConverter))]
    public struct LuminousFluxUnit : IUnit, IUnit<LuminousFlux>, IEquatable<LuminousFluxUnit>
    {
        /// <summary>
        /// The LuminousFluxUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly LuminousFluxUnit Lumens = new LuminousFluxUnit(lumens => lumens, lumens => lumens, "lm");

        private readonly Func<double, double> toLumens;
        private readonly Func<double, double> fromLumens;
        internal readonly string symbol;

        public LuminousFluxUnit(Func<double, double> toLumens, Func<double, double> fromLumens, string symbol)
        {
            this.toLumens = toLumens;
            this.fromLumens = fromLumens;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.LuminousFluxUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.LuminousFluxUnit"/>
        /// </summary>
        public LuminousFluxUnit SiUnit => Lumens;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.LuminousFluxUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Lumens;

        public static LuminousFlux operator *(double left, LuminousFluxUnit right)
        {
            return LuminousFlux.From(left, right);
        }

        public static bool operator ==(LuminousFluxUnit left, LuminousFluxUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LuminousFluxUnit left, LuminousFluxUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="LuminousFluxUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="LuminousFluxUnit"/></returns>
        public static LuminousFluxUnit Parse(string text)
        {
            return UnitParser<LuminousFluxUnit>.Parse(text);
        }

        public static bool TryParse(string text, out LuminousFluxUnit value)
        {
            return UnitParser<LuminousFluxUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Lumens.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toLumens(value);
        }

        /// <summary>
        /// Converts a value from lumens.
        /// </summary>
        /// <param name="lumens">The value in Lumens</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double lumens)
        {
            return this.fromLumens(lumens);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new LuminousFlux(<paramref name="value"/>, this)</returns>
        public LuminousFlux CreateQuantity(double value)
        {
            return new LuminousFlux(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Lumens
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(LuminousFlux quantity)
        {
            return FromSiUnit(quantity.lumens);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            LuminousFluxUnit unit;
            var paddedFormat = UnitFormatCache<LuminousFluxUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<LuminousFluxUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(LuminousFluxUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LuminousFluxUnit && Equals((LuminousFluxUnit)obj);
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