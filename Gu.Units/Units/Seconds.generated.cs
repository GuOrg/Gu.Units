
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Seconds : ITimeUnit
    {
        internal const string _symbol = "s";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Time operator *(double left, Seconds right)
        {
            return new Time(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Seconds"/> value to <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double time)
        {
            return 1 * time;
        }
    }
}