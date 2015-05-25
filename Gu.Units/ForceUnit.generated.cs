namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.ForceUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct ForceUnit : IUnit, IUnit<Force>, IEquatable<ForceUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Newtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Newtons = new ForceUnit(1.0, "N");
        /// <summary>
        /// The <see cref="T:Gu.Units.Newtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit N = Newtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanonewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Nanonewtons = new ForceUnit(1E-09, "nN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanonewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit nN = Nanonewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Micronewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Micronewtons = new ForceUnit(1E-06, "µN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Micronewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit µN = Micronewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millinewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Millinewtons = new ForceUnit(0.001, "mN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millinewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit mN = Millinewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilonewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Kilonewtons = new ForceUnit(1000, "kN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilonewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit kN = Kilonewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Meganewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Meganewtons = new ForceUnit(1000000, "MN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Meganewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit MN = Meganewtons;

        /// <summary>
        /// The <see cref="T:Gu.Units.Giganewtons"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Giganewtons = new ForceUnit(1000000000, "GN");
        /// <summary>
        /// The <see cref="T:Gu.Units.Giganewtons"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit GN = Giganewtons;

        private readonly double conversionFactor;
        private readonly string symbol;

        public ForceUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Newtons"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Force operator *(double left, ForceUnit right)
        {
            return Force.From(left, right);
        }

        public static bool operator ==(ForceUnit left, ForceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ForceUnit left, ForceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Newtons"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Newtons.
        /// </summary>
        /// <param name="value">The value in Newtons</param>
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
        public Force CreateQuantity(double value)
        {
            return new Force(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Force quantity)
        {
            return FromSiUnit(quantity.newtons);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", this.symbol, this.ToSiUnit(1), Newtons.symbol);
        }

        public bool Equals(ForceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ForceUnit && Equals((ForceUnit)obj);
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