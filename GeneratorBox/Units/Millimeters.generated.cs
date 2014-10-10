
namespace GeneratorBox
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Millimeters : ILengthUnit
    {
        private const double _conversionFactor = 1000;
        internal const string _name = "mm";

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

        public static Length operator *(double left, Millimeters right)
        {
            return new Length(left, right);
        }
    }
}