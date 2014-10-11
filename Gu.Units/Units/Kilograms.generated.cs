
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Kilograms : IMassUnit
    {
        internal const string _symbol = "kg";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Mass operator *(double left, Kilograms right)
        {
            return new Mass(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Kilograms"/> value to <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        /// <param name="kilograms"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double kilograms)
        {
            return 1 * kilograms;
        }
    }
}