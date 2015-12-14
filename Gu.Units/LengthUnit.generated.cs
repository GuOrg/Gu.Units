namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Length"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(LengthUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{LengthUnit.symbol}")]
    public struct LengthUnit : IUnit, IUnit<Length>, IEquatable<LengthUnit>
    {
        /// <summary>
        /// The LengthUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly LengthUnit Metres = new LengthUnit(metres => metres, metres => metres, "m");

        /// <summary>
        /// The Inches unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Inches = new LengthUnit(inches => 0.0254 * inches, metres => metres / 0.0254, "in");

        /// <summary>
        /// The Mile unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Mile = new LengthUnit(mile => 1609.344 * mile, metres => metres / 1609.344, "mi");

        /// <summary>
        /// The Yard unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Yard = new LengthUnit(yard => 0.9144 * yard, metres => metres / 0.9144, "yd");

        /// <summary>
        /// The NauticalMile unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit NauticalMile = new LengthUnit(nauticalMile => 1852 * nauticalMile, metres => metres / 1852, "nmi");

        /// <summary>
        /// The Nanometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Nanometres = new LengthUnit(nanometres => nanometres / 1000000000, metres => 1000000000 * metres, "nm");

        /// <summary>
        /// The Micrometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Micrometres = new LengthUnit(micrometres => micrometres / 1000000, metres => 1000000 * metres, "µm");

        /// <summary>
        /// The Millimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Millimetres = new LengthUnit(millimetres => millimetres / 1000, metres => 1000 * metres, "mm");

        /// <summary>
        /// The Centimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Centimetres = new LengthUnit(centimetres => centimetres / 100, metres => 100 * metres, "cm");

        /// <summary>
        /// The Decimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Decimetres = new LengthUnit(decimetres => decimetres / 10, metres => 10 * metres, "dm");

        /// <summary>
        /// The Kilometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Kilometres = new LengthUnit(kilometres => 1000 * kilometres, metres => metres / 1000, "km");

        private readonly Func<double, double> toMetres;
        private readonly Func<double, double> fromMetres;
        internal readonly string symbol;

        public LengthUnit(Func<double, double> toMetres, Func<double, double> fromMetres, string symbol)
        {
            this.toMetres = toMetres;
            this.fromMetres = fromMetres;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.LengthUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.LengthUnit"/>
        /// </summary>
        public LengthUnit SiUnit => Metres;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.LengthUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Metres;

        public static Length operator *(double left, LengthUnit right)
        {
            return Length.From(left, right);
        }

        public static bool operator ==(LengthUnit left, LengthUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LengthUnit left, LengthUnit right)
        {
            return !left.Equals(right);
        }

        public static LengthUnit Parse(string text)
        {
            return UnitParser<LengthUnit>.Parse(text);
        }

        public static bool TryParse(string text, out LengthUnit value)
        {
            return UnitParser<LengthUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Metres.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetres(value);
        }

        /// <summary>
        /// Converts a value from Metres.
        /// </summary>
        /// <param name="value">The value in Metres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metres)
        {
            return this.fromMetres(metres);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Length(value, this)</returns>
        public Length CreateQuantity(double value)
        {
            return new Length(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in LengthUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Length quantity)
        {
            return FromSiUnit(quantity.metres);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(LengthUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LengthUnit && Equals((LengthUnit)obj);
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