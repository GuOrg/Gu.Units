namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Current"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(CurrentUnitTypeConverter))]
    public struct CurrentUnit : IUnit, IUnit<Current>, IEquatable<CurrentUnit>
    {
        /// <summary>
        /// The CurrentUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly CurrentUnit Amperes = new CurrentUnit(amperes => amperes, amperes => amperes, "A");

        /// <summary>
        /// The Milliamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Milliamperes = new CurrentUnit(milliamperes => milliamperes / 1000, amperes => 1000 * amperes, "mA");

        /// <summary>
        /// The Kiloamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Kiloamperes = new CurrentUnit(kiloamperes => 1000 * kiloamperes, amperes => amperes / 1000, "kA");

        /// <summary>
        /// The Megaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Megaamperes = new CurrentUnit(megaamperes => 1000000 * megaamperes, amperes => amperes / 1000000, "MA");

        /// <summary>
        /// The Microamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Microamperes = new CurrentUnit(microamperes => microamperes / 1000000, amperes => 1000000 * amperes, "µA");

        /// <summary>
        /// The Nanoamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Nanoamperes = new CurrentUnit(nanoamperes => nanoamperes / 1000000000, amperes => 1000000000 * amperes, "nA");

        /// <summary>
        /// The Gigaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Gigaamperes = new CurrentUnit(gigaamperes => 1000000000 * gigaamperes, amperes => amperes / 1000000000, "GA");

        private readonly Func<double, double> toAmperes;
        private readonly Func<double, double> fromAmperes;
        internal readonly string symbol;

        public CurrentUnit(Func<double, double> toAmperes, Func<double, double> fromAmperes, string symbol)
        {
            this.toAmperes = toAmperes;
            this.fromAmperes = fromAmperes;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.CurrentUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.CurrentUnit"/>
        /// </summary>
        public CurrentUnit SiUnit => Amperes;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.CurrentUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Amperes;

        public static Current operator *(double left, CurrentUnit right)
        {
            return Current.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CurrentUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
	    public static bool operator ==(CurrentUnit left, CurrentUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CurrentUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CurrentUnit"/>.</param>
        public static bool operator !=(CurrentUnit left, CurrentUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="CurrentUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="CurrentUnit"/></returns>
        public static CurrentUnit Parse(string text)
        {
            return UnitParser<CurrentUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.CurrentUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.CurrentUnit"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="CurrentUnit"/></param>
        /// <returns>True if an instance of <see cref="CurrentUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out CurrentUnit value)
        {
            return UnitParser<CurrentUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Amperes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toAmperes(value);
        }

        /// <summary>
        /// Converts a value from amperes.
        /// </summary>
        /// <param name="amperes">The value in Amperes</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double amperes)
        {
            return this.fromAmperes(amperes);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Current(<paramref name="value"/>, this)</returns>
        public Current CreateQuantity(double value)
        {
            return new Current(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Amperes
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Current quantity)
        {
            return FromSiUnit(quantity.amperes);
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
            CurrentUnit unit;
            var paddedFormat = UnitFormatCache<CurrentUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<CurrentUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.CurrentUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.CurrentUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same CurrentUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(CurrentUnit other)
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

            return obj is CurrentUnit && Equals((CurrentUnit)obj);
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