namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Resistance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ResistanceUnitTypeConverter))]
    public struct ResistanceUnit : IUnit, IUnit<Resistance>, IEquatable<ResistanceUnit>
    {
        /// <summary>
        /// The ResistanceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ResistanceUnit Ohm = new ResistanceUnit(ohm => ohm, ohm => ohm, "Ω");

        /// <summary>
        /// The Microohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Microohm = new ResistanceUnit(microohm => microohm / 1000000, ohm => 1000000 * ohm, "µΩ");

        /// <summary>
        /// The Milliohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Milliohm = new ResistanceUnit(milliohm => milliohm / 1000, ohm => 1000 * ohm, "mΩ");

        /// <summary>
        /// The Kiloohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Kiloohm = new ResistanceUnit(kiloohm => 1000 * kiloohm, ohm => ohm / 1000, "kΩ");

        /// <summary>
        /// The Megaohm unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Megaohm = new ResistanceUnit(megaohm => 1000000 * megaohm, ohm => ohm / 1000000, "MΩ");

        private readonly Func<double, double> toOhm;
        private readonly Func<double, double> fromOhm;
        internal readonly string symbol;

        public ResistanceUnit(Func<double, double> toOhm, Func<double, double> fromOhm, string symbol)
        {
            this.toOhm = toOhm;
            this.fromOhm = fromOhm;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.ResistanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ResistanceUnit"/>
        /// </summary>
        public ResistanceUnit SiUnit => Ohm;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ResistanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Ohm;

        public static Resistance operator *(double left, ResistanceUnit right)
        {
            return Resistance.From(left, right);
        }

        public static bool operator ==(ResistanceUnit left, ResistanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ResistanceUnit left, ResistanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="ResistanceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="ResistanceUnit"/></returns>
        public static ResistanceUnit Parse(string text)
        {
            return UnitParser<ResistanceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out ResistanceUnit value)
        {
            return UnitParser<ResistanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Ohm.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toOhm(value);
        }

        /// <summary>
        /// Converts a value from ohm.
        /// </summary>
        /// <param name="Ohm">The value in Ohm</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double ohm)
        {
            return this.fromOhm(ohm);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Resistance(<paramref name="value"/>, this)</returns>
        public Resistance CreateQuantity(double value)
        {
            return new Resistance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Ohm
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Resistance quantity)
        {
            return FromSiUnit(quantity.ohm);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            ResistanceUnit unit;
            var paddedFormat = UnitFormatCache<ResistanceUnit>.GetOrCreate(format, out unit);
            if (unit != this)
            {
                return format;
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<ResistanceUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(ResistanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ResistanceUnit && Equals((ResistanceUnit)obj);
        }

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
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