namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.VoltageUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct VoltageUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Volts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Volts = new VoltageUnit(1.0, "V");
        /// <summary>
        /// The <see cref="T:Gu.Units.Volts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit V = Volts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millivolts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Millivolts = new VoltageUnit(0.001, "mV");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millivolts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit mV = Millivolts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilovolts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Kilovolts = new VoltageUnit(1000, "kV");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilovolts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit kV = Kilovolts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megavolts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Megavolts = new VoltageUnit(1000000, "MV");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megavolts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit MV = Megavolts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microvolts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Microvolts = new VoltageUnit(1E-06, "µV");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microvolts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit µV = Microvolts;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public VoltageUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Volts"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Voltage operator *(double left, VoltageUnit right)
        {
            return Voltage.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Volts"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Volts.
        /// </summary>
        /// <param name="value">The value in Volts</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Volts.Symbol);
        }
    }
}