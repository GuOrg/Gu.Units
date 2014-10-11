
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public struct Newtons : IForceUnit
    {
        internal const string _symbol = "N";

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Force operator *(double left, Newtons right)
        {
            return new Force(left, right);
        }

        /// <summary>
        /// Converts a value in <see cref="T:Gu.Units.Newtons"/> value to <see cref="T:Gu.Units.Newtons"/>.
        /// </summary>
        /// <param name="force"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double force)
        {
            return 1 * force;
        }
    }
}