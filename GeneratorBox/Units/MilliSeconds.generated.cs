
namespace GeneratorBox
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct MilliSeconds : ITimeUnit
    {
        private const double _conversionFactor = 1000;
        internal const string _name = "ms";

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

        public static Time operator *(double left, MilliSeconds right)
        {
            return new Time(left, right);
        }
    }
}