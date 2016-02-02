namespace Gu.Units
{
    using System;
    using System.Xml.Serialization;

    public interface IQuantity : IFormattable, IXmlSerializable
    {
        /// <summary>
        /// The value in <see cref="SiUnit"/>
        /// </summary>
        double SiValue { get; }

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit SiUnit { get; }

        /// <summary>
        /// Returns a string with the <see cref="Length.SiValue"/> and <see cref="Length.SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        string ToString(IFormatProvider provider);

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m\"</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        string ToString(string format);

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        string ToString(string valueFormat, string symbolFormat);

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider);
    }
}