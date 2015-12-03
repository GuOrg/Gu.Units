namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MassUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(MassUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Kilograms.symbol}")]
    public struct MassUnit : IUnit, IUnit<Mass>, IEquatable<MassUnit>
    {
        /// <summary>
        /// The Kilograms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Kilograms = new MassUnit(1.0, "kg");

        /// <summary>
        /// The Kilograms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit kg = Kilograms;

        /// <summary>
        /// The Grams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit Grams = new MassUnit(0.001, "g");

        /// <summary>
        /// The Grams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit g = Grams;

        /// <summary>
        /// The Milligrams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit Milligrams = new MassUnit(1E-06, "mg");

        /// <summary>
        /// The Milligrams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit mg = Milligrams;

        /// <summary>
        /// The Micrograms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly MassUnit Micrograms = new MassUnit(1E-09, "µg");

        /// <summary>
        /// The Micrograms unit
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
        /// The symbol for the <see cref="Gu.Units.MassUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.MassUnit"/>
        /// </summary>
        public MassUnit SiUnit => MassUnit.Kilograms;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.MassUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MassUnit.Kilograms;

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
            return UnitParser<MassUnit>.Parse(text);
        }

        public static bool TryParse(string text, out MassUnit value)
        {
            return UnitParser<MassUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Kilograms.
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
        /// <returns>new Mass(value, this)</returns>
        public Mass CreateQuantity(double value)
        {
            return new Mass(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Kilograms
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