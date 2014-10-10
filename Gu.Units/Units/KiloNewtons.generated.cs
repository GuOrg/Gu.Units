
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct KiloNewtons : IForceUnit
    {
        private const double _conversionFactor = 1e-3;
        internal const string _symbol = "kN";

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

        public static Force operator *(double left, KiloNewtons right)
        {
            return new Force(left, right);
        }
    }
}