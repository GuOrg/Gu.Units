namespace Gu.Units
{
    using System;

    [Serializable]
    public struct FrequencyUnit : IUnit
    {
        public static readonly FrequencyUnit Hertz = new FrequencyUnit(1.0, "Hz");
        public static readonly FrequencyUnit Hz = Hertz;

        public static readonly FrequencyUnit Millihertz = new FrequencyUnit(0.001, "mHz");
        public static readonly FrequencyUnit mHz = Millihertz;

        public static readonly FrequencyUnit Kilohertz = new FrequencyUnit(1000, "kHz");
        public static readonly FrequencyUnit kHz = Kilohertz;

        public static readonly FrequencyUnit Megahertz = new FrequencyUnit(1000000, "MHz");
        public static readonly FrequencyUnit MHz = Megahertz;

        public static readonly FrequencyUnit Gigahertz = new FrequencyUnit(1000000000, "GHz");
        public static readonly FrequencyUnit GHz = Gigahertz;


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public FrequencyUnit(double conversionFactor, string symbol)
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

        public static Frequency operator *(double left, FrequencyUnit right)
        {
            return Frequency.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Frequency "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Hertz "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Hertz.Symbol);
        }
    }
}
