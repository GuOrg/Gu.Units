
namespace GeneratorBox
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Seconds : ITimeUnit
    {
        private const double _conversionFactor = 1;
        internal const string _name = "s";

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

        public static Time operator *(double left, Seconds right)
        {
            return new Time(left, right);
        }
    }
}