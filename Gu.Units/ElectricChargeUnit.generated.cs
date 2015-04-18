namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.ElectricChargeUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct ElectricChargeUnit : IUnit, IUnit<ElectricCharge>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Coulombs"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Coulombs = new ElectricChargeUnit(1.0, "C");
        /// <summary>
        /// The <see cref="T:Gu.Units.Coulombs"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit C = Coulombs;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public ElectricChargeUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Coulombs"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static ElectricCharge operator *(double left, ElectricChargeUnit right)
        {
            return ElectricCharge.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Coulombs"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Coulombs.
        /// </summary>
        /// <param name="value">The value in Coulombs</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public ElectricCharge CreateQuantity(double value)
        {
            return new ElectricCharge(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Coulombs.Symbol);
        }
    }
}