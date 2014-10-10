
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Centimeters : ILengthUnit
    {
        private const double _conversionFactor = 100;
        internal const string _symbol = "cm";

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

        public static Length operator *(double left, Centimeters right)
        {
            return new Length(left, right);
        }
    }
}