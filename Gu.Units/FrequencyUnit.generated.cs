namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.FrequencyUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(FrequencyUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Hertz.symbol}")]
    public struct FrequencyUnit : IUnit, IUnit<Frequency>, IEquatable<FrequencyUnit>
    {
        /// <summary>
        /// The Hertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Hertz = new FrequencyUnit(1.0, "Hz");

        /// <summary>
        /// The Hertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit Hz = Hertz;

        /// <summary>
        /// The Millihertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit Millihertz = new FrequencyUnit(0.001, "mHz");

        /// <summary>
        /// The Millihertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit mHz = Millihertz;

        /// <summary>
        /// The Kilohertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit Kilohertz = new FrequencyUnit(1000, "kHz");

        /// <summary>
        /// The Kilohertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit kHz = Kilohertz;

        /// <summary>
        /// The Megahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit Megahertz = new FrequencyUnit(1000000, "MHz");

        /// <summary>
        /// The Megahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit MHz = Megahertz;

        /// <summary>
        /// The Gigahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit Gigahertz = new FrequencyUnit(1000000000, "GHz");

        /// <summary>
        /// The Gigahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly FrequencyUnit GHz = Gigahertz;

        private readonly double conversionFactor;
        private readonly string symbol;

        public FrequencyUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.FrequencyUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.FrequencyUnit"/>
        /// </summary>
        public FrequencyUnit SiUnit => FrequencyUnit.Hertz;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.FrequencyUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => FrequencyUnit.Hertz;

        public static Frequency operator *(double left, FrequencyUnit right)
        {
            return Frequency.From(left, right);
        }

        public static bool operator ==(FrequencyUnit left, FrequencyUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FrequencyUnit left, FrequencyUnit right)
        {
            return !left.Equals(right);
        }

        public static FrequencyUnit Parse(string text)
        {
            return UnitParser<FrequencyUnit>.Parse(text);
        }

        public static bool TryParse(string text, out FrequencyUnit value)
        {
            return UnitParser<FrequencyUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Hertz.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Hertz.
        /// </summary>
        /// <param name="value">The value in Hertz</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Frequency(value, this)</returns>
        public Frequency CreateQuantity(double value)
        {
            return new Frequency(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Hertz
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Frequency quantity)
        {
            return FromSiUnit(quantity.hertz);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(FrequencyUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is FrequencyUnit && Equals((FrequencyUnit)obj);
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