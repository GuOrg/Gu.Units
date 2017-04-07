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
        /// The Lumens unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly LuminousFluxUnit Lumens = new LuminousFluxUnit(lumens => lumens, lumens => lumens, "lm");

        private readonly Func<double, double> toLumens;
        private readonly Func<double, double> fromLumens;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="LuminousFluxUnit"/>.
        /// </summary>
        /// <param name="toLumens">The conversion to <see cref="Lumens"/></param>
        /// <param name="fromLumens">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Lumens"/></param>
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

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LuminousFlux"/> that is the result from the multiplication.</returns>
        public static LuminousFlux operator *(double left, LuminousFluxUnit right)
        {
            return LuminousFlux.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LuminousFluxUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFluxUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFluxUnit"/>.</param>
	    public static bool operator ==(LuminousFluxUnit left, LuminousFluxUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LuminousFluxUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFluxUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFluxUnit"/>.</param>
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

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFluxUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFluxUnit"/></param>
        /// <param name="result">The parsed <see cref="LuminousFluxUnit"/></param>
        /// <returns>True if an instance of <see cref="LuminousFluxUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out LuminousFluxUnit result)
        {
            return UnitParser<LuminousFluxUnit>.TryParse(text, out result);
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

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SymbolFormat symbolFormat)
        {
            var paddedFormat = UnitFormatCache<LuminousFluxUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LuminousFluxUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.LuminousFluxUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LuminousFluxUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(LuminousFluxUnit other)
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

            return obj is LuminousFluxUnit && Equals((LuminousFluxUnit)obj);
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