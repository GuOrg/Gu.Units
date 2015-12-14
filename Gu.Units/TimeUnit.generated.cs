namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Time"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(TimeUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{TimeUnit.symbol}")]
    public struct TimeUnit : IUnit, IUnit<Time>, IEquatable<TimeUnit>
    {
        /// <summary>
        /// The TimeUnit unit
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

        private readonly Func<double, double> toSeconds;
        private readonly Func<double, double> fromSeconds;
        internal readonly string symbol;

        public TimeUnit(Func<double, double> toSeconds, Func<double, double> fromSeconds, string symbol)
        {
            this.toSeconds = toSeconds;
            this.fromSeconds = fromSeconds;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.TimeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.TimeUnit"/>
        /// </summary>
        public TimeUnit SiUnit => Seconds;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.TimeUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Seconds;

        public static Time operator *(double left, TimeUnit right)
        {
            return Time.From(left, right);
        }

        public static bool operator ==(TimeUnit left, TimeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TimeUnit left, TimeUnit right)
        {
            return !left.Equals(right);
        }

        public static TimeUnit Parse(string text)
        {
            return UnitParser<TimeUnit>.Parse(text);
        }

        public static bool TryParse(string text, out TimeUnit value)
        {
            return UnitParser<TimeUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Seconds.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSeconds(value);
        }

        /// <summary>
        /// Converts a value from Seconds.
        /// </summary>
        /// <param name="value">The value in Seconds</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double seconds)
        {
            return this.fromSeconds(seconds);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Time(value, this)</returns>
        public Time CreateQuantity(double value)
        {
            return new Time(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in TimeUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Time quantity)
        {
            return FromSiUnit(quantity.seconds);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(TimeUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TimeUnit && Equals((TimeUnit)obj);
        }

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