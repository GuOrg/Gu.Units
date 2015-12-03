namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.UnitlessUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(UnitlessUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Scalar.symbol}")]
    public struct UnitlessUnit : IUnit, IUnit<Unitless>, IEquatable<UnitlessUnit>
    {
        /// <summary>
        /// The Scalar unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Scalar = new UnitlessUnit(1.0, "ul");

        /// <summary>
        /// The Scalar unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly UnitlessUnit ul = Scalar;

        /// <summary>
        /// The PartsPerMillion unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly UnitlessUnit PartsPerMillion = new UnitlessUnit(1E-06, "ppm");

        /// <summary>
        /// The PartsPerMillion unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly UnitlessUnit ppm = PartsPerMillion;

        /// <summary>
        /// The Promilles unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly UnitlessUnit Promilles = new UnitlessUnit(0.001, "‰");

        /// <summary>
        /// The Percents unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly UnitlessUnit Percents = new UnitlessUnit(0.01, "%");

        private readonly double conversionFactor;
        private readonly string symbol;

        public UnitlessUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.UnitlessUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.UnitlessUnit"/>
        /// </summary>
        public UnitlessUnit SiUnit => UnitlessUnit.Scalar;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.UnitlessUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => UnitlessUnit.Scalar;

        public static Unitless operator *(double left, UnitlessUnit right)
        {
            return Unitless.From(left, right);
        }

        public static bool operator ==(UnitlessUnit left, UnitlessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UnitlessUnit left, UnitlessUnit right)
        {
            return !left.Equals(right);
        }

        public static UnitlessUnit Parse(string text)
        {
            return UnitParser<UnitlessUnit>.Parse(text);
        }

        public static bool TryParse(string text, out UnitlessUnit value)
        {
            return UnitParser<UnitlessUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Scalar.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Scalar.
        /// </summary>
        /// <param name="value">The value in Scalar</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Unitless(value, this)</returns>
        public Unitless CreateQuantity(double value)
        {
            return new Unitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Scalar
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Unitless quantity)
        {
            return FromSiUnit(quantity.scalar);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(UnitlessUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnitlessUnit && Equals((UnitlessUnit)obj);
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