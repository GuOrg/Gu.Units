// <summary file="Length.generated.cs" company="...">
// some text...
// </summary>
namespace GeneratorBox.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

	/// <summary>
    /// An Length
    /// </summary>
    [Serializable]
	public partial struct Length : IComparable<Length>, IEquatable<Length>, IFormattable, IXmlSerializable, IUnitValue
	{
	    /// <summary>
        /// The value in <see cref="T:GeneratorBox.Units.Meters"/>.
        /// </summary>
		public readonly Meters Meters;
		
		private Length(double meters)
        {
            Meters = meters;
        }

		/// <summary>
        /// Initializes a new instance of <see cref="T:GeneratorBox.Units.Meters"/>.
        /// </summary>
        /// <param name="meters"></param>
        /// <param name="unit"></param>
        public Angle(double meters, Meters unit)
        {
            Meters = meters;
        }
		