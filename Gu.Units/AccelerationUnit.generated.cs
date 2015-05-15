namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AccelerationUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct AccelerationUnit : IUnit, IUnit<Acceleration>, IEquatable<AccelerationUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerSecondSquared"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MetresPerSecondSquared = new AccelerationUnit(1.0, "m/s²");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerSecondSquared"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MillimetresPerSecondSquared = new AccelerationUnit(1E-06, "mm/s²");

        /// <summary>
        /// The <see cref="T:Gu.Units.CentimetresPerSecondSquared"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit CentimetresPerSecondSquared = new AccelerationUnit(0.0001, "cm/s²");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public AccelerationUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.MetresPerSecondSquared"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

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

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.MetresPerSecondSquared"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerSecondSquared.
        /// </summary>
        /// <param name="value">The value in MetresPerSecondSquared</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public Acceleration CreateQuantity(double value)
        {
            return new Acceleration(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Acceleration quantity)
        {
            return FromSiUnit(quantity.metresPerSecondSquared);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), MetresPerSecondSquared.Symbol);
        }

        public bool Equals(AccelerationUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is AccelerationUnit && Equals((AccelerationUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}