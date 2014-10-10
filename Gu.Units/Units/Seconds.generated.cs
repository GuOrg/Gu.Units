
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Seconds : ITimeUnit
    {
        private const double _conversionFactor = 1;
        internal const string _symbol = "s";

        public double ConversionFactor
        {
            get
            {
                return _conversionFactor;
            }
        }

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Time operator *(double left, Seconds right)
        {
            return new Time(left, right);
        }
    }
}