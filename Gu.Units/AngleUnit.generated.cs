
namespace Gu.Units
{
    using System;

    [Serializable]
    public struct AngleUnit : IUnit
    {
        public static readonly AngleUnit Radians = new AngleUnit(1.0, "rad");
        public static readonly AngleUnit rad = Radians;

        public static readonly AngleUnit Degrees = new AngleUnit(57.2957795130823, "°");


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AngleUnit(double conversionFactor, string symbol)
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

        public static Angle operator *(double left, AngleUnit right)
        {
            return Angle.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Angle "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Radians "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Radians.Symbol);
        }
    }
}
