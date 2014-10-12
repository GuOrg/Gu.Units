
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Milliseconds : ITimeUnit
    {
        internal const string _symbol = "ms";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Time operator *(double left, Milliseconds right)
        {
            return new Time(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Milliseconds"/> value to <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double milliseconds)
        {
            return 1e-3 * milliseconds;
        }
    }
}