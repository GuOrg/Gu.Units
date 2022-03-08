namespace Gu.Units
{
    using System;

    /// <summary>
    /// An amount of <typeparamref name="TUnit"/>.
    /// </summary>
    /// <typeparam name="TUnit">The corresponding unit.</typeparam>
    public interface IQuantity<in TUnit> : IQuantity
        where TUnit : IUnit
    {
        /// <summary>
        /// Gets the scalar value in <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>The scalar value.</returns>
        double GetValue(TUnit unit);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(TUnit unit);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(TUnit unit, SymbolFormat symbolFormat);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(TUnit unit, IFormatProvider formatProvider);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(TUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/>.</param>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(string valueFormat, TUnit unit);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/>.</param>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(string valueFormat, TUnit unit, SymbolFormat symbolFormat);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/>.</param>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(string valueFormat, TUnit unit, IFormatProvider formatProvider);

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/>.</param>
        /// <param name="unit">The unit to use in the conversion.</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        string ToString(string valueFormat, TUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider);
    }
}
