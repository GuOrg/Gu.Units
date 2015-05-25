namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.AngularSpeedUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct AngularSpeedUnit : IUnit, IUnit<AngularSpeed>, IEquatable<AngularSpeedUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.RadiansPerSecond"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit RadiansPerSecond = new AngularSpeedUnit(1.0, "rad/s");

        /// <summary>
        /// The <see cref="T:Gu.Units.RevolutionsPerMinute"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit RevolutionsPerMinute = new AngularSpeedUnit(0.10471975511966, "rpm");
        /// <summary>
        /// The <see cref="T:Gu.Units.RevolutionsPerMinute"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly AngularSpeedUnit rpm = RevolutionsPerMinute;

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
            return string.Format("1{0} == {1}{2}", this.symbol, this.ToSiUnit(1), RadiansPerSecond.symbol);
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