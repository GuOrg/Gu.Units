namespace Gu.Units
{
    using System;

    [Serializable]
    public struct TimeUnit : IUnit
    {
        public static readonly TimeUnit Seconds = new TimeUnit(1.0, "s");
        public static readonly TimeUnit s = Seconds;

        public static readonly TimeUnit Nanoseconds = new TimeUnit(1E-09, "ns");
        public static readonly TimeUnit ns = Nanoseconds;

        public static readonly TimeUnit Microseconds = new TimeUnit(1E-06, "µs");
        public static readonly TimeUnit µs = Microseconds;

        public static readonly TimeUnit Milliseconds = new TimeUnit(0.001, "ms");
        public static readonly TimeUnit ms = Milliseconds;

        public static readonly TimeUnit Hours = new TimeUnit(3600, "h");
        public static readonly TimeUnit h = Hours;

        public static readonly TimeUnit Minutes = new TimeUnit(60, "min");
        public static readonly TimeUnit min = Minutes;


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public TimeUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Time operator *(double left, TimeUnit right)
        {
            return Time.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Time "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Seconds "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Seconds.Symbol);
        }
    }
}
