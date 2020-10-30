namespace Gu.Units
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// An amount of a <see cref="IUnit"/>.
    /// </summary>
    public interface IQuantity : IFormattable, IXmlSerializable
    {
        /// <summary>
        /// Gets the value in <see cref="SiUnit"/>.
        /// </summary>
        double SiValue { get; }

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>.
        /// </summary>
        IUnit SiUnit { get; }

        /// <summary>
        /// Returns a string with the <see cref="Length.SiValue"/> and <see cref="Length.SiUnit"/>.
        /// </summary>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Length"/>.</returns>
        string ToString(IFormatProvider formatProvider);

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}.
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m\".</param>
        /// <returns>The string representation of the <see cref="Length"/>.</returns>
        string ToString(string format);

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}.
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2.</param>
        /// <param name="symbolFormat">For formatting of the unit ex m.</param>
        /// <returns>The string representation of the <see cref="Length"/>.</returns>
        string ToString(string valueFormat, string symbolFormat);

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}.
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2.</param>
        /// <param name="symbolFormat">For formatting the unit ex m.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Length"/>.</returns>
        string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider);
    }
}