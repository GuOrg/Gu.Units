
namespace GeneratorBox
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Newtons : IForceUnit
    {
        private const double _conversionFactor = 1;
        internal const string _name = "N";

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

        public static Force operator *(double left, Newtons right)
        {
            return new Force(left, right);
        }
    }
}