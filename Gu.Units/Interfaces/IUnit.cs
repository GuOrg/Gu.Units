namespace Gu.Units
{
    public interface IUnit
    {
        /// <summary>
        /// Gets the default symbol
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Gets the base unit
        /// </summary>
        IUnit SiUnit { get; }

        /// <summary>
        /// Converts a value to the base unit.
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The converted value</returns>
        double ToSiUnit(double value);

        /// <summary>
        /// Converts a value from the base unit.
        /// </summary>
        /// <param name="value">The value in base unit</param>
        /// <returns>The converted value</returns>
        double FromSiUnit(double value);

        /// <summary>
        /// Converts the unit to its string representation
        /// </summary>
        /// <param name="format">How to format the return value</param>
        /// <returns></returns>
        string ToString(SymbolFormat format);
    }
}