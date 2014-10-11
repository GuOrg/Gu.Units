
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Grams : IMassUnit
    {
        internal const string _symbol = "g";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Mass operator *(double left, Grams right)
        {
            return new Mass(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Grams"/> value to <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        /// <param name="grams"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double grams)
        {
            return 1e-3 * grams;
        }
    }
}