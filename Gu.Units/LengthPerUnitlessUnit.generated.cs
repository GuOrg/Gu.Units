namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.LengthPerUnitlessUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(LengthPerUnitlessUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{MetresPerUnitless.symbol}")]
    public struct LengthPerUnitlessUnit : IUnit, IUnit<LengthPerUnitless>, IEquatable<LengthPerUnitlessUnit>
    {
        /// <summary>
        /// The MetresPerUnitless unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthPerUnitlessUnit MetresPerUnitless = new LengthPerUnitlessUnit(1.0, "m/ul");

        /// <summary>
        /// The MillimetresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthPerUnitlessUnit MillimetresPerPercent = new LengthPerUnitlessUnit(0.1, "mm/%");

        /// <summary>
        /// The MicrometresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthPerUnitlessUnit MicrometresPerPercent = new LengthPerUnitlessUnit(9.9999999999999991E-05, "µm/%");

        /// <summary>
        /// The NanometresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthPerUnitlessUnit NanometresPerPercent = new LengthPerUnitlessUnit(1.0000000000000001E-07, "nm/%");

        /// <summary>
        /// The MetresPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LengthPerUnitlessUnit MetresPerPercent = new LengthPerUnitlessUnit(100, "m/%");

        private readonly double conversionFactor;
        private readonly string symbol;

        public LengthPerUnitlessUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.LengthPerUnitlessUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.LengthPerUnitlessUnit"/>
        /// </summary>
        public LengthPerUnitlessUnit SiUnit => LengthPerUnitlessUnit.MetresPerUnitless;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.LengthPerUnitlessUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => LengthPerUnitlessUnit.MetresPerUnitless;

        public static LengthPerUnitless operator *(double left, LengthPerUnitlessUnit right)
        {
            return LengthPerUnitless.From(left, right);
        }

        public static bool operator ==(LengthPerUnitlessUnit left, LengthPerUnitlessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LengthPerUnitlessUnit left, LengthPerUnitlessUnit right)
        {
            return !left.Equals(right);
        }

        public static LengthPerUnitlessUnit Parse(string text)
        {
            return UnitParser<LengthPerUnitlessUnit>.Parse(text);
        }

        public static bool TryParse(string text, out LengthPerUnitlessUnit value)
        {
            return UnitParser<LengthPerUnitlessUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerUnitless.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerUnitless.
        /// </summary>
        /// <param name="value">The value in MetresPerUnitless</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new LengthPerUnitless(value, this)</returns>
        public LengthPerUnitless CreateQuantity(double value)
        {
            return new LengthPerUnitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerUnitless
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(LengthPerUnitless quantity)
        {
            return FromSiUnit(quantity.metresPerUnitless);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(LengthPerUnitlessUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LengthPerUnitlessUnit && Equals((LengthPerUnitlessUnit)obj);
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