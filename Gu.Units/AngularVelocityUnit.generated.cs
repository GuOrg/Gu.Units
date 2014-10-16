namespace Gu.Units
{
    using System;

    [Serializable]
    public struct AngularVelocityUnit : IUnit
    {
        public static readonly AngularVelocityUnit RadiansPerSecond = new AngularVelocityUnit(1.0, "rad/s");


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AngularVelocityUnit(double conversionFactor, string symbol)
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

        public static AngularVelocity operator *(double left, AngularVelocityUnit right)
        {
            return AngularVelocity.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.AngularVelocity "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.RadiansPerSecond "/>.
        /// </summary>
        /// <param name="value"></param>
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
