namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.SpecificEnergyUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct SpecificEnergyUnit : IUnit, IUnit<SpecificEnergy>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.JoulesPerKilogram"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly SpecificEnergyUnit JoulesPerKilogram = new SpecificEnergyUnit(1.0, "J/kg");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public SpecificEnergyUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.JoulesPerKilogram"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static SpecificEnergy operator *(double left, SpecificEnergyUnit right)
        {
            return SpecificEnergy.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.JoulesPerKilogram"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from JoulesPerKilogram.
        /// </summary>
        /// <param name="value">The value in JoulesPerKilogram</param>
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
        public SpecificEnergy CreateQuantity(double value)
        {
            return new SpecificEnergy(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(SpecificEnergy quantity)
        {
            return FromSiUnit(quantity.joulesPerKilogram);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), JoulesPerKilogram.Symbol);
        }
    }
}