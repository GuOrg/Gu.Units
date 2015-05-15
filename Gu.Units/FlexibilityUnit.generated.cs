namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.FlexibilityUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct FlexibilityUnit : IUnit, IUnit<Flexibility>, IEquatable<FlexibilityUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerNewton"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MetresPerNewton = new FlexibilityUnit(1.0, "m/N");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerNewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerNewton = new FlexibilityUnit(0.001, "mm/N");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerKilonewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerKilonewton = new FlexibilityUnit(1E-06, "mm/kN");

        /// <summary>
        /// The <see cref="T:Gu.Units.MicrometresPerKilonewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MicrometresPerKilonewton = new FlexibilityUnit(1E-09, "µm/kN");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public FlexibilityUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Flexibility operator *(double left, FlexibilityUnit right)
        {
            return Flexibility.From(left, right);
        }

        public static bool operator ==(FlexibilityUnit left, FlexibilityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FlexibilityUnit left, FlexibilityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerNewton.
        /// </summary>
        /// <param name="value">The value in MetresPerNewton</param>
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
        public Flexibility CreateQuantity(double value)
        {
            return new Flexibility(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Flexibility quantity)
        {
            return FromSiUnit(quantity.metresPerNewton);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), MetresPerNewton.Symbol);
        }

        public bool Equals(FlexibilityUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is FlexibilityUnit && Equals((FlexibilityUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}