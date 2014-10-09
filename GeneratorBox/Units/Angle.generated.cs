// <summary file="Angle.generated.cs" company="...">
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
    /// An Angle
    /// </summary>
    [Serializable]
	public partial struct Angle : IComparable<Angle>, IEquatable<Angle>, IFormattable, IXmlSerializable, IUnitValue
	{
	    /// <summary>
        /// The value in <see cref="T:GeneratorBox.Units.Angle"/>.
        /// </summary>
		public readonly Angle Angle;
		
		private Angle(double angle)
        {
            Angle = angle;
        }

		/// <summary>
        /// Initializes a new instance of <see cref="T:GeneratorBox.Units.Angle"/>.
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="unit"></param>
        public Angle(double angle, Angle unit)
        {
            Angle = angle;
        }
		