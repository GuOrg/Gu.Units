
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Hours : ITimeUnit
    {
        internal const string _symbol = "h";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Time operator *(double left, Hours right)
        {
            return new Time(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Hours"/> value to <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double time)
        {
            return 3600 * time;
        }
    }
}