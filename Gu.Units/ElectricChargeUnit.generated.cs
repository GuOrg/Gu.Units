namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.ElectricChargeUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct ElectricChargeUnit : IUnit, IUnit<ElectricCharge>, IEquatable<ElectricChargeUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Coulombs"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Coulombs = new ElectricChargeUnit(1.0, "C");
        /// <summary>
        /// The <see cref="T:Gu.Units.Coulombs"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit C = Coulombs;

        private readonly double conversionFactor;
        private readonly string symbol;

        public ElectricChargeUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Coulombs"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static ElectricCharge operator *(double left, ElectricChargeUnit right)
        {
            return ElectricCharge.From(left, right);
        }

        public static bool operator ==(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Coulombs"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Coulombs.
        /// </summary>
        /// <param name="value">The value in Coulombs</param>
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
        public ElectricCharge CreateQuantity(double value)
        {
            return new ElectricCharge(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(ElectricCharge quantity)
        {
            return FromSiUnit(quantity.coulombs);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", this.symbol, this.ToSiUnit(1), Coulombs.symbol);
        }

        public bool Equals(ElectricChargeUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ElectricChargeUnit && Equals((ElectricChargeUnit)obj);
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