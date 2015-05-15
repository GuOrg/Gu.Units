namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.CapacitanceUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct CapacitanceUnit : IUnit, IUnit<Capacitance>, IEquatable<CapacitanceUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Farads"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Farads = new CapacitanceUnit(1.0, "F");
        /// <summary>
        /// The <see cref="T:Gu.Units.Farads"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit F = Farads;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public CapacitanceUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Farads"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Capacitance operator *(double left, CapacitanceUnit right)
        {
            return Capacitance.From(left, right);
        }

        public static bool operator ==(CapacitanceUnit left, CapacitanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CapacitanceUnit left, CapacitanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Farads"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Farads.
        /// </summary>
        /// <param name="value">The value in Farads</param>
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
        public Capacitance CreateQuantity(double value)
        {
            return new Capacitance(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Capacitance quantity)
        {
            return FromSiUnit(quantity.farads);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Farads.Symbol);
        }

        public bool Equals(CapacitanceUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CapacitanceUnit && Equals((CapacitanceUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}