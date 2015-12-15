namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Area"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AreaUnitTypeConverter))]
    public struct AreaUnit : IUnit, IUnit<Area>, IEquatable<AreaUnit>
    {
        /// <summary>
        /// The AreaUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMetres = new AreaUnit(squareMetres => squareMetres, squareMetres => squareMetres, "m²");

        /// <summary>
        /// The Hectare unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit Hectare = new AreaUnit(hectare => 10000 * hectare, squareMetres => squareMetres / 10000, "ha");

        /// <summary>
        /// The SquareMillimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMillimetres = new AreaUnit(squareMillimetres => squareMillimetres / 1000000, squareMetres => 1000000 * squareMetres, "mm²");

        /// <summary>
        /// The SquareCentimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareCentimetres = new AreaUnit(squareCentimetres => squareCentimetres / 10000, squareMetres => 10000 * squareMetres, "cm²");

        /// <summary>
        /// The SquareDecimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareDecimetres = new AreaUnit(squareDecimetres => squareDecimetres / 100, squareMetres => 100 * squareMetres, "dm²");

        /// <summary>
        /// The SquareKilometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareKilometres = new AreaUnit(squareKilometres => 1000000 * squareKilometres, squareMetres => squareMetres / 1000000, "km²");

        /// <summary>
        /// The SquareMile unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareMile = new AreaUnit(squareMile => 2589988.110336 * squareMile, squareMetres => squareMetres / 2589988.110336, "mi²");

        /// <summary>
        /// The SquareYard unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareYard = new AreaUnit(squareYard => 0.83612736 * squareYard, squareMetres => squareMetres / 0.83612736, "yd²");

        /// <summary>
        /// The SquareInches unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AreaUnit SquareInches = new AreaUnit(squareInches => 0.00064516 * squareInches, squareMetres => squareMetres / 0.00064516, "in²");

        private readonly Func<double, double> toSquareMetres;
        private readonly Func<double, double> fromSquareMetres;
        internal readonly string symbol;

        public AreaUnit(Func<double, double> toSquareMetres, Func<double, double> fromSquareMetres, string symbol)
        {
            this.toSquareMetres = toSquareMetres;
            this.fromSquareMetres = fromSquareMetres;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AreaUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AreaUnit"/>
        /// </summary>
        public AreaUnit SiUnit => SquareMetres;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AreaUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => SquareMetres;

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
        /// Constructs a <see cref="AreaUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AreaUnit"/></returns>
        public static AreaUnit Parse(string text)
        {
            return UnitParser<AreaUnit>.Parse(text);
        }

        public static bool TryParse(string text, out AreaUnit value)
        {
            return UnitParser<AreaUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to SquareMetres.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSquareMetres(value);
        }

        /// <summary>
        /// Converts a value from squareMetres.
        /// </summary>
        /// <param name="SquareMetres">The value in SquareMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double squareMetres)
        {
            return this.fromSquareMetres(squareMetres);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Area(<paramref name="value"/>, this)</returns>
        public Area CreateQuantity(double value)
        {
            return new Area(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in SquareMetres
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

        public string ToString(string format)
        {
            AreaUnit unit;
            var paddedFormat = UnitFormatCache<AreaUnit>.GetOrCreate(format, out unit);
            if (unit != this)
            {
                return format;
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<AreaUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
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

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
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