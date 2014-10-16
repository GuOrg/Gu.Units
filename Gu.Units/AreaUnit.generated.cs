namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AreaUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct AreaUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.SquareMetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMetres = new AreaUnit(1.0, "m²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareMillimetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMillimetres = new AreaUnit(1E-06, "mm²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareCentimetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareCentimetres = new AreaUnit(0.0001, "cm²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareDecimetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareDecimetres = new AreaUnit(0.01, "dm²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareKilometres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareKilometres = new AreaUnit(1000000, "km²");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AreaUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.SquareMetres"/>.
        /// </summary>
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
        /// Converts a value to <see cref="T:Gu.Units.SquareMetres"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from SquareMetres.
        /// </summary>
        /// <param name="value">The value in SquareMetres</param>
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