namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.PressureUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(PressureUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Pascals.symbol}")]
    public struct PressureUnit : IUnit, IUnit<Pressure>, IEquatable<PressureUnit>
    {
        /// <summary>
        /// The Pascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Pascals = new PressureUnit(1.0, "Pa");

        /// <summary>
        /// The Pascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Pa = Pascals;

        /// <summary>
        /// The Nanopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Nanopascals = new PressureUnit(1E-09, "nPa");

        /// <summary>
        /// The Nanopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit nPa = Nanopascals;

        /// <summary>
        /// The Micropascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Micropascals = new PressureUnit(1E-06, "µPa");

        /// <summary>
        /// The Micropascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit µPa = Micropascals;

        /// <summary>
        /// The Millipascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Millipascals = new PressureUnit(0.001, "mPa");

        /// <summary>
        /// The Millipascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit mPa = Millipascals;

        /// <summary>
        /// The Kilopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Kilopascals = new PressureUnit(1000, "kPa");

        /// <summary>
        /// The Kilopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit kPa = Kilopascals;

        /// <summary>
        /// The Megapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Megapascals = new PressureUnit(1000000, "MPa");

        /// <summary>
        /// The Megapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit MPa = Megapascals;

        /// <summary>
        /// The Gigapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Gigapascals = new PressureUnit(1000000000, "GPa");

        /// <summary>
        /// The Gigapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit GPa = Gigapascals;

        /// <summary>
        /// The Bars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Bars = new PressureUnit(100000, "bar");

        /// <summary>
        /// The Bars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit bar = Bars;

        /// <summary>
        /// The Millibars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit Millibars = new PressureUnit(100, "mbar");

        /// <summary>
        /// The Millibars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit mbar = Millibars;

        /// <summary>
        /// The NewtonsPerSquareMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit NewtonsPerSquareMillimetre = new PressureUnit(1000000, "N⋅mm⁻²");

        /// <summary>
        /// The KilonewtonsPerSquareMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit KilonewtonsPerSquareMillimetre = new PressureUnit(1000000000, "kN⋅mm⁻²");

        /// <summary>
        /// The NewtonsPerSquareMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PressureUnit NewtonsPerSquareMetre = new PressureUnit(1, "N/m²");

        private readonly double conversionFactor;
        private readonly string symbol;

        public PressureUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.PressureUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.PressureUnit"/>
        /// </summary>
        public PressureUnit SiUnit => PressureUnit.Pascals;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.PressureUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => PressureUnit.Pascals;

        public static Pressure operator *(double left, PressureUnit right)
        {
            return Pressure.From(left, right);
        }

        public static bool operator ==(PressureUnit left, PressureUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PressureUnit left, PressureUnit right)
        {
            return !left.Equals(right);
        }

        public static PressureUnit Parse(string text)
        {
            return UnitParser<PressureUnit>.Parse(text);
        }

        public static bool TryParse(string text, out PressureUnit value)
        {
            return UnitParser<PressureUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Pascals.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Pascals.
        /// </summary>
        /// <param name="value">The value in Pascals</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Pressure(value, this)</returns>
        public Pressure CreateQuantity(double value)
        {
            return new Pressure(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Pascals
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Pressure quantity)
        {
            return FromSiUnit(quantity.pascals);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(PressureUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is PressureUnit && Equals((PressureUnit)obj);
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