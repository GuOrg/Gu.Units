namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.SpeedUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct SpeedUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerSecond"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerSecond = new SpeedUnit(1.0, "m/s");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerSecond"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerSecond = new SpeedUnit(0.001, "mm / s");

        /// <summary>
        /// The <see cref="T:Gu.Units.CentimetresPerSecond"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerSecond = new SpeedUnit(0.01, "cm / s");

        /// <summary>
        /// The <see cref="T:Gu.Units.KilometresPerHour"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit KilometresPerHour = new SpeedUnit(0.277777777777778, "km / h");

        /// <summary>
        /// The <see cref="T:Gu.Units.CentimetresPerMinute"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerMinute = new SpeedUnit(0.000166666666666667, "cm / min");

        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerMinute"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerMinute = new SpeedUnit(0.0166666666666667, "m / min");

        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerHour"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerHour = new SpeedUnit(0.000277777777777778, "m / h");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerHour"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerHour = new SpeedUnit(2.77777777777778E-07, "mm / h");

        /// <summary>
        /// The <see cref="T:Gu.Units.CentimetresPerHour"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerHour = new SpeedUnit(2.77777777777778E-06, "cm / h");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerMinute"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerMinute = new SpeedUnit(1.66666666666667E-05, "mm / min");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public SpeedUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.MetresPerSecond"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Speed operator *(double left, SpeedUnit right)
        {
            return Speed.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.MetresPerSecond"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerSecond.
        /// </summary>
        /// <param name="value">The value in MetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), MetresPerSecond.Symbol);
        }
    }
}