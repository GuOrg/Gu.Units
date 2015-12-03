namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.ForceUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(ForceUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Newtons.symbol}")]
    public struct ForceUnit : IUnit, IUnit<Force>, IEquatable<ForceUnit>
    {
        /// <summary>
        /// The Newtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Newtons = new ForceUnit(1.0, "N");

        /// <summary>
        /// The Newtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit N = Newtons;

        /// <summary>
        /// The Nanonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit Nanonewtons = new ForceUnit(1E-09, "nN");

        /// <summary>
        /// The Nanonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit nN = Nanonewtons;

        /// <summary>
        /// The Micronewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit Micronewtons = new ForceUnit(1E-06, "µN");

        /// <summary>
        /// The Micronewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit µN = Micronewtons;

        /// <summary>
        /// The Millinewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit Millinewtons = new ForceUnit(0.001, "mN");

        /// <summary>
        /// The Millinewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit mN = Millinewtons;

        /// <summary>
        /// The Kilonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit Kilonewtons = new ForceUnit(1000, "kN");

        /// <summary>
        /// The Kilonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit kN = Kilonewtons;

        /// <summary>
        /// The Meganewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit Meganewtons = new ForceUnit(1000000, "MN");

        /// <summary>
        /// The Meganewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit MN = Meganewtons;

        /// <summary>
        /// The Giganewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForceUnit Giganewtons = new ForceUnit(1000000000, "GN");

        /// <summary>
        /// The Giganewtons unit
        /// Contains conversion logic to from and formatting.
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
        /// The symbol for the <see cref="Gu.Units.ForceUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ForceUnit"/>
        /// </summary>
        public ForceUnit SiUnit => ForceUnit.Newtons;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ForceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => ForceUnit.Newtons;

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

        public static ForceUnit Parse(string text)
        {
            return UnitParser<ForceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out ForceUnit value)
        {
            return UnitParser<ForceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Newtons.
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
        /// <returns>new Force(value, this)</returns>
        public Force CreateQuantity(double value)
        {
            return new Force(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Newtons
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Force quantity)
        {
            return FromSiUnit(quantity.newtons);
        }

        public override string ToString()
        {
            return this.symbol;
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