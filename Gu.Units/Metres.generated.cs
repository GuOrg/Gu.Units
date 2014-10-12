
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Metres : ILengthUnit
    {
        internal const string _symbol = "m";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Length operator *(double left, Metres right)
        {
            return new Length(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Metres"/> value to <see cref="T:Gu.Units.Metres"/>.
        /// </summary>
        /// <param name="metres"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double metres)
        {
            return 1 * metres;
        }
    }
}