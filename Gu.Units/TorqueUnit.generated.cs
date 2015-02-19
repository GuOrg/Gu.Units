namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.TorqueUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct TorqueUnit : IUnit, IUnit<Torque>
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

        public Torque Create(double value)
        {
            return new Torque(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), NewtonMetres.Symbol);
        }
    }
}