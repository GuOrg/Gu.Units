namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Time"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(TimeUnitTypeConverter))]
    public struct TimeUnit : IUnit, IUnit<Time>, IEquatable<TimeUnit>
    {
        /// <summary>
        /// The Seconds unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly TimeUnit Seconds = new TimeUnit(seconds => seconds, seconds => seconds, "s");

        /// <summary>
        /// The Hours unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Hours = new TimeUnit(hours => 3600 * hours, seconds => seconds / 3600, "h");

        /// <summary>
        /// The Minutes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Minutes = new TimeUnit(minutes => 60 * minutes, seconds => seconds / 60, "min");

        /// <summary>
        /// The Days unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Days = new TimeUnit(days => 86400 * days, seconds => seconds / 86400, "d");

        /// <summary>
        /// The Nanoseconds unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Nanoseconds = new TimeUnit(nanoseconds => nanoseconds / 1000000000, seconds => 1000000000 * seconds, "ns");

        /// <summary>
        /// The Microseconds unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Microseconds = new TimeUnit(microseconds => microseconds / 1000000, seconds => 1000000 * seconds, "µs");

        /// <summary>
        /// The Milliseconds unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Milliseconds = new TimeUnit(milliseconds => milliseconds / 1000, seconds => 1000 * seconds, "ms");

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.TimeUnit"/>.
        /// </summary>
        internal readonly string symbol;

        private readonly Func<double, double> toSeconds;
        private readonly Func<double, double> fromSeconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeUnit"/> struct.
        /// </summary>
        /// <param name="toSeconds">The conversion to <see cref="Seconds"/></param>
        /// <param name="fromSeconds">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Seconds"/></param>
        public TimeUnit(Func<double, double> toSeconds, Func<double, double> fromSeconds, string symbol)
        {
            this.toSeconds = toSeconds;
            this.fromSeconds = fromSeconds;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.TimeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.TimeUnit"/>
        /// </summary>
        public TimeUnit SiUnit => Seconds;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Seconds;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the multiplication.</returns>
        public static Time operator *(double left, TimeUnit right)
        {
            return Time.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TimeUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.TimeUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.TimeUnit"/>.</param>
        public static bool operator ==(TimeUnit left, TimeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TimeUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.TimeUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.TimeUnit"/>.</param>
        public static bool operator !=(TimeUnit left, TimeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="TimeUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="TimeUnit"/></returns>
        public static TimeUnit Parse(string text)
        {
            return UnitParser<TimeUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.TimeUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.TimeUnit"/></param>
        /// <param name="result">The parsed <see cref="TimeUnit"/></param>
        /// <returns>True if an instance of <see cref="TimeUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out TimeUnit result)
        {
            return UnitParser<TimeUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Seconds.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSeconds(value);
        }

        /// <summary>
        /// Converts a value from seconds.
        /// </summary>
        /// <param name="seconds">The value in Seconds</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double seconds)
        {
            return this.fromSeconds(seconds);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Time(<paramref name="value"/>, this)</returns>
        public Time CreateQuantity(double value)
        {
            return new Time(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Seconds
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Time quantity)
        {
            return this.FromSiUnit(quantity.seconds);
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
            TimeUnit unit;
            var paddedFormat = UnitFormatCache<TimeUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<TimeUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.TimeUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.TimeUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same TimeUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(TimeUnit other)
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

            return obj is TimeUnit && this.Equals((TimeUnit)obj);
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