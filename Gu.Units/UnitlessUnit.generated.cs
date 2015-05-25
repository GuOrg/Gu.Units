namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.UnitlessUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct UnitlessUnit : IUnit, IUnit<Unitless>, IEquatable<UnitlessUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Scalar"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Scalar = new UnitlessUnit(1.0, "ul");
        /// <summary>
        /// The <see cref="T:Gu.Units.Scalar"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit ul = Scalar;

        /// <summary>
        /// The <see cref="T:Gu.Units.PartsPerMillion"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit PartsPerMillion = new UnitlessUnit(1E-06, "ppm");
        /// <summary>
        /// The <see cref="T:Gu.Units.PartsPerMillion"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit ppm = PartsPerMillion;

        /// <summary>
        /// The <see cref="T:Gu.Units.Promilles"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Promilles = new UnitlessUnit(0.001, "‰");

        /// <summary>
        /// The <see cref="T:Gu.Units.Percents"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Percents = new UnitlessUnit(0.01, "%");

        private readonly double conversionFactor;
        private readonly string symbol;

        public UnitlessUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Scalar"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Unitless operator *(double left, UnitlessUnit right)
        {
            return Unitless.From(left, right);
        }

        public static bool operator ==(UnitlessUnit left, UnitlessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UnitlessUnit left, UnitlessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Scalar"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Scalar.
        /// </summary>
        /// <param name="value">The value in Scalar</param>
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
        public Unitless CreateQuantity(double value)
        {
            return new Unitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Unitless quantity)
        {
            return FromSiUnit(quantity.scalar);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", this.symbol, this.ToSiUnit(1), Scalar.symbol);
        }

        public bool Equals(UnitlessUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnitlessUnit && Equals((UnitlessUnit)obj);
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