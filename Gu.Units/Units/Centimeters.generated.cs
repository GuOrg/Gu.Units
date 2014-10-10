
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Centimeters : ILengthUnit
    {
        private const double _conversionFactor = 100;
        internal const string _name = "cm";

        public double Conversionfactor
        {
            get
            {
                return _conversionFactor;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public static Length operator *(double left, Centimeters right)
        {
            return new Length(left, right);
        }
    }
}