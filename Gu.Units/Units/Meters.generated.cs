
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Meters : ILengthUnit
    {
        private const double _conversionFactor = 1;
        internal const string _name = "m";

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

        public static Length operator *(double left, Meters right)
        {
            return new Length(left, right);
        }
    }
}