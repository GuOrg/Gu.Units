
namespace Gu.Units
{
    using System;

    [Serializable]
    public struct MassUnit : IUnit
    {
        public static readonly MassUnit Kilograms = new MassUnit(1.0, "kg");
        public static readonly MassUnit kg = Kilograms;

        public static readonly MassUnit Grams = new MassUnit(0.001, "g");
        public static readonly MassUnit g = Grams;

        public static readonly MassUnit Milligrams = new MassUnit(1E-06, "mg");
        public static readonly MassUnit mg = Milligrams;

        public static readonly MassUnit Micrograms = new MassUnit(1E-09, "µg");
        public static readonly MassUnit µg = Micrograms;


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public MassUnit(double conversionFactor, string symbol)
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

        public static Mass operator *(double left, MassUnit right)
        {
            return Mass.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Mass "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Kilograms "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Kilograms.Symbol);
        }
    }
}
