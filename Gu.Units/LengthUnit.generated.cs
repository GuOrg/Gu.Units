namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.LengthUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(LengthUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Metres.symbol}")]
    public struct LengthUnit : IUnit, IUnit<Length>, IEquatable<LengthUnit>
    {
        /// <summary>
        /// The Metres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Metres = new LengthUnit(1.0, "m");

        /// <summary>
        /// The Metres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit m = Metres;

        /// <summary>
        /// The Nanometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Nanometres = new LengthUnit(1E-09, "nm");

        /// <summary>
        /// The Nanometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit nm = Nanometres;

        /// <summary>
        /// The Micrometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Micrometres = new LengthUnit(1E-06, "µm");

        /// <summary>
        /// The Micrometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit µm = Micrometres;

        /// <summary>
        /// The Millimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Millimetres = new LengthUnit(0.001, "mm");

        /// <summary>
        /// The Millimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit mm = Millimetres;

        /// <summary>
        /// The Centimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Centimetres = new LengthUnit(0.01, "cm");

        /// <summary>
        /// The Centimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit cm = Centimetres;

        /// <summary>
        /// The Decimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Decimetres = new LengthUnit(0.1, "dm");

        /// <summary>
        /// The Decimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit dm = Decimetres;

        /// <summary>
        /// The Kilometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Kilometres = new LengthUnit(1000, "km");

        /// <summary>
        /// The Kilometres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit km = Kilometres;

        /// <summary>
        /// The Inches unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Inches = new LengthUnit(0.0254, "in");

        /// <summary>
        /// The Mile unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Mile = new LengthUnit(1609.344, "mi");

        /// <summary>
        /// The Mile unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit mi = Mile;

        /// <summary>
        /// The Yard unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit Yard = new LengthUnit(0.9144, "yd");

        /// <summary>
        /// The Yard unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit yd = Yard;

        /// <summary>
        /// The NauticalMile unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit NauticalMile = new LengthUnit(1852, "nmi");

        /// <summary>
        /// The NauticalMile unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthUnit nmi = NauticalMile;

        private readonly double conversionFactor;
        private readonly string symbol;

        public LengthUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.LengthUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.LengthUnit"/>
        /// </summary>
        public LengthUnit SiUnit => LengthUnit.Metres;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.LengthUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => LengthUnit.Metres;

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
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Metres.
        /// </summary>
        /// <param name="value">The value in Metres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
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
        /// Gets the scalar value of <paramref name="quantity"/> in Metres
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