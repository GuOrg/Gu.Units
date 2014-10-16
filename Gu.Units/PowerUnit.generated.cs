namespace Gu.Units
{
    using System;

    [Serializable]
    public struct PowerUnit : IUnit
    {
        public static readonly PowerUnit Watts = new PowerUnit(1.0, "W");
        public static readonly PowerUnit W = Watts;

        public static readonly PowerUnit Nanowatts = new PowerUnit(1E-09, "nW");
        public static readonly PowerUnit nW = Nanowatts;

        public static readonly PowerUnit Microwatts = new PowerUnit(1E-06, "µW");
        public static readonly PowerUnit µW = Microwatts;

        public static readonly PowerUnit Milliwatts = new PowerUnit(0.001, "mW");
        public static readonly PowerUnit mW = Milliwatts;

        public static readonly PowerUnit Kilowatts = new PowerUnit(1000, "kW");
        public static readonly PowerUnit kW = Kilowatts;

        public static readonly PowerUnit Megawatts = new PowerUnit(1000000, "MW");
        public static readonly PowerUnit MW = Megawatts;

        public static readonly PowerUnit Gigawatts = new PowerUnit(1000000000, "GW");
        public static readonly PowerUnit GW = Gigawatts;


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public PowerUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

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
        /// Converts a value to <see cref="T:Gu.Units.Power "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Watts "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Watts.Symbol);
        }
    }
}
