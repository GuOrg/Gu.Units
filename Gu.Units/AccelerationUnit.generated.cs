namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AccelerationUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(AccelerationUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{MetresPerSecondSquared.symbol}")]
    public struct AccelerationUnit : IUnit, IUnit<Acceleration>, IEquatable<AccelerationUnit>
    {
        /// <summary>
        /// The MetresPerSecondSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MetresPerSecondSquared = new AccelerationUnit(1.0, "m/s²");

        /// <summary>
        /// The MillimetresPerSecondSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AccelerationUnit MillimetresPerSecondSquared = new AccelerationUnit(0.001, "mm/s²");

        /// <summary>
        /// The CentimetresPerSecondSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AccelerationUnit CentimetresPerSecondSquared = new AccelerationUnit(0.01, "cm/s²");

        private readonly double conversionFactor;
        private readonly string symbol;

        public AccelerationUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AccelerationUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AccelerationUnit"/>
        /// </summary>
        public AccelerationUnit SiUnit => AccelerationUnit.MetresPerSecondSquared;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AccelerationUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => AccelerationUnit.MetresPerSecondSquared;

        public static Acceleration operator *(double left, AccelerationUnit right)
        {
            return Acceleration.From(left, right);
        }

        public static bool operator ==(AccelerationUnit left, AccelerationUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AccelerationUnit left, AccelerationUnit right)
        {
            return !left.Equals(right);
        }

        public static AccelerationUnit Parse(string text)
        {
            return UnitParser<AccelerationUnit>.Parse(text);
        }

        public static bool TryParse(string text, out AccelerationUnit value)
        {
            return UnitParser<AccelerationUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerSecondSquared.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerSecondSquared.
        /// </summary>
        /// <param name="value">The value in MetresPerSecondSquared</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Acceleration(value, this)</returns>
        public Acceleration CreateQuantity(double value)
        {
            return new Acceleration(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerSecondSquared
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Acceleration quantity)
        {
            return FromSiUnit(quantity.metresPerSecondSquared);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AccelerationUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AccelerationUnit && Equals((AccelerationUnit)obj);
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