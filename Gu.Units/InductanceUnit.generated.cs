namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.InductanceUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct InductanceUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Henrys"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Henrys = new InductanceUnit(1.0, "H");
        /// <summary>
        /// The <see cref="T:Gu.Units.Henrys"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit H = Henrys;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public InductanceUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Henrys"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Inductance operator *(double left, InductanceUnit right)
        {
            return Inductance.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Henrys"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Henrys.
        /// </summary>
        /// <param name="value">The value in Henrys</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Henrys.Symbol);
        }
    }
}