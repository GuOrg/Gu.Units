
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Centimetres : ILengthUnit
    {
        internal const string _symbol = "cm";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Length operator *(double left, Centimetres right)
        {
            return new Length(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Centimetres"/> value to <see cref="T:Gu.Units.Metres"/>.
        /// </summary>
        /// <param name="centimetres"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double centimetres)
        {
            return 1e-2 * centimetres;
        }
    }
}