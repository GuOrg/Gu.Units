 
namespace GeneratorBox
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct KiloNewtons : IForceUnit
    {
        private const double _conversionFactor = ;
        internal const string _name = "kN";

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

        public static Force operator *(double left, KiloNewtons right)
        {
            return new Force(left, right);
        }
    }
}