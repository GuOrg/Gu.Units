namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Current"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(CurrentUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{CurrentUnit.symbol}")]
    public struct CurrentUnit : IUnit, IUnit<Current>, IEquatable<CurrentUnit>
    {
        /// <summary>
        /// The CurrentUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly CurrentUnit Amperes = new CurrentUnit(amperes => amperes, amperes => amperes, "A");

        /// <summary>
        /// The Milliamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Milliamperes = new CurrentUnit(milliamperes => milliamperes / 1000, amperes => 1000 * amperes, "mA");

        /// <summary>
        /// The Kiloamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Kiloamperes = new CurrentUnit(kiloamperes => 1000 * kiloamperes, amperes => amperes / 1000, "kA");

        /// <summary>
        /// The Megaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Megaamperes = new CurrentUnit(megaamperes => 1000000 * megaamperes, amperes => amperes / 1000000, "MA");

        /// <summary>
        /// The Microamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Microamperes = new CurrentUnit(microamperes => microamperes / 1000000, amperes => 1000000 * amperes, "µA");

        /// <summary>
        /// The Nanoamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Nanoamperes = new CurrentUnit(nanoamperes => nanoamperes / 1000000000, amperes => 1000000000 * amperes, "nA");

        /// <summary>
        /// The Gigaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Gigaamperes = new CurrentUnit(gigaamperes => 1000000000 * gigaamperes, amperes => amperes / 1000000000, "GA");

        private readonly Func<double, double> toAmperes;
        private readonly Func<double, double> fromAmperes;
        internal readonly string symbol;

        public CurrentUnit(Func<double, double> toAmperes, Func<double, double> fromAmperes, string symbol)
        {
            this.toAmperes = toAmperes;
            this.fromAmperes = fromAmperes;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.CurrentUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.CurrentUnit"/>
        /// </summary>
        public CurrentUnit SiUnit => Amperes;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.CurrentUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Amperes;

        public static Current operator *(double left, CurrentUnit right)
        {
            return Current.From(left, right);
        }

        public static bool operator ==(CurrentUnit left, CurrentUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CurrentUnit left, CurrentUnit right)
        {
            return !left.Equals(right);
        }

        public static CurrentUnit Parse(string text)
        {
            return UnitParser<CurrentUnit>.Parse(text);
        }

        public static bool TryParse(string text, out CurrentUnit value)
        {
            return UnitParser<CurrentUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Amperes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toAmperes(value);
        }

        /// <summary>
        /// Converts a value from Amperes.
        /// </summary>
        /// <param name="value">The value in Amperes</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double amperes)
        {
            return this.fromAmperes(amperes);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Current(value, this)</returns>
        public Current CreateQuantity(double value)
        {
            return new Current(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in CurrentUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Current quantity)
        {
            return FromSiUnit(quantity.amperes);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(CurrentUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is CurrentUnit && Equals((CurrentUnit)obj);
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