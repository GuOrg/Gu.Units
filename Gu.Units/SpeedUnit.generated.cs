namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.SpeedUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(SpeedUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{MetresPerSecond.symbol}")]
    public struct SpeedUnit : IUnit, IUnit<Speed>, IEquatable<SpeedUnit>
    {
        /// <summary>
        /// The MetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerSecond = new SpeedUnit(1.0, "m/s");

        /// <summary>
        /// The MillimetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit MillimetresPerSecond = new SpeedUnit(0.001, "mm/s");

        /// <summary>
        /// The CentimetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit CentimetresPerSecond = new SpeedUnit(0.01, "cm/s");

        /// <summary>
        /// The KilometresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit KilometresPerHour = new SpeedUnit(0.27777777777777779, "km/h");

        /// <summary>
        /// The CentimetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit CentimetresPerMinute = new SpeedUnit(0.00016666666666666666, "cm/min");

        /// <summary>
        /// The MetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit MetresPerMinute = new SpeedUnit(0.016666666666666666, "m/min");

        /// <summary>
        /// The MetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit MetresPerHour = new SpeedUnit(0.00027777777777777778, "m/h");

        /// <summary>
        /// The MillimetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit MillimetresPerHour = new SpeedUnit(2.7777777777777776E-07, "mm/h");

        /// <summary>
        /// The CentimetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit CentimetresPerHour = new SpeedUnit(2.7777777777777779E-06, "cm/h");

        /// <summary>
        /// The MillimetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly SpeedUnit MillimetresPerMinute = new SpeedUnit(1.6666666666666667E-05, "mm/min");

        private readonly double conversionFactor;
        private readonly string symbol;

        public SpeedUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SpeedUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SpeedUnit"/>
        /// </summary>
        public SpeedUnit SiUnit => SpeedUnit.MetresPerSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SpeedUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => SpeedUnit.MetresPerSecond;

        public static Speed operator *(double left, SpeedUnit right)
        {
            return Speed.From(left, right);
        }

        public static bool operator ==(SpeedUnit left, SpeedUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SpeedUnit left, SpeedUnit right)
        {
            return !left.Equals(right);
        }

        public static SpeedUnit Parse(string text)
        {
            return UnitParser<SpeedUnit>.Parse(text);
        }

        public static bool TryParse(string text, out SpeedUnit value)
        {
            return UnitParser<SpeedUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerSecond.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerSecond.
        /// </summary>
        /// <param name="value">The value in MetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Speed(value, this)</returns>
        public Speed CreateQuantity(double value)
        {
            return new Speed(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerSecond
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Speed quantity)
        {
            return FromSiUnit(quantity.metresPerSecond);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(SpeedUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SpeedUnit && Equals((SpeedUnit)obj);
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