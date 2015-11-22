namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AreaUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{SquareMetres.symbol}")]
    public struct AreaUnit : IUnit, IUnit<Area>, IEquatable<AreaUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.SquareMetres"/> unit
        /// Contains conversion logic to from and formatting.
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
        /// Contains conversion logic to from and formatting.
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

        private readonly double conversionFactor;
        private readonly string symbol;

        public AreaUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.SquareMetres"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
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

        public static AreaUnit Parse(string text)
        {
            return Parser.ParseUnit<AreaUnit>(text);
        }

        public static bool TryParse(string text, out AreaUnit value)
        {
            return Parser.TryParseUnit<AreaUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.SquareMetres"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from SquareMetres.
        /// </summary>
        /// <param name="value">The value in SquareMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
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
        public double GetScalarValue(Area quantity)
        {
            return FromSiUnit(quantity.squareMetres);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AreaUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AreaUnit && Equals((AreaUnit)obj);
        }

        public override int GetHashCode()
        {
            if (this.symbol == null)
            {
                return 0; // Needed due to default ctor
            }

            return this.symbol.GetHashCode();
        }
    }
}