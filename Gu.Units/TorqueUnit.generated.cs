namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.TorqueUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct TorqueUnit : IUnit, IUnit<Torque>, IEquatable<TorqueUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.NewtonMetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly TorqueUnit NewtonMetres = new TorqueUnit(1.0, "N⋅m");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public TorqueUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.NewtonMetres"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Torque operator *(double left, TorqueUnit right)
        {
            return Torque.From(left, right);
        }

        public static bool operator ==(TorqueUnit left, TorqueUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TorqueUnit left, TorqueUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.NewtonMetres"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from NewtonMetres.
        /// </summary>
        /// <param name="value">The value in NewtonMetres</param>
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
        public Torque CreateQuantity(double value)
        {
            return new Torque(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Torque quantity)
        {
            return FromSiUnit(quantity.newtonMetres);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), NewtonMetres.Symbol);
        }

        public bool Equals(TorqueUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TorqueUnit && Equals((TorqueUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}