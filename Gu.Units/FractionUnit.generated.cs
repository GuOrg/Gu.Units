
namespace Gu.Units
{
    using System;

    [Serializable]
    public struct FractionUnit : IUnit
    {
        public static readonly FractionUnit Fractions = new FractionUnit(1.0, "/x");

        public static readonly FractionUnit PartsPerMillion = new FractionUnit(1E-06, "ppm");
        public static readonly FractionUnit ppm = PartsPerMillion;

        public static readonly FractionUnit Promilles = new FractionUnit(0.001, "‰");

        public static readonly FractionUnit Percents = new FractionUnit(0.01, "%");


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public FractionUnit(double conversionFactor, string symbol)
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

        public static Fraction operator *(double left, FractionUnit right)
        {
            return Fraction.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Fraction "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Fractions "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Fractions.Symbol);
        }
    }
}
