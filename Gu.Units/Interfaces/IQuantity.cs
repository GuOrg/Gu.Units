namespace Gu.Units
{
    using System;
    using System.Xml.Serialization;

    public interface IQuantity : IFormattable, IXmlSerializable
    {
        Type GetType();

        /// <summary>
        /// The value in <see cref="SiUnit"/>
        /// </summary>
        double SiValue { get; }

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit SiUnit { get; }
    }
}