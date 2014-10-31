namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.TimeUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct TimeUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Seconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Seconds = new TimeUnit(1.0, "s");
        /// <summary>
        /// The <see cref="T:Gu.Units.Seconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit s = Seconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanoseconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Nanoseconds = new TimeUnit(1E-09, "ns");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanoseconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit ns = Nanoseconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microseconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Microseconds = new TimeUnit(1E-06, "µs");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microseconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit µs = Microseconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Milliseconds"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Milliseconds = new TimeUnit(0.001, "ms");
        /// <summary>
        /// The <see cref="T:Gu.Units.Milliseconds"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit ms = Milliseconds;

        /// <summary>
        /// The <see cref="T:Gu.Units.Hours"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Hours = new TimeUnit(3600, "h");
        /// <summary>
        /// The <see cref="T:Gu.Units.Hours"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit h = Hours;

        /// <summary>
        /// The <see cref="T:Gu.Units.Minutes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Minutes = new TimeUnit(60, "min");
        /// <summary>
        /// The <see cref="T:Gu.Units.Minutes"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit min = Minutes;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public TimeUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
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
        /// Converts a value to <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Seconds.
        /// </summary>
        /// <param name="value">The value in Seconds</param>
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