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
        /// The AngularJerkUnit unit
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

        public static AngularJerk operator *(double left, AngularJerkUnit right)
        {
            return AngularJerk.From(left, right);
        }

        public static bool operator ==(AngularJerkUnit left, AngularJerkUnit right)
        {
            return left.Equals(right);
        }

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

        public static bool TryParse(string text, out AngularJerkUnit value)
        {
            return UnitParser<AngularJerkUnit>.TryParse(text, out value);
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

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<AngularJerkUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(AngularJerkUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularJerkUnit && Equals((AngularJerkUnit)obj);
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