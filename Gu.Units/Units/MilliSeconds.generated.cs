
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct MilliSeconds : ITimeUnit
    {
        private const double _conversionFactor = 1000;
        internal const string _symbol = "ms";

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

        public static Time operator *(double left, MilliSeconds right)
        {
            return new Time(left, right);
        }
    }
}