namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AngularJerk"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AngularJerkUnitTypeConverter))]
    public struct AngularJerkUnit : IUnit, IUnit<AngularJerk>, IEquatable<AngularJerkUnit>
    {
        /// <summary>
        /// The RadiansPerSecondCubed unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AngularJerkUnit RadiansPerSecondCubed = new AngularJerkUnit(radiansPerSecondCubed => radiansPerSecondCubed, radiansPerSecondCubed => radiansPerSecondCubed, "rad/s³");

        /// <summary>
        /// The DegreesPerSecondCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit DegreesPerSecondCubed = new AngularJerkUnit(degreesPerSecondCubed => 0.0174532925199433 * degreesPerSecondCubed, radiansPerSecondCubed => radiansPerSecondCubed / 0.0174532925199433, "°⋅s⁻³");

        /// <summary>
        /// The RadiansPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit RadiansPerHourCubed = new AngularJerkUnit(radiansPerHourCubed => radiansPerHourCubed / 46656000000, radiansPerSecondCubed => 46656000000 * radiansPerSecondCubed, "rad⋅h⁻³");

        /// <summary>
        /// The DegreesPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit DegreesPerHourCubed = new AngularJerkUnit(degreesPerHourCubed => 3.74084630485753E-13 * degreesPerHourCubed, radiansPerSecondCubed => radiansPerSecondCubed / 3.74084630485753E-13, "°⋅h⁻³");

        /// <summary>
        /// The RadiansPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit RadiansPerMinuteCubed = new AngularJerkUnit(radiansPerMinuteCubed => radiansPerMinuteCubed / 216000, radiansPerSecondCubed => 216000 * radiansPerSecondCubed, "rad⋅min⁻³");

        /// <summary>
        /// The DegreesPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit DegreesPerMinuteCubed = new AngularJerkUnit(degreesPerMinuteCubed => 8.08022801849227E-08 * degreesPerMinuteCubed, radiansPerSecondCubed => radiansPerSecondCubed / 8.08022801849227E-08, "°⋅min⁻³");

        private readonly Func<double, double> toRadiansPerSecondCubed;
        private readonly Func<double, double> fromRadiansPerSecondCubed;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="AngularJerkUnit"/>.
        /// </summary>
        /// <param name="toRadiansPerSecondCubed">The conversion to <see cref="RadiansPerSecondCubed"/></param>
        /// <param name="fromRadiansPerSecondCubed">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="RadiansPerSecondCubed"/></param>
        public AngularJerkUnit(Func<double, double> toRadiansPerSecondCubed, Func<double, double> fromRadiansPerSecondCubed, string symbol)
        {
            this.toRadiansPerSecondCubed = toRadiansPerSecondCubed;
            this.fromRadiansPerSecondCubed = fromRadiansPerSecondCubed;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AngularJerkUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AngularJerkUnit"/>
        /// </summary>
        public AngularJerkUnit SiUnit => RadiansPerSecondCubed;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AngularJerkUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => RadiansPerSecondCubed;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularJerk"/> that is the result from the multiplication.</returns>
        public static AngularJerk operator *(double left, AngularJerkUnit right)
        {
            return AngularJerk.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularJerkUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerkUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerkUnit"/>.</param>
	    public static bool operator ==(AngularJerkUnit left, AngularJerkUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularJerkUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerkUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerkUnit"/>.</param>
        public static bool operator !=(AngularJerkUnit left, AngularJerkUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AngularJerkUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AngularJerkUnit"/></returns>
        public static AngularJerkUnit Parse(string text)
        {
            return UnitParser<AngularJerkUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularJerkUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularJerkUnit"/></param>
        /// <param name="result">The parsed <see cref="AngularJerkUnit"/></param>
        /// <returns>True if an instance of <see cref="AngularJerkUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out AngularJerkUnit result)
        {
            return UnitParser<AngularJerkUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to RadiansPerSecondCubed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toRadiansPerSecondCubed(value);
        }

        /// <summary>
        /// Converts a value from radiansPerSecondCubed.
        /// </summary>
        /// <param name="radiansPerSecondCubed">The value in RadiansPerSecondCubed</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double radiansPerSecondCubed)
        {
            return this.fromRadiansPerSecondCubed(radiansPerSecondCubed);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new AngularJerk(<paramref name="value"/>, this)</returns>
        public AngularJerk CreateQuantity(double value)
        {
            return new AngularJerk(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in RadiansPerSecondCubed
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AngularJerk quantity)
        {
            return FromSiUnit(quantity.radiansPerSecondCubed);
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
            AngularJerkUnit unit;
            var paddedFormat = UnitFormatCache<AngularJerkUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AngularJerkUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularJerkUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularJerkUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularJerkUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(AngularJerkUnit other)
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

            return obj is AngularJerkUnit && Equals((AngularJerkUnit)obj);
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