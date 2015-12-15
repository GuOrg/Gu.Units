namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Speed"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SpeedUnitTypeConverter))]
    public struct SpeedUnit : IUnit, IUnit<Speed>, IEquatable<SpeedUnit>
    {
        /// <summary>
        /// The SpeedUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerSecond = new SpeedUnit(metresPerSecond => metresPerSecond, metresPerSecond => metresPerSecond, "m/s");

        /// <summary>
        /// The KilometresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit KilometresPerHour = new SpeedUnit(kilometresPerHour => 0.277777777777778 * kilometresPerHour, metresPerSecond => metresPerSecond / 0.277777777777778, "km/h");

        /// <summary>
        /// The CentimetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerMinute = new SpeedUnit(centimetresPerMinute => centimetresPerMinute / 6000, metresPerSecond => 6000 * metresPerSecond, "cm/min");

        /// <summary>
        /// The MetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerMinute = new SpeedUnit(metresPerMinute => metresPerMinute / 60, metresPerSecond => 60 * metresPerSecond, "m/min");

        /// <summary>
        /// The MetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerHour = new SpeedUnit(metresPerHour => metresPerHour / 3600, metresPerSecond => 3600 * metresPerSecond, "m/h");

        /// <summary>
        /// The MillimetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerHour = new SpeedUnit(millimetresPerHour => millimetresPerHour / 3600000, metresPerSecond => 3600000 * metresPerSecond, "mm/h");

        /// <summary>
        /// The CentimetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerHour = new SpeedUnit(centimetresPerHour => centimetresPerHour / 360000, metresPerSecond => 360000 * metresPerSecond, "cm/h");

        /// <summary>
        /// The MillimetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerMinute = new SpeedUnit(millimetresPerMinute => millimetresPerMinute / 60000, metresPerSecond => 60000 * metresPerSecond, "mm/min");

        /// <summary>
        /// The MillimetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerSecond = new SpeedUnit(millimetresPerSecond => millimetresPerSecond / 1000, metresPerSecond => 1000 * metresPerSecond, "mm/s");

        /// <summary>
        /// The CentimetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerSecond = new SpeedUnit(centimetresPerSecond => centimetresPerSecond / 100, metresPerSecond => 100 * metresPerSecond, "cm/s");

        private readonly Func<double, double> toMetresPerSecond;
        private readonly Func<double, double> fromMetresPerSecond;
        internal readonly string symbol;

        public SpeedUnit(Func<double, double> toMetresPerSecond, Func<double, double> fromMetresPerSecond, string symbol)
        {
            this.toMetresPerSecond = toMetresPerSecond;
            this.fromMetresPerSecond = fromMetresPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SpeedUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SpeedUnit"/>
        /// </summary>
        public SpeedUnit SiUnit => MetresPerSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SpeedUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MetresPerSecond;

        public static Speed operator *(double left, SpeedUnit right)
        {
            return Speed.From(left, right);
        }

        public static bool operator ==(SpeedUnit left, SpeedUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SpeedUnit left, SpeedUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="SpeedUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="SpeedUnit"/></returns>
        public static SpeedUnit Parse(string text)
        {
            return UnitParser<SpeedUnit>.Parse(text);
        }

        public static bool TryParse(string text, out SpeedUnit value)
        {
            return UnitParser<SpeedUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerSecond.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerSecond(value);
        }

        /// <summary>
        /// Converts a value from metresPerSecond.
        /// </summary>
        /// <param name="MetresPerSecond">The value in MetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerSecond)
        {
            return this.fromMetresPerSecond(metresPerSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Speed(<paramref name="value"/>, this)</returns>
        public Speed CreateQuantity(double value)
        {
            return new Speed(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerSecond
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Speed quantity)
        {
            return FromSiUnit(quantity.metresPerSecond);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            SpeedUnit unit;
            var paddedFormat = UnitFormatCache<SpeedUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<SpeedUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(SpeedUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SpeedUnit && Equals((SpeedUnit)obj);
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