
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Millimeters : ILengthUnit
    {
        private const double _conversionFactor = 1000;
        internal const string _symbol = "mm";

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

        public static Length operator *(double left, Millimeters right)
        {
            return new Length(left, right);
        }
    }
}