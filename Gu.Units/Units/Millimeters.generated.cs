
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Millimeters : ILengthUnit
    {
        internal const string _symbol = "mm";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Length operator *(double left, Millimeters right)
        {
            return new Length(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Millimeters"/> value to <see cref="T:Gu.Units.Meters"/>.
        /// </summary>
        /// <param name="millimeters"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double millimeters)
        {
            return 1e-3 * millimeters;
        }
    }
}