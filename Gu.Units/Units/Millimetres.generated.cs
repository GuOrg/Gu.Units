
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Millimetres : ILengthUnit
    {
        internal const string _symbol = "mm";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Length operator *(double left, Millimetres right)
        {
            return new Length(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Millimetres"/> value to <see cref="T:Gu.Units.Metres"/>.
        /// </summary>
        /// <param name="millimetres"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double millimetres)
        {
            return 1e-3 * millimetres;
        }
    }
}