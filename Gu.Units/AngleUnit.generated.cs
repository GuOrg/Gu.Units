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
        /// The AngleUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AngleUnit Radians = new AngleUnit(radians => radians, radians => radians, "rad");

        /// <summary>
        /// The Degrees unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngleUnit Degrees = new AngleUnit(degrees => degrees / 57.295779513082323, radians => 57.295779513082323 * radians, "°");

        private readonly Func<double, double> toRadians;
        private readonly Func<double, double> fromRadians;
        internal readonly string symbol;

        public AngleUnit(Func<double, double> toRadians, Func<double, double> fromRadians, string symbol)
        {
            this.toRadians = toRadians;
            this.fromRadians = fromRadians;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AngleUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AngleUnit"/>
        /// </summary>
        public AngleUnit SiUnit => Radians;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AngleUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Radians;

        public static Angle operator *(double left, AngleUnit right)
        {
            return Angle.From(left, right);
        }

        public static bool operator ==(AngleUnit left, AngleUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AngleUnit left, AngleUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AngleUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AngleUnit"/></returns>
        public static AngleUnit Parse(string text)
        {
            return UnitParser<AngleUnit>.Parse(text);
        }

        public static bool TryParse(string text, out AngleUnit value)
        {
            return UnitParser<AngleUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Radians.
        /// </summary>
        /// <param name="value"></param>
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
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Angle quantity)
        {
            return FromSiUnit(quantity.radians);
        }

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<AngleUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(AngleUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngleUnit && Equals((AngleUnit)obj);
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