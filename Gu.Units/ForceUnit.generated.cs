namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Force"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(ForceUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{ForceUnit.symbol}")]
    public struct ForceUnit : IUnit, IUnit<Force>, IEquatable<ForceUnit>
    {
        /// <summary>
        /// The ForceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ForceUnit Newtons = new ForceUnit(newtons => newtons, newtons => newtons, "N");

        /// <summary>
        /// The Nanonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Nanonewtons = new ForceUnit(nanonewtons => nanonewtons / 1000000000, newtons => 1000000000 * newtons, "nN");

        /// <summary>
        /// The Micronewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Micronewtons = new ForceUnit(micronewtons => micronewtons / 1000000, newtons => 1000000 * newtons, "µN");

        /// <summary>
        /// The Millinewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Millinewtons = new ForceUnit(millinewtons => millinewtons / 1000, newtons => 1000 * newtons, "mN");

        /// <summary>
        /// The Kilonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Kilonewtons = new ForceUnit(kilonewtons => 1000 * kilonewtons, newtons => newtons / 1000, "kN");

        /// <summary>
        /// The Meganewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Meganewtons = new ForceUnit(meganewtons => 1000000 * meganewtons, newtons => newtons / 1000000, "MN");

        /// <summary>
        /// The Giganewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Giganewtons = new ForceUnit(giganewtons => 1000000000 * giganewtons, newtons => newtons / 1000000000, "GN");

        private readonly Func<double, double> toNewtons;
        private readonly Func<double, double> fromNewtons;
        internal readonly string symbol;

        public ForceUnit(Func<double, double> toNewtons, Func<double, double> fromNewtons, string symbol)
        {
            this.toNewtons = toNewtons;
            this.fromNewtons = fromNewtons;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.ForceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ForceUnit"/>
        /// </summary>
        public ForceUnit SiUnit => Newtons;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ForceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Newtons;

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
            return this.toNewtons(value);
        }

        /// <summary>
        /// Converts a value from Newtons.
        /// </summary>
        /// <param name="value">The value in Newtons</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double newtons)
        {
            return this.fromNewtons(newtons);
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
        /// Gets the scalar value of <paramref name="quantity"/> in ForceUnit
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