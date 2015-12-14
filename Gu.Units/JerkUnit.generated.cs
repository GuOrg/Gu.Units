namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Jerk"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(JerkUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{JerkUnit.symbol}")]
    public struct JerkUnit : IUnit, IUnit<Jerk>, IEquatable<JerkUnit>
    {
        /// <summary>
        /// The JerkUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly JerkUnit MetresPerSecondCubed = new JerkUnit(metresPerSecondCubed => metresPerSecondCubed, metresPerSecondCubed => metresPerSecondCubed, "m/s³");

        /// <summary>
        /// The MillimetresPerSecondCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MillimetresPerSecondCubed = new JerkUnit(millimetresPerSecondCubed => millimetresPerSecondCubed / 1000, metresPerSecondCubed => 1000 * metresPerSecondCubed, "mm⋅s⁻³");

        /// <summary>
        /// The CentimetresPerSecondCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit CentimetresPerSecondCubed = new JerkUnit(centimetresPerSecondCubed => centimetresPerSecondCubed / 100, metresPerSecondCubed => 100 * metresPerSecondCubed, "cm⋅s⁻³");

        /// <summary>
        /// The MillimetresPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MillimetresPerHourCubed = new JerkUnit(millimetresPerHourCubed => millimetresPerHourCubed / 46656000000000, metresPerSecondCubed => 46656000000000 * metresPerSecondCubed, "mm⋅h⁻³");

        /// <summary>
        /// The MillimetresPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MillimetresPerMinuteCubed = new JerkUnit(millimetresPerMinuteCubed => millimetresPerMinuteCubed / 216000000, metresPerSecondCubed => 216000000 * metresPerSecondCubed, "mm⋅min⁻³");

        /// <summary>
        /// The MetresPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MetresPerHourCubed = new JerkUnit(metresPerHourCubed => metresPerHourCubed / 46656000000, metresPerSecondCubed => 46656000000 * metresPerSecondCubed, "m⋅h⁻³");

        /// <summary>
        /// The MetresPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit MetresPerMinuteCubed = new JerkUnit(metresPerMinuteCubed => metresPerMinuteCubed / 216000, metresPerSecondCubed => 216000 * metresPerSecondCubed, "m⋅min⁻³");

        /// <summary>
        /// The CentimetresPerHourCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit CentimetresPerHourCubed = new JerkUnit(centimetresPerHourCubed => centimetresPerHourCubed / 4665600000000, metresPerSecondCubed => 4665600000000 * metresPerSecondCubed, "cm⋅h⁻³");

        /// <summary>
        /// The CentimetresPerMinuteCubed unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly JerkUnit CentimetresPerMinuteCubed = new JerkUnit(centimetresPerMinuteCubed => centimetresPerMinuteCubed / 21600000, metresPerSecondCubed => 21600000 * metresPerSecondCubed, "cm⋅min⁻³");

        private readonly Func<double, double> toMetresPerSecondCubed;
        private readonly Func<double, double> fromMetresPerSecondCubed;
        internal readonly string symbol;

        public JerkUnit(Func<double, double> toMetresPerSecondCubed, Func<double, double> fromMetresPerSecondCubed, string symbol)
        {
            this.toMetresPerSecondCubed = toMetresPerSecondCubed;
            this.fromMetresPerSecondCubed = fromMetresPerSecondCubed;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.JerkUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.JerkUnit"/>
        /// </summary>
        public JerkUnit SiUnit => MetresPerSecondCubed;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.JerkUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MetresPerSecondCubed;

        public static Jerk operator *(double left, JerkUnit right)
        {
            return Jerk.From(left, right);
        }

        public static bool operator ==(JerkUnit left, JerkUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(JerkUnit left, JerkUnit right)
        {
            return !left.Equals(right);
        }

        public static JerkUnit Parse(string text)
        {
            return UnitParser<JerkUnit>.Parse(text);
        }

        public static bool TryParse(string text, out JerkUnit value)
        {
            return UnitParser<JerkUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerSecondCubed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerSecondCubed(value);
        }

        /// <summary>
        /// Converts a value from MetresPerSecondCubed.
        /// </summary>
        /// <param name="value">The value in MetresPerSecondCubed</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerSecondCubed)
        {
            return this.fromMetresPerSecondCubed(metresPerSecondCubed);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Jerk(value, this)</returns>
        public Jerk CreateQuantity(double value)
        {
            return new Jerk(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in JerkUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Jerk quantity)
        {
            return FromSiUnit(quantity.metresPerSecondCubed);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(JerkUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is JerkUnit && Equals((JerkUnit)obj);
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