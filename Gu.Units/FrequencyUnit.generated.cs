





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Frequency"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(FrequencyUnitTypeConverter))]
    public struct FrequencyUnit : IUnit, IUnit<Frequency>, IEquatable<FrequencyUnit>
    {
        /// <summary>
        /// The Hertz unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly FrequencyUnit Hertz = new FrequencyUnit(hertz => hertz, hertz => hertz, "Hz");


        /// <summary>
        /// The Millihertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Millihertz = new FrequencyUnit(millihertz => millihertz / 1000, hertz => 1000 * hertz, "mHz");


        /// <summary>
        /// The Kilohertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Kilohertz = new FrequencyUnit(kilohertz => 1000 * kilohertz, hertz => hertz / 1000, "kHz");


        /// <summary>
        /// The Megahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Megahertz = new FrequencyUnit(megahertz => 1000000 * megahertz, hertz => hertz / 1000000, "MHz");


        /// <summary>
        /// The Gigahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Gigahertz = new FrequencyUnit(gigahertz => 1000000000 * gigahertz, hertz => hertz / 1000000000, "GHz");


        private readonly Func<double, double> toHertz;
        private readonly Func<double, double> fromHertz;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="FrequencyUnit"/>.
        /// </summary>
        /// <param name="toHertz">The conversion to <see cref="Hertz"/></param>
        /// <param name="fromHertz">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Hertz"/></param>
        public FrequencyUnit(Func<double, double> toHertz, Func<double, double> fromHertz, string symbol)
        {
            this.toHertz = toHertz;
            this.fromHertz = fromHertz;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.FrequencyUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.FrequencyUnit"/>
        /// </summary>
        public FrequencyUnit SiUnit => Hertz;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.FrequencyUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Hertz;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the multiplication.</returns>
        public static Frequency operator *(double left, FrequencyUnit right)
        {
            return Frequency.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.FrequencyUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.FrequencyUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.FrequencyUnit"/>.</param>
	    public static bool operator ==(FrequencyUnit left, FrequencyUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.FrequencyUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.FrequencyUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.FrequencyUnit"/>.</param>
        public static bool operator !=(FrequencyUnit left, FrequencyUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="FrequencyUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="FrequencyUnit"/></returns>
        public static FrequencyUnit Parse(string text)
        {
            return UnitParser<FrequencyUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.FrequencyUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.FrequencyUnit"/></param>
        /// <param name="result">The parsed <see cref="FrequencyUnit"/></param>
        /// <returns>True if an instance of <see cref="FrequencyUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out FrequencyUnit result)
        {
            return UnitParser<FrequencyUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Hertz.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toHertz(value);
        }

        /// <summary>
        /// Converts a value from hertz.
        /// </summary>
        /// <param name="hertz">The value in Hertz</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double hertz)
        {
            return this.fromHertz(hertz);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Frequency(<paramref name="value"/>, this)</returns>
        public Frequency CreateQuantity(double value)
        {
            return new Frequency(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Hertz
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Frequency quantity)
        {
            return FromSiUnit(quantity.hertz);
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
            FrequencyUnit unit;
            var paddedFormat = UnitFormatCache<FrequencyUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<FrequencyUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.FrequencyUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.FrequencyUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same FrequencyUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(FrequencyUnit other)
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

            return obj is FrequencyUnit && Equals((FrequencyUnit)obj);
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