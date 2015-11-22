namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AngularSpeedUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{RadiansPerSecond.symbol}")]
    public struct AngularSpeedUnit : IUnit, IUnit<AngularSpeed>, IEquatable<AngularSpeedUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerSecond"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit RadiansPerSecond = new AngularSpeedUnit(1.0, "rad/s");

        /// <summary>
        /// The <see cref="T:Gu.Units.RevolutionsPerMinute"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularSpeedUnit RevolutionsPerMinute = new AngularSpeedUnit(0.10471975511966, "rpm");
        /// <summary>
        /// The <see cref="T:Gu.Units.RevolutionsPerMinute"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularSpeedUnit rpm = RevolutionsPerMinute;

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerSecond"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularSpeedUnit DegreesPerSecond = new AngularSpeedUnit(0.017453292519943295, "°⋅s⁻¹");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerMinute"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularSpeedUnit DegreesPerMinute = new AngularSpeedUnit(0.00029088820866572158, "min⁻¹⋅°");

        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerMinute"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularSpeedUnit RadiansPerMinute = new AngularSpeedUnit(0.016666666666666666, "min⁻¹⋅rad");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerHour"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularSpeedUnit DegreesPerHour = new AngularSpeedUnit(4.84813681109536E-06, "h⁻¹⋅°");

        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerHour"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AngularSpeedUnit RadiansPerHour = new AngularSpeedUnit(0.00027777777777777778, "h⁻¹⋅rad");

        private readonly double conversionFactor;
        private readonly string symbol;

        public AngularSpeedUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.RadiansPerSecond"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static AngularSpeed operator *(double left, AngularSpeedUnit right)
        {
            return AngularSpeed.From(left, right);
        }

        public static bool operator ==(AngularSpeedUnit left, AngularSpeedUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AngularSpeedUnit left, AngularSpeedUnit right)
        {
            return !left.Equals(right);
        }

        public static AngularSpeedUnit Parse(string text)
        {
            return Parser.ParseUnit<AngularSpeedUnit>(text);
        }

        public static bool TryParse(string text, out AngularSpeedUnit value)
        {
            return Parser.TryParseUnit<AngularSpeedUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.RadiansPerSecond"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from RadiansPerSecond.
        /// </summary>
        /// <param name="value">The value in RadiansPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public AngularSpeed CreateQuantity(double value)
        {
            return new AngularSpeed(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AngularSpeed quantity)
        {
            return FromSiUnit(quantity.radiansPerSecond);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AngularSpeedUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularSpeedUnit && Equals((AngularSpeedUnit)obj);
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