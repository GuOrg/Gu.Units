namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.PowerUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct PowerUnit : IUnit, IUnit<Power>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Watts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Watts = new PowerUnit(1.0, "W");
        /// <summary>
        /// The <see cref="T:Gu.Units.Watts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit W = Watts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanowatts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Nanowatts = new PowerUnit(1E-09, "nW");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanowatts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit nW = Nanowatts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microwatts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Microwatts = new PowerUnit(1E-06, "µW");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microwatts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit µW = Microwatts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Milliwatts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Milliwatts = new PowerUnit(0.001, "mW");
        /// <summary>
        /// The <see cref="T:Gu.Units.Milliwatts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit mW = Milliwatts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilowatts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Kilowatts = new PowerUnit(1000, "kW");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilowatts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit kW = Kilowatts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megawatts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Megawatts = new PowerUnit(1000000, "MW");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megawatts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit MW = Megawatts;

        /// <summary>
        /// The <see cref="T:Gu.Units.Gigawatts"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Gigawatts = new PowerUnit(1000000000, "GW");
        /// <summary>
        /// The <see cref="T:Gu.Units.Gigawatts"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit GW = Gigawatts;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public PowerUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Watts"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Power operator *(double left, PowerUnit right)
        {
            return Power.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Watts"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Watts.
        /// </summary>
        /// <param name="value">The value in Watts</param>
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
        public Power CreateQuantity(double value)
        {
            return new Power(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Power quantity)
        {
            return FromSiUnit(quantity.watts);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Watts.Symbol);
        }
    }
}