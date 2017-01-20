





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AngularAcceleration"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AngularAccelerationUnitTypeConverter))]
    public struct AngularAccelerationUnit : IUnit, IUnit<AngularAcceleration>, IEquatable<AngularAccelerationUnit>
    {
        /// <summary>
        /// The RadiansPerSecondSquared unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerSecondSquared = new AngularAccelerationUnit(radiansPerSecondSquared => radiansPerSecondSquared, radiansPerSecondSquared => radiansPerSecondSquared, "rad/s²");


        /// <summary>
        /// The DegreesPerSecondSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerSecondSquared = new AngularAccelerationUnit(degreesPerSecondSquared => 0.0174532925199433 * degreesPerSecondSquared, radiansPerSecondSquared => radiansPerSecondSquared / 0.0174532925199433, "°⋅s⁻²");


        /// <summary>
        /// The RadiansPerHourSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerHourSquared = new AngularAccelerationUnit(radiansPerHourSquared => radiansPerHourSquared / 12960000, radiansPerSecondSquared => 12960000 * radiansPerSecondSquared, "h⁻²⋅rad");


        /// <summary>
        /// The DegreesPerHourSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerHourSquared = new AngularAccelerationUnit(degreesPerHourSquared => 1.34670466974871E-09 * degreesPerHourSquared, radiansPerSecondSquared => radiansPerSecondSquared / 1.34670466974871E-09, "h⁻²⋅°");


        /// <summary>
        /// The DegreesPerMinuteSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerMinuteSquared = new AngularAccelerationUnit(degreesPerMinuteSquared => 4.84813681109536E-06 * degreesPerMinuteSquared, radiansPerSecondSquared => radiansPerSecondSquared / 4.84813681109536E-06, "min⁻²⋅°");


        /// <summary>
        /// The RadiansPerMinuteSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerMinuteSquared = new AngularAccelerationUnit(radiansPerMinuteSquared => radiansPerMinuteSquared / 3600, radiansPerSecondSquared => 3600 * radiansPerSecondSquared, "min⁻²⋅rad");


        private readonly Func<double, double> toRadiansPerSecondSquared;
        private readonly Func<double, double> fromRadiansPerSecondSquared;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="AngularAccelerationUnit"/>.
        /// </summary>
        /// <param name="toRadiansPerSecondSquared">The conversion to <see cref="RadiansPerSecondSquared"/></param>
        /// <param name="fromRadiansPerSecondSquared">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="RadiansPerSecondSquared"/></param>
        public AngularAccelerationUnit(Func<double, double> toRadiansPerSecondSquared, Func<double, double> fromRadiansPerSecondSquared, string symbol)
        {
            this.toRadiansPerSecondSquared = toRadiansPerSecondSquared;
            this.fromRadiansPerSecondSquared = fromRadiansPerSecondSquared;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AngularAccelerationUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AngularAccelerationUnit"/>
        /// </summary>
        public AngularAccelerationUnit SiUnit => RadiansPerSecondSquared;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AngularAccelerationUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => RadiansPerSecondSquared;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularAcceleration"/> that is the result from the multiplication.</returns>
        public static AngularAcceleration operator *(double left, AngularAccelerationUnit right)
        {
            return AngularAcceleration.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularAccelerationUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAccelerationUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAccelerationUnit"/>.</param>
	    public static bool operator ==(AngularAccelerationUnit left, AngularAccelerationUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularAccelerationUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAccelerationUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAccelerationUnit"/>.</param>
        public static bool operator !=(AngularAccelerationUnit left, AngularAccelerationUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AngularAccelerationUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AngularAccelerationUnit"/></returns>
        public static AngularAccelerationUnit Parse(string text)
        {
            return UnitParser<AngularAccelerationUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAccelerationUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAccelerationUnit"/></param>
        /// <param name="result">The parsed <see cref="AngularAccelerationUnit"/></param>
        /// <returns>True if an instance of <see cref="AngularAccelerationUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out AngularAccelerationUnit result)
        {
            return UnitParser<AngularAccelerationUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to RadiansPerSecondSquared.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toRadiansPerSecondSquared(value);
        }

        /// <summary>
        /// Converts a value from radiansPerSecondSquared.
        /// </summary>
        /// <param name="radiansPerSecondSquared">The value in RadiansPerSecondSquared</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double radiansPerSecondSquared)
        {
            return this.fromRadiansPerSecondSquared(radiansPerSecondSquared);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new AngularAcceleration(<paramref name="value"/>, this)</returns>
        public AngularAcceleration CreateQuantity(double value)
        {
            return new AngularAcceleration(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in RadiansPerSecondSquared
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AngularAcceleration quantity)
        {
            return FromSiUnit(quantity.radiansPerSecondSquared);
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
            AngularAccelerationUnit unit;
            var paddedFormat = UnitFormatCache<AngularAccelerationUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AngularAccelerationUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularAccelerationUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularAccelerationUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularAccelerationUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(AngularAccelerationUnit other)
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

            return obj is AngularAccelerationUnit && Equals((AngularAccelerationUnit)obj);
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