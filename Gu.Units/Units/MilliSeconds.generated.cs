
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct MilliSeconds : ITimeUnit
    {
        internal const string _symbol = "ms";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Time operator *(double left, MilliSeconds right)
        {
            return new Time(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.MilliSeconds"/> value to <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double time)
        {
            return 1000 * time;
        }
    }
}