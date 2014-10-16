namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.DensityUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct DensityUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.KilogramsPerCubicMetre"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit KilogramsPerCubicMetre = new DensityUnit(1.0, "kg/m³");

        /// <summary>
        /// The <see cref="T:Gu.Units.GramsPerCubicMillimetre"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit GramsPerCubicMillimetre = new DensityUnit(1000000, "g / mm³");

        /// <summary>
        /// The <see cref="T:Gu.Units.GramsPerCubicCentimetre"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit GramsPerCubicCentimetre = new DensityUnit(1000, "g / cm³");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public DensityUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.KilogramsPerCubicMetre"/>.
        /// </summary>
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
        /// Converts a value to <see cref="T:Gu.Units.KilogramsPerCubicMetre"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from KilogramsPerCubicMetre.
        /// </summary>
        /// <param name="value">The value in KilogramsPerCubicMetre</param>
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