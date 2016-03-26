namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AnglePerUnitless"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AnglePerUnitlessUnitTypeConverter))]
    public struct AnglePerUnitlessUnit : IUnit, IUnit<AnglePerUnitless>, IEquatable<AnglePerUnitlessUnit>
    {
        /// <summary>
        /// The AnglePerUnitlessUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AnglePerUnitlessUnit RadiansPerUnitless = new AnglePerUnitlessUnit(radiansPerUnitless => radiansPerUnitless, radiansPerUnitless => radiansPerUnitless, "rad/ul");

        /// <summary>
        /// The DegreesPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AnglePerUnitlessUnit DegreesPerPercent = new AnglePerUnitlessUnit(degreesPerPercent => 1.74532925199433 * degreesPerPercent, radiansPerUnitless => radiansPerUnitless / 1.74532925199433, "°/%");

        /// <summary>
        /// The RadiansPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AnglePerUnitlessUnit RadiansPerPercent = new AnglePerUnitlessUnit(radiansPerPercent => 100 * radiansPerPercent, radiansPerUnitless => radiansPerUnitless / 100, "rad/%");

        private readonly Func<double, double> toRadiansPerUnitless;
        private readonly Func<double, double> fromRadiansPerUnitless;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="AnglePerUnitlessUnit"/>.
        /// </summary>
        /// <param name="toRadiansPerUnitless">The conversion to <see cref="RadiansPerUnitless"/></param>
        /// <param name="fromRadiansPerUnitless">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="RadiansPerUnitless"/></param>
        public AnglePerUnitlessUnit(Func<double, double> toRadiansPerUnitless, Func<double, double> fromRadiansPerUnitless, string symbol)
        {
            this.toRadiansPerUnitless = toRadiansPerUnitless;
            this.fromRadiansPerUnitless = fromRadiansPerUnitless;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AnglePerUnitlessUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AnglePerUnitlessUnit"/>
        /// </summary>
        public AnglePerUnitlessUnit SiUnit => RadiansPerUnitless;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AnglePerUnitlessUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => RadiansPerUnitless;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AnglePerUnitless"/> that is the result from the multiplication.</returns>
        public static AnglePerUnitless operator *(double left, AnglePerUnitlessUnit right)
        {
            return AnglePerUnitless.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AnglePerUnitlessUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitlessUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitlessUnit"/>.</param>
	    public static bool operator ==(AnglePerUnitlessUnit left, AnglePerUnitlessUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AnglePerUnitlessUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitlessUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitlessUnit"/>.</param>
        public static bool operator !=(AnglePerUnitlessUnit left, AnglePerUnitlessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AnglePerUnitlessUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AnglePerUnitlessUnit"/></returns>
        public static AnglePerUnitlessUnit Parse(string text)
        {
            return UnitParser<AnglePerUnitlessUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitlessUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitlessUnit"/></param>
        /// <param name="result">The parsed <see cref="AnglePerUnitlessUnit"/></param>
        /// <returns>True if an instance of <see cref="AnglePerUnitlessUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out AnglePerUnitlessUnit result)
        {
            return UnitParser<AnglePerUnitlessUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to RadiansPerUnitless.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toRadiansPerUnitless(value);
        }

        /// <summary>
        /// Converts a value from radiansPerUnitless.
        /// </summary>
        /// <param name="radiansPerUnitless">The value in RadiansPerUnitless</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double radiansPerUnitless)
        {
            return this.fromRadiansPerUnitless(radiansPerUnitless);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new AnglePerUnitless(<paramref name="value"/>, this)</returns>
        public AnglePerUnitless CreateQuantity(double value)
        {
            return new AnglePerUnitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in RadiansPerUnitless
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AnglePerUnitless quantity)
        {
            return FromSiUnit(quantity.radiansPerUnitless);
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
            AnglePerUnitlessUnit unit;
            var paddedFormat = UnitFormatCache<AnglePerUnitlessUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AnglePerUnitlessUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AnglePerUnitlessUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AnglePerUnitlessUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AnglePerUnitlessUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(AnglePerUnitlessUnit other)
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

            return obj is AnglePerUnitlessUnit && Equals((AnglePerUnitlessUnit)obj);
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