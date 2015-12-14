namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Illuminance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(IlluminanceUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{IlluminanceUnit.symbol}")]
    public struct IlluminanceUnit : IUnit, IUnit<Illuminance>, IEquatable<IlluminanceUnit>
    {
        /// <summary>
        /// The IlluminanceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly IlluminanceUnit Lux = new IlluminanceUnit(lux => lux, lux => lux, "lx");

        private readonly Func<double, double> toLux;
        private readonly Func<double, double> fromLux;
        internal readonly string symbol;

        public IlluminanceUnit(Func<double, double> toLux, Func<double, double> fromLux, string symbol)
        {
            this.toLux = toLux;
            this.fromLux = fromLux;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.IlluminanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.IlluminanceUnit"/>
        /// </summary>
        public IlluminanceUnit SiUnit => Lux;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.IlluminanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Lux;

        public static Illuminance operator *(double left, IlluminanceUnit right)
        {
            return Illuminance.From(left, right);
        }

        public static bool operator ==(IlluminanceUnit left, IlluminanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IlluminanceUnit left, IlluminanceUnit right)
        {
            return !left.Equals(right);
        }

        public static IlluminanceUnit Parse(string text)
        {
            return UnitParser<IlluminanceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out IlluminanceUnit value)
        {
            return UnitParser<IlluminanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Lux.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toLux(value);
        }

        /// <summary>
        /// Converts a value from Lux.
        /// </summary>
        /// <param name="value">The value in Lux</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double lux)
        {
            return this.fromLux(lux);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Illuminance(value, this)</returns>
        public Illuminance CreateQuantity(double value)
        {
            return new Illuminance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in IlluminanceUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Illuminance quantity)
        {
            return FromSiUnit(quantity.lux);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(IlluminanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is IlluminanceUnit && Equals((IlluminanceUnit)obj);
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