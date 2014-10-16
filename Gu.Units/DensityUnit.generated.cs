
namespace Gu.Units
{
    using System;

    [Serializable]
    public struct DensityUnit : IUnit
    {
        public static readonly DensityUnit KilogramsPerCubicMetre = new DensityUnit(1.0, "ρ");
        public static readonly DensityUnit ρ = KilogramsPerCubicMetre;

        public static readonly DensityUnit GramsPerCubicMillimetre = new DensityUnit(1000000, "g / mm^3");

        public static readonly DensityUnit GramsPerCubicCentimetre = new DensityUnit(1000, "g / cm^3");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public DensityUnit(double conversionFactor, string symbol)
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

        public static Density operator *(double left, DensityUnit right)
        {
            return Density.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Density "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.KilogramsPerCubicMetre "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), KilogramsPerCubicMetre.Symbol);
        }
    }
}
