
namespace Gu.Units
{
    using System;

    [Serializable]
    public struct PressureUnit : IUnit
    {
        public static readonly PressureUnit Pascals = new PressureUnit(1.0, "Pa");
        public static readonly PressureUnit Pa = Pascals;

        public static readonly PressureUnit Nanopascals = new PressureUnit(1E-09, "nPa");
        public static readonly PressureUnit nPa = Nanopascals;

        public static readonly PressureUnit Micropascals = new PressureUnit(1E-06, "µPa");
        public static readonly PressureUnit µPa = Micropascals;

        public static readonly PressureUnit Millipascals = new PressureUnit(0.001, "mPa");
        public static readonly PressureUnit mPa = Millipascals;

        public static readonly PressureUnit Kilopascals = new PressureUnit(1000, "kPa");
        public static readonly PressureUnit kPa = Kilopascals;

        public static readonly PressureUnit Megapascals = new PressureUnit(1000000, "MPa");
        public static readonly PressureUnit MPa = Megapascals;

        public static readonly PressureUnit Gigapascals = new PressureUnit(1000000000, "GPa");
        public static readonly PressureUnit GPa = Gigapascals;


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public PressureUnit(double conversionFactor, string symbol)
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

        public static Pressure operator *(double left, PressureUnit right)
        {
            return Pressure.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Pressure "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Pascals "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Pascals.Symbol);
        }
    }
}
