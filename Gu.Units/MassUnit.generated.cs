namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.MassUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Kilograms.symbol}")]
    public struct MassUnit : IUnit, IUnit<Mass>, IEquatable<MassUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilograms"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Kilograms = new MassUnit(1.0, "kg");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilograms"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit kg = Kilograms;

        /// <summary>
        /// The <see cref="T:Gu.Units.Grams"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit Grams = new MassUnit(0.001, "g");
        /// <summary>
        /// The <see cref="T:Gu.Units.Grams"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit g = Grams;

        /// <summary>
        /// The <see cref="T:Gu.Units.Milligrams"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit Milligrams = new MassUnit(1E-06, "mg");
        /// <summary>
        /// The <see cref="T:Gu.Units.Milligrams"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit mg = Milligrams;

        /// <summary>
        /// The <see cref="T:Gu.Units.Micrograms"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit Micrograms = new MassUnit(1E-09, "µg");
        /// <summary>
        /// The <see cref="T:Gu.Units.Micrograms"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit µg = Micrograms;

        private readonly double conversionFactor;
        private readonly string symbol;

        public MassUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Mass operator *(double left, MassUnit right)
        {
            return Mass.From(left, right);
        }

        public static bool operator ==(MassUnit left, MassUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MassUnit left, MassUnit right)
        {
            return !left.Equals(right);
        }

        public static MassUnit Parse(string text)
        {
            return Parser.ParseUnit<MassUnit>(text);
        }

        public static bool TryParse(string text, out MassUnit value)
        {
            return Parser.TryParseUnit<MassUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Kilograms.
        /// </summary>
        /// <param name="value">The value in Kilograms</param>
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
        public Mass CreateQuantity(double value)
        {
            return new Mass(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Mass quantity)
        {
            return FromSiUnit(quantity.kilograms);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(MassUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MassUnit && Equals((MassUnit)obj);
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