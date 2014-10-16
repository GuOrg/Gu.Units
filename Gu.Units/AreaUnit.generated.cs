
namespace Gu.Units
{
    using System;

    [Serializable]
    public struct AreaUnit : IUnit
    {
        public static readonly AreaUnit SquareMetres = new AreaUnit(1.0, "m^2");

        public static readonly AreaUnit SquareMillimetres = new AreaUnit(1E-06, "mm^2");

        public static readonly AreaUnit SquareCentimetres = new AreaUnit(0.0001, "cm^2");

        public static readonly AreaUnit SquareDecimetres = new AreaUnit(0.01, "dm^2");

        public static readonly AreaUnit SquareKilometres = new AreaUnit(1000000, "km^2");


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AreaUnit(double conversionFactor, string symbol)
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

        public static Area operator *(double left, AreaUnit right)
        {
            return Area.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Area "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.SquareMetres "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), SquareMetres.Symbol);
        }
    }
}
