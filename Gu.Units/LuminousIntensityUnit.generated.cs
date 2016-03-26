namespace Gu.Units
{
    using System;
    using System.ComponentModel;

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

        /// <summary>
        /// Initializes a new instance of <see cref="LuminousIntensityUnit"/>.
        /// </summary>
        /// <param name="toCandelas">The conversion to <see cref="Candelas"/></param>
        /// <param name="fromCandelas">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Candelas"/></param>
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

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LuminousIntensity"/> that is the result from the multiplication.</returns>
        public static LuminousIntensity operator *(double left, LuminousIntensityUnit right)
        {
            return LuminousIntensity.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LuminousIntensityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousIntensityUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousIntensityUnit"/>.</param>
	    public static bool operator ==(LuminousIntensityUnit left, LuminousIntensityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LuminousIntensityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousIntensityUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousIntensityUnit"/>.</param>
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

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousIntensityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousIntensityUnit"/></param>
        /// <param name="result">The parsed <see cref="LuminousIntensityUnit"/></param>
        /// <returns>True if an instance of <see cref="LuminousIntensityUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out LuminousIntensityUnit result)
        {
            return UnitParser<LuminousIntensityUnit>.TryParse(text, out result);
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
        /// <param name="candelas">The value in Candelas</param>
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

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SymbolFormat symbolFormat)
        {
            var paddedFormat = UnitFormatCache<LuminousIntensityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LuminousIntensityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.LuminousIntensityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LuminousIntensityUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(LuminousIntensityUnit other)
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

            return obj is LuminousIntensityUnit && Equals((LuminousIntensityUnit)obj);
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