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
        /// The AngularAccelerationUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerSecondSquared = new AngularAccelerationUnit(radiansPerSecondSquared => radiansPerSecondSquared, radiansPerSecondSquared => radiansPerSecondSquared, "rad/s²");

        /// <summary>
        /// The DegreesPerSquareSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerSquareSecond = new AngularAccelerationUnit(degreesPerSquareSecond => 0.0174532925199433 * degreesPerSquareSecond, radiansPerSecondSquared => radiansPerSecondSquared / 0.0174532925199433, "°⋅s⁻²");

        /// <summary>
        /// The RadiansPerSquareHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerSquareHour = new AngularAccelerationUnit(radiansPerSquareHour => radiansPerSquareHour / 12960000, radiansPerSecondSquared => 12960000 * radiansPerSecondSquared, "h⁻²⋅rad");

        /// <summary>
        /// The DegreesPerSquareHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerSquareHour = new AngularAccelerationUnit(degreesPerSquareHour => 1.34670466974871E-09 * degreesPerSquareHour, radiansPerSecondSquared => radiansPerSecondSquared / 1.34670466974871E-09, "h⁻²⋅°");

        /// <summary>
        /// The DegreesPerSquareMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerSquareMinute = new AngularAccelerationUnit(degreesPerSquareMinute => 4.84813681109536E-06 * degreesPerSquareMinute, radiansPerSecondSquared => radiansPerSecondSquared / 4.84813681109536E-06, "min⁻²⋅°");

        /// <summary>
        /// The RadiansPerSquareMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerSquareMinute = new AngularAccelerationUnit(radiansPerSquareMinute => radiansPerSquareMinute / 3600, radiansPerSecondSquared => 3600 * radiansPerSecondSquared, "min⁻²⋅rad");

        private readonly Func<double, double> toRadiansPerSecondSquared;
        private readonly Func<double, double> fromRadiansPerSecondSquared;
        internal readonly string symbol;

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

        public static AngularAcceleration operator *(double left, AngularAccelerationUnit right)
        {
            return AngularAcceleration.From(left, right);
        }

        public static bool operator ==(AngularAccelerationUnit left, AngularAccelerationUnit right)
        {
            return left.Equals(right);
        }

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

        public static bool TryParse(string text, out AngularAccelerationUnit value)
        {
            return UnitParser<AngularAccelerationUnit>.TryParse(text, out value);
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

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<AngularAccelerationUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(AngularAccelerationUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularAccelerationUnit && Equals((AngularAccelerationUnit)obj);
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