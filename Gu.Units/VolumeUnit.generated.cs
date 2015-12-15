namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Volume"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(VolumeUnitTypeConverter))]
    public struct VolumeUnit : IUnit, IUnit<Volume>, IEquatable<VolumeUnit>
    {
        /// <summary>
        /// The VolumeUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicMetres = new VolumeUnit(cubicMetres => cubicMetres, cubicMetres => cubicMetres, "m³");

        /// <summary>
        /// The Litres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit Litres = new VolumeUnit(litres => litres / 1000, cubicMetres => 1000 * cubicMetres, "L");

        /// <summary>
        /// The Millilitres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit Millilitres = new VolumeUnit(millilitres => millilitres / 1000000, cubicMetres => 1000000 * cubicMetres, "ml");

        /// <summary>
        /// The Centilitres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit Centilitres = new VolumeUnit(centilitres => centilitres / 100000, cubicMetres => 100000 * cubicMetres, "cl");

        /// <summary>
        /// The Decilitres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit Decilitres = new VolumeUnit(decilitres => decilitres / 10000, cubicMetres => 10000 * cubicMetres, "dl");

        /// <summary>
        /// The CubicCentimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicCentimetres = new VolumeUnit(cubicCentimetres => cubicCentimetres / 1000000, cubicMetres => 1000000 * cubicMetres, "cm³");

        /// <summary>
        /// The CubicMillimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicMillimetres = new VolumeUnit(cubicMillimetres => cubicMillimetres / 1000000000, cubicMetres => 1000000000 * cubicMetres, "mm³");

        /// <summary>
        /// The CubicInches unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicInches = new VolumeUnit(cubicInches => 1.6387064E-05 * cubicInches, cubicMetres => cubicMetres / 1.6387064E-05, "in³");

        /// <summary>
        /// The CubicDecimetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicDecimetres = new VolumeUnit(cubicDecimetres => cubicDecimetres / 1000, cubicMetres => 1000 * cubicMetres, "dm³");

        private readonly Func<double, double> toCubicMetres;
        private readonly Func<double, double> fromCubicMetres;
        internal readonly string symbol;

        public VolumeUnit(Func<double, double> toCubicMetres, Func<double, double> fromCubicMetres, string symbol)
        {
            this.toCubicMetres = toCubicMetres;
            this.fromCubicMetres = fromCubicMetres;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.VolumeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.VolumeUnit"/>
        /// </summary>
        public VolumeUnit SiUnit => CubicMetres;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.VolumeUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => CubicMetres;

        public static Volume operator *(double left, VolumeUnit right)
        {
            return Volume.From(left, right);
        }

        public static bool operator ==(VolumeUnit left, VolumeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VolumeUnit left, VolumeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="VolumeUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="VolumeUnit"/></returns>
        public static VolumeUnit Parse(string text)
        {
            return UnitParser<VolumeUnit>.Parse(text);
        }

        public static bool TryParse(string text, out VolumeUnit value)
        {
            return UnitParser<VolumeUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to CubicMetres.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toCubicMetres(value);
        }

        /// <summary>
        /// Converts a value from cubicMetres.
        /// </summary>
        /// <param name="CubicMetres">The value in CubicMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double cubicMetres)
        {
            return this.fromCubicMetres(cubicMetres);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Volume(<paramref name="value"/>, this)</returns>
        public Volume CreateQuantity(double value)
        {
            return new Volume(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in CubicMetres
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Volume quantity)
        {
            return FromSiUnit(quantity.cubicMetres);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            VolumeUnit unit;
            var paddedFormat = UnitFormatCache<VolumeUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<VolumeUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(VolumeUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is VolumeUnit && Equals((VolumeUnit)obj);
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