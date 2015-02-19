namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.CapacitanceUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct CapacitanceUnit : IUnit, IUnit<Capacitance>
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

        public Capacitance Create(double value)
        {
            return new Capacitance(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Farads.Symbol);
        }
    }
}