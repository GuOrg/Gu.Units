namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AngularVelocityUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct AngularVelocityUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerSecond"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AngularVelocityUnit RadiansPerSecond = new AngularVelocityUnit(1.0, "rad/s");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AngularVelocityUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.RadiansPerSecond"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static AngularVelocity operator *(double left, AngularVelocityUnit right)
        {
            return AngularVelocity.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.RadiansPerSecond"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from RadiansPerSecond.
        /// </summary>
        /// <param name="value">The value in RadiansPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), RadiansPerSecond.Symbol);
        }
    }
}