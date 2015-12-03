namespace Gu.Units
{
    public interface IUnit
    {
        string Symbol { get; }

        IUnit SiUnit { get; }

        double ToSiUnit(double value);

        /// <summary>
        /// Converts a value from the base unit.
        /// </summary>
        /// <param name="value">The value in base unit</param>
        /// <returns>The converted value</returns>
        double FromSiUnit(double value);
    }
}