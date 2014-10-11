
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Centimeters : ILengthUnit
    {
        internal const string _symbol = "cm";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Length operator *(double left, Centimeters right)
        {
            return new Length(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Centimeters"/> value to <see cref="T:Gu.Units.Meters"/>.
        /// </summary>
        /// <param name="length"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double length)
        {
            return 100 * length;
        }
    }
}