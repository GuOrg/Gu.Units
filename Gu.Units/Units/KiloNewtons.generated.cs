
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct KiloNewtons : IForceUnit
    {
        internal const string _symbol = "kN";

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

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.KiloNewtons"/> value to <see cref="T:Gu.Units.Newtons"/>.
        /// </summary>
        /// <param name="kiloNewtons"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double kiloNewtons)
        {
            return 1e3 * kiloNewtons;
        }
    }
}