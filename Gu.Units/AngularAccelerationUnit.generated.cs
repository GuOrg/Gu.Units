namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AngularAccelerationUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{RadiansPerSecondSquared.symbol}")]
    public struct AngularAccelerationUnit : IUnit, IUnit<AngularAcceleration>, IEquatable<AngularAccelerationUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerSecondSquared"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerSecondSquared = new AngularAccelerationUnit(1.0, "rad/s²");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerSquareSecond"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerSquareSecond = new AngularAccelerationUnit(0.017453292519943295, "°⋅s⁻²");

        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerSquareHour"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerSquareHour = new AngularAccelerationUnit(7.71604938271605E-08, "h⁻²⋅rad");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerSquareHour"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerSquareHour = new AngularAccelerationUnit(1.346704669748711E-09, "h⁻²⋅°");

        /// <summary>
        /// The <see cref="T:Gu.Units.DegreesPerSquareMinute"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit DegreesPerSquareMinute = new AngularAccelerationUnit(4.84813681109536E-06, "min⁻²⋅°");

        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerSquareMinute"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularAccelerationUnit RadiansPerSquareMinute = new AngularAccelerationUnit(0.00027777777777777778, "min⁻²⋅rad");

        private readonly double conversionFactor;
        private readonly string symbol;

        public AngularAccelerationUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.RadiansPerSecondSquared"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static AngularAcceleration operator *(double left, AngularAccelerationUnit right)
        {
            return AngularAcceleration.From(left, right);
        }

        public static bool operator ==(AngularAccelerationUnit left, AngularAccelerationUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AngularAccelerationUnit left, AngularAccelerationUnit right)
        {
            return !left.Equals(right);
        }

        public static AngularAccelerationUnit Parse(string text)
        {
            return Parser.ParseUnit<AngularAccelerationUnit>(text);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.RadiansPerSecondSquared"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from RadiansPerSecondSquared.
        /// </summary>
        /// <param name="value">The value in RadiansPerSecondSquared</param>
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
        public AngularAcceleration CreateQuantity(double value)
        {
            return new AngularAcceleration(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AngularAcceleration quantity)
        {
            return FromSiUnit(quantity.radiansPerSecondSquared);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AngularAccelerationUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularAccelerationUnit && Equals((AngularAccelerationUnit)obj);
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