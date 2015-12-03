namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.CurrentUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(CurrentUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Amperes.symbol}")]
    public struct CurrentUnit : IUnit, IUnit<Current>, IEquatable<CurrentUnit>
    {
        /// <summary>
        /// The Amperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Amperes = new CurrentUnit(1.0, "A");

        /// <summary>
        /// The Amperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit A = Amperes;

        /// <summary>
        /// The Milliamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit Milliamperes = new CurrentUnit(0.001, "mA");

        /// <summary>
        /// The Milliamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit mA = Milliamperes;

        /// <summary>
        /// The Kiloamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit Kiloamperes = new CurrentUnit(1000, "kA");

        /// <summary>
        /// The Kiloamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit kA = Kiloamperes;

        /// <summary>
        /// The Megaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit Megaamperes = new CurrentUnit(1000000, "MA");

        /// <summary>
        /// The Megaamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit MA = Megaamperes;

        /// <summary>
        /// The Microamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit Microamperes = new CurrentUnit(1E-06, "µA");

        /// <summary>
        /// The Microamperes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly CurrentUnit µA = Microamperes;

        private readonly double conversionFactor;
        private readonly string symbol;

        public CurrentUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.CurrentUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.CurrentUnit"/>
        /// </summary>
        public CurrentUnit SiUnit => CurrentUnit.Amperes;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.CurrentUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => CurrentUnit.Amperes;

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
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Amperes.
        /// </summary>
        /// <param name="value">The value in Amperes</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
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
        /// Gets the scalar value of <paramref name="quantity"/> in Amperes
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