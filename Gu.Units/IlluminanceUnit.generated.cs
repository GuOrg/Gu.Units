namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Illuminance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(IlluminanceUnitTypeConverter))]
    public struct IlluminanceUnit : IUnit, IUnit<Illuminance>, IEquatable<IlluminanceUnit>
    {
        /// <summary>
        /// The IlluminanceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly IlluminanceUnit Lux = new IlluminanceUnit(lux => lux, lux => lux, "lx");

        private readonly Func<double, double> toLux;
        private readonly Func<double, double> fromLux;
        internal readonly string symbol;

        public IlluminanceUnit(Func<double, double> toLux, Func<double, double> fromLux, string symbol)
        {
            this.toLux = toLux;
            this.fromLux = fromLux;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.IlluminanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.IlluminanceUnit"/>
        /// </summary>
        public IlluminanceUnit SiUnit => Lux;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.IlluminanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Lux;

        public static Illuminance operator *(double left, IlluminanceUnit right)
        {
            return Illuminance.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.IlluminanceUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
	    public static bool operator ==(IlluminanceUnit left, IlluminanceUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.IlluminanceUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.IlluminanceUnit"/>.</param>
        public static bool operator !=(IlluminanceUnit left, IlluminanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="IlluminanceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="IlluminanceUnit"/></returns>
        public static IlluminanceUnit Parse(string text)
        {
            return UnitParser<IlluminanceUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.IlluminanceUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.IlluminanceUnit"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="IlluminanceUnit"/></param>
        /// <returns>True if an instance of <see cref="IlluminanceUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out IlluminanceUnit value)
        {
            return UnitParser<IlluminanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Lux.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toLux(value);
        }

        /// <summary>
        /// Converts a value from lux.
        /// </summary>
        /// <param name="lux">The value in Lux</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double lux)
        {
            return this.fromLux(lux);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Illuminance(<paramref name="value"/>, this)</returns>
        public Illuminance CreateQuantity(double value)
        {
            return new Illuminance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Lux
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Illuminance quantity)
        {
            return FromSiUnit(quantity.lux);
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
            IlluminanceUnit unit;
            var paddedFormat = UnitFormatCache<IlluminanceUnit>.GetOrCreate(format, out unit);
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
        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<IlluminanceUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.IlluminanceUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.IlluminanceUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same IlluminanceUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(IlluminanceUnit other)
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

            return obj is IlluminanceUnit && Equals((IlluminanceUnit)obj);
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