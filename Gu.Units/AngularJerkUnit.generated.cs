namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AngularJerkUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(AngularJerkUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{RadiansPerSecondCubed.symbol}")]
    public struct AngularJerkUnit : IUnit, IUnit<AngularJerk>, IEquatable<AngularJerkUnit>
    {
        /// <summary>
        /// The RadiansPerSecondCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularJerkUnit RadiansPerSecondCubed = new AngularJerkUnit(1.0, "rad/s³");

        /// <summary>
        /// The DegreesPerSecondCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularJerkUnit DegreesPerSecondCubed = new AngularJerkUnit(0.017453292519943295, "°⋅s⁻³");

        /// <summary>
        /// The RadiansPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularJerkUnit RadiansPerHourCubed = new AngularJerkUnit(2.1433470507544583E-11, "rad⋅h⁻³");

        /// <summary>
        /// The DegreesPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularJerkUnit DegreesPerHourCubed = new AngularJerkUnit(3.7408463048575307E-13, "°⋅h⁻³");

        /// <summary>
        /// The RadiansPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularJerkUnit RadiansPerMinuteCubed = new AngularJerkUnit(4.6296296296296296E-06, "rad⋅min⁻³");

        /// <summary>
        /// The DegreesPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularJerkUnit DegreesPerMinuteCubed = new AngularJerkUnit(8.0802280184922666E-08, "°⋅min⁻³");

        private readonly double conversionFactor;
        private readonly string symbol;

        public AngularJerkUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AngularJerkUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AngularJerkUnit"/>
        /// </summary>
        public AngularJerkUnit SiUnit => AngularJerkUnit.RadiansPerSecondCubed;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AngularJerkUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => AngularJerkUnit.RadiansPerSecondCubed;

        public static AngularJerk operator *(double left, AngularJerkUnit right)
        {
            return AngularJerk.From(left, right);
        }

        public static bool operator ==(AngularJerkUnit left, AngularJerkUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AngularJerkUnit left, AngularJerkUnit right)
        {
            return !left.Equals(right);
        }

        public static AngularJerkUnit Parse(string text)
        {
            return UnitParser<AngularJerkUnit>.Parse(text);
        }

        public static bool TryParse(string text, out AngularJerkUnit value)
        {
            return UnitParser<AngularJerkUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to RadiansPerSecondCubed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from RadiansPerSecondCubed.
        /// </summary>
        /// <param name="value">The value in RadiansPerSecondCubed</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new AngularJerk(value, this)</returns>
        public AngularJerk CreateQuantity(double value)
        {
            return new AngularJerk(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in RadiansPerSecondCubed
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AngularJerk quantity)
        {
            return FromSiUnit(quantity.radiansPerSecondCubed);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AngularJerkUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularJerkUnit && Equals((AngularJerkUnit)obj);
        }

        public override int GetHashCode()
        {
            if (this.symbol == null)
            {
                return 0; // Needed due to default ctor
            }

            return this.symbol.GetHashCode();
        }
    }
}