
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Hours : ITimeUnit
    {
        private const double _conversionFactor = 1 / 60.0;
        internal const string _symbol = "h";

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

        public static Time operator *(double left, Hours right)
        {
            return new Time(left, right);
        }
    }
}