
namespace Gu.Units
{
    using System;

    [Serializable]
    public struct FrequencyUnit : IUnit
    {
        public static readonly FrequencyUnit Herts = new FrequencyUnit(1.0, "Hz");
        public static readonly FrequencyUnit Hz = Herts;

        public static readonly FrequencyUnit Kiloherts = new FrequencyUnit(1000, "kHz");
        public static readonly FrequencyUnit kHz = Kiloherts;

        public static readonly FrequencyUnit Megaherts = new FrequencyUnit(1000000, "MHz");
        public static readonly FrequencyUnit MHz = Megaherts;

        public static readonly FrequencyUnit Gigaherts = new FrequencyUnit(1000000000, "GHz");
        public static readonly FrequencyUnit GHz = Gigaherts;

        public static readonly FrequencyUnit Milliherts = new FrequencyUnit(0.001, "mHz");
        public static readonly FrequencyUnit mHz = Milliherts;


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
        /// Converts a value to <see cref="T:Gu.Units.Herts "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Herts.Symbol);
        }
    }
}
