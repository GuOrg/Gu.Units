namespace Gu.Units
{
    public interface IUnit<TQuantity> : IUnit
        where TQuantity : IQuantity
    {
        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        TQuantity CreateQuantity(double value);

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <typeparam name="TQuantity"></typeparam>
        /// <param name="quantity"></param>
        /// <returns></returns>
        double GetScalarValue(TQuantity quantity);
    }
}
