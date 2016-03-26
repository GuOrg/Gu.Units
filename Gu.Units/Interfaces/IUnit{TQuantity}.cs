namespace Gu.Units
{
    /// <summary>
    /// The unit of <typeparamref name="TQuantity"/>
    /// </summary>
    /// <typeparam name="TQuantity">The quantity type</typeparam>
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
        /// <param name="quantity">The quantity value</param>
        /// <returns>The scalar value in the unit of this</returns>
        double GetScalarValue(TQuantity quantity);
    }
}
