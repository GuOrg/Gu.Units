
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Hours : ITimeUnit
    {
        private const double _conversionFactor = 1 / 60.0;
        internal const string _name = "h";

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

        public static Time operator *(double left, Hours right)
        {
            return new Time(left, right);
        }
    }
}