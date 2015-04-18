namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.LuminousIntensityUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct LuminousIntensityUnit : IUnit, IUnit<LuminousIntensity>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Candelas"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly LuminousIntensityUnit Candelas = new LuminousIntensityUnit(1.0, "cd");
        /// <summary>
        /// The <see cref="T:Gu.Units.Candelas"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LuminousIntensityUnit cd = Candelas;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public LuminousIntensityUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Candelas"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static LuminousIntensity operator *(double left, LuminousIntensityUnit right)
        {
            return LuminousIntensity.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Candelas"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Candelas.
        /// </summary>
        /// <param name="value">The value in Candelas</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public LuminousIntensity CreateQuantity(double value)
        {
            return new LuminousIntensity(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(LuminousIntensity quantity)
        {
            return FromSiUnit(quantity.candelas);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Candelas.Symbol);
        }
    }
}