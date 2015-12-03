namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.ResistanceUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(ResistanceUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Ohm.symbol}")]
    public struct ResistanceUnit : IUnit, IUnit<Resistance>, IEquatable<ResistanceUnit>
    {
        /// <summary>
        /// The Ohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Ohm = new ResistanceUnit(1.0, "Ω");

        /// <summary>
        /// The Ohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit Ω = Ohm;

        /// <summary>
        /// The Microohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit Microohm = new ResistanceUnit(1E-06, "µΩ");

        /// <summary>
        /// The Microohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit µΩ = Microohm;

        /// <summary>
        /// The Milliohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit Milliohm = new ResistanceUnit(0.001, "mΩ");

        /// <summary>
        /// The Milliohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit mΩ = Milliohm;

        /// <summary>
        /// The Kiloohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit Kiloohm = new ResistanceUnit(1000, "kΩ");

        /// <summary>
        /// The Kiloohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit kΩ = Kiloohm;

        /// <summary>
        /// The Megaohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit Megaohm = new ResistanceUnit(1000000, "MΩ");

        /// <summary>
        /// The Megaohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ResistanceUnit MΩ = Megaohm;

        private readonly double conversionFactor;
        private readonly string symbol;

        public ResistanceUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.ResistanceUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ResistanceUnit"/>
        /// </summary>
        public ResistanceUnit SiUnit => ResistanceUnit.Ohm;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ResistanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => ResistanceUnit.Ohm;

        public static Resistance operator *(double left, ResistanceUnit right)
        {
            return Resistance.From(left, right);
        }

        public static bool operator ==(ResistanceUnit left, ResistanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ResistanceUnit left, ResistanceUnit right)
        {
            return !left.Equals(right);
        }

        public static ResistanceUnit Parse(string text)
        {
            return UnitParser<ResistanceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out ResistanceUnit value)
        {
            return UnitParser<ResistanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Ohm.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Ohm.
        /// </summary>
        /// <param name="value">The value in Ohm</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Resistance(value, this)</returns>
        public Resistance CreateQuantity(double value)
        {
            return new Resistance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Ohm
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Resistance quantity)
        {
            return FromSiUnit(quantity.ohm);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(ResistanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ResistanceUnit && Equals((ResistanceUnit)obj);
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