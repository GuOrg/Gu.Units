
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Newtons : IForceUnit
    {
        private const double _conversionFactor = 1;
        internal const string _symbol = "N";

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

        public static Force operator *(double left, Newtons right)
        {
            return new Force(left, right);
        }
    }
}