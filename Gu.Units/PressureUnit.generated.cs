namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Pressure"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(PressureUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{PressureUnit.symbol}")]
    public struct PressureUnit : IUnit, IUnit<Pressure>, IEquatable<PressureUnit>
    {
        /// <summary>
        /// The PressureUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly PressureUnit Pascals = new PressureUnit(pascals => pascals, pascals => pascals, "Pa");

        /// <summary>
        /// The Bars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Bars = new PressureUnit(bars => 100000 * bars, pascals => pascals / 100000, "bar");

        /// <summary>
        /// The Millibars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millibars = new PressureUnit(millibars => 100 * millibars, pascals => pascals / 100, "mbar");

        /// <summary>
        /// The Nanopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Nanopascals = new PressureUnit(nanopascals => nanopascals / 1000000000, pascals => 1000000000 * pascals, "nPa");

        /// <summary>
        /// The Micropascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Micropascals = new PressureUnit(micropascals => micropascals / 1000000, pascals => 1000000 * pascals, "µPa");

        /// <summary>
        /// The Millipascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millipascals = new PressureUnit(millipascals => millipascals / 1000, pascals => 1000 * pascals, "mPa");

        /// <summary>
        /// The Kilopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Kilopascals = new PressureUnit(kilopascals => 1000 * kilopascals, pascals => pascals / 1000, "kPa");

        /// <summary>
        /// The Megapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Megapascals = new PressureUnit(megapascals => 1000000 * megapascals, pascals => pascals / 1000000, "MPa");

        /// <summary>
        /// The Gigapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Gigapascals = new PressureUnit(gigapascals => 1000000000 * gigapascals, pascals => pascals / 1000000000, "GPa");

        /// <summary>
        /// The NewtonsPerSquareMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit NewtonsPerSquareMillimetre = new PressureUnit(newtonsPerSquareMillimetre => 1000000 * newtonsPerSquareMillimetre, pascals => pascals / 1000000, "N⋅mm⁻²");

        /// <summary>
        /// The KilonewtonsPerSquareMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit KilonewtonsPerSquareMillimetre = new PressureUnit(kilonewtonsPerSquareMillimetre => 1000000000 * kilonewtonsPerSquareMillimetre, pascals => pascals / 1000000000, "kN⋅mm⁻²");

        /// <summary>
        /// The NewtonsPerSquareMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit NewtonsPerSquareMetre = new PressureUnit(newtonsPerSquareMetre => newtonsPerSquareMetre, pascals => pascals, "N/m²");

        private readonly Func<double, double> toPascals;
        private readonly Func<double, double> fromPascals;
        internal readonly string symbol;

        public PressureUnit(Func<double, double> toPascals, Func<double, double> fromPascals, string symbol)
        {
            this.toPascals = toPascals;
            this.fromPascals = fromPascals;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.PressureUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.PressureUnit"/>
        /// </summary>
        public PressureUnit SiUnit => Pascals;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.PressureUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Pascals;

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
            return this.toPascals(value);
        }

        /// <summary>
        /// Converts a value from Pascals.
        /// </summary>
        /// <param name="value">The value in Pascals</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double pascals)
        {
            return this.fromPascals(pascals);
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
        /// Gets the scalar value of <paramref name="quantity"/> in PressureUnit
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