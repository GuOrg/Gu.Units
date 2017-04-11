namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Angle"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AngleUnitTypeConverter))]
    public struct AngleUnit : IUnit, IUnit<Angle>, IEquatable<AngleUnit>
    {
        /// <summary>
        /// The Radians unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AngleUnit Radians = new AngleUnit(radians => radians, radians => radians, "rad");

        /// <summary>
        /// The Degrees unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngleUnit Degrees = new AngleUnit(degrees => degrees / 57.295779513082323, radians => 57.295779513082323 * radians, "°");

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.AngleUnit"/>.
        /// </summary>
        internal readonly string symbol;

        private readonly Func<double, double> toRadians;
        private readonly Func<double, double> fromRadians;

        /// <summary>
        /// Initializes a new instance of the <see cref="AngleUnit"/> struct.
        /// </summary>
        /// <param name="toRadians">The conversion to <see cref="Radians"/></param>
        /// <param name="fromRadians">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Radians"/></param>
        public AngleUnit(Func<double, double> toRadians, Func<double, double> fromRadians, string symbol)
        {
            this.toRadians = toRadians;
            this.fromRadians = fromRadians;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.AngleUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.AngleUnit"/>
        /// </summary>
        public AngleUnit SiUnit => Radians;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Radians;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Angle"/> that is the result from the multiplication.</returns>
        public static Angle operator *(double left, AngleUnit right)
        {
            return Angle.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngleUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngleUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngleUnit"/>.</param>
        public static bool operator ==(AngleUnit left, AngleUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngleUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngleUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngleUnit"/>.</param>
        public static bool operator !=(AngleUnit left, AngleUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AngleUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="AngleUnit"/></returns>
        public static AngleUnit Parse(string text)
        {
            return UnitParser<AngleUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngleUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngleUnit"/></param>
        /// <param name="result">The parsed <see cref="AngleUnit"/></param>
        /// <returns>True if an instance of <see cref="AngleUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out AngleUnit result)
        {
            return UnitParser<AngleUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Radians.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toRadians(value);
        }

        /// <summary>
        /// Converts a value from radians.
        /// </summary>
        /// <param name="radians">The value in Radians</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double radians)
        {
            return this.fromRadians(radians);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Angle(<paramref name="value"/>, this)</returns>
        public Angle CreateQuantity(double value)
        {
            return new Angle(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Radians
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Angle quantity)
        {
            return this.FromSiUnit(quantity.radians);
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
            AngleUnit unit;
            var paddedFormat = UnitFormatCache<AngleUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AngleUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngleUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AngleUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngleUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(AngleUnit other)
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

            return obj is AngleUnit && this.Equals((AngleUnit)obj);
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