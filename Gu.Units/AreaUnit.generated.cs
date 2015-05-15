namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AreaUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct AreaUnit : IUnit, IUnit<Area>, IEquatable<AreaUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.SquareMetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMetres = new AreaUnit(1.0, "m²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareMillimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMillimetres = new AreaUnit(1E-06, "mm²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareCentimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareCentimetres = new AreaUnit(0.0001, "cm²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareDecimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareDecimetres = new AreaUnit(0.010000000000000002, "dm²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareKilometres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareKilometres = new AreaUnit(1000000, "km²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareInches"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareInches = new AreaUnit(0.00064516, "in²");

        /// <summary>
        /// The <see cref="T:Gu.Units.Hectare"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit Hectare = new AreaUnit(10000, "ha");
        /// <summary>
        /// The <see cref="T:Gu.Units.Hectare"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit ha = Hectare;

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareMile"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMile = new AreaUnit(2589988.110336, "mi²");

        /// <summary>
        /// The <see cref="T:Gu.Units.SquareYard"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareYard = new AreaUnit(0.83612736, "yd²");

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

        public static bool operator ==(AreaUnit left, AreaUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AreaUnit left, AreaUnit right)
        {
            return !left.Equals(right);
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

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public Area CreateQuantity(double value)
        {
            return new Area(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Area quantity)
        {
            return FromSiUnit(quantity.squareMetres);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), SquareMetres.Symbol);
        }

        public bool Equals(AreaUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is AreaUnit && Equals((AreaUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}