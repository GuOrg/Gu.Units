namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Illuminance"/>.
    /// </summary>
    [TypeConverter(typeof(IlluminanceTypeConverter))]
    [Serializable]
    public partial struct Illuminance : IQuantity<IlluminanceUnit>, IComparable<Illuminance>, IEquatable<Illuminance>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.IlluminanceUnit.Lux"/>
        /// </summary>
        public static readonly Illuminance Zero = default(Illuminance);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.IlluminanceUnit.Lux"/>.
        /// </summary>
        internal readonly double lux;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Illuminance"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.IlluminanceUnit"/>.</param>
        public Illuminance(double value, IlluminanceUnit unit)
        {
            this.lux = unit.ToSiUnit(value);
        }

        private Illuminance(double lux)
        {
            this.lux = lux;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.IlluminanceUnit.Lux"/>
        /// </summary>
        public double SiValue => this.lux;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IlluminanceUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public IlluminanceUnit SiUnit => IlluminanceUnit.Lux;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => IlluminanceUnit.Lux;

        /// <summary>
        /// Gets the quantity in lux".
        /// </summary>
        public double Lux => this.lux;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <returns>The <see cref="Gu.Units.Illuminance"/> parsed from <paramref name="text"/></returns>
        public static Illuminance Parse(string text)
        {
            return QuantityParser.Parse<IlluminanceUnit, Illuminance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Illuminance"/> parsed from <paramref name="text"/></returns>
        public static Illuminance Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<IlluminanceUnit, Illuminance>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Illuminance"/> parsed from <paramref name="text"/></returns>
        public static Illuminance Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<IlluminanceUnit, Illuminance>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Illuminance"/> parsed from <paramref name="text"/></returns>
        public static Illuminance Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<IlluminanceUnit, Illuminance>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="result">The parsed <see cref="Illuminance"/></param>
        /// <returns>True if an instance of <see cref="Illuminance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Illuminance result)
        {
            return QuantityParser.TryParse<IlluminanceUnit, Illuminance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Illuminance"/></param>
        /// <returns>True if an instance of <see cref="Illuminance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Illuminance result)
        {
            return QuantityParser.TryParse<IlluminanceUnit, Illuminance>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Illuminance"/></param>
        /// <returns>True if an instance of <see cref="Illuminance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Illuminance result)
        {
            return QuantityParser.TryParse<IlluminanceUnit, Illuminance>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Illuminance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Illuminance"/></param>
        /// <returns>True if an instance of <see cref="Illuminance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Illuminance result)
        {
            return QuantityParser.TryParse<IlluminanceUnit, Illuminance>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Illuminance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Illuminance"/></returns>
        public static Illuminance ReadFrom(XmlReader reader)
        {
            var v = default(Illuminance);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Illuminance"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Illuminance"/></returns>
        public static Illuminance From(double value, IlluminanceUnit unit)
        {
            return new Illuminance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Illuminance"/>.
        /// </summary>
        /// <param name="lux">The value in <see cref="Gu.Units.IlluminanceUnit.Lux"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Illuminance"/></returns>
        public static Illuminance FromLux(double lux)
        {
            return new Illuminance(lux);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LuminousFlux"/> that is the result from the multiplication.</returns>
        public static LuminousFlux operator *(Illuminance left, Area right)
        {
            return LuminousFlux.FromLumens(left.lux * right.squareMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Illuminance left, Illuminance right)
        {
            return left.lux / right.lux;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Illuminance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        public static bool operator ==(Illuminance left, Illuminance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Illuminance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        public static bool operator !=(Illuminance left, Illuminance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Illuminance"/> is less than another specified <see cref="Gu.Units.Illuminance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        public static bool operator <(Illuminance left, Illuminance right)
        {
            return left.lux < right.lux;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Illuminance"/> is greater than another specified <see cref="Gu.Units.Illuminance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        public static bool operator >(Illuminance left, Illuminance right)
        {
            return left.lux > right.lux;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Illuminance"/> is less than or equal to another specified <see cref="Gu.Units.Illuminance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        public static bool operator <=(Illuminance left, Illuminance right)
        {
            return left.lux <= right.lux;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Illuminance"/> is greater than or equal to another specified <see cref="Gu.Units.Illuminance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        public static bool operator >=(Illuminance left, Illuminance right)
        {
            return left.lux >= right.lux;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Illuminance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="left">An instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Illuminance"/> with <paramref name="left"/> and returns the result.</returns>
        public static Illuminance operator *(double left, Illuminance right)
        {
            return new Illuminance(left * right.lux);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Illuminance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="right">An instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Illuminance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Illuminance operator *(Illuminance left, double right)
        {
            return new Illuminance(left.lux * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Illuminance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/></param>
        /// <param name="right">An instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Illuminance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Illuminance operator /(Illuminance left, double right)
        {
            return new Illuminance(left.lux / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Illuminance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Illuminance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/>.</param>
        public static Illuminance operator +(Illuminance left, Illuminance right)
        {
            return new Illuminance(left.lux + right.lux);
        }

        /// <summary>
        /// Subtracts an Illuminance from another Illuminance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Illuminance"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Illuminance"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Illuminance"/> (the subtrahend).</param>
        public static Illuminance operator -(Illuminance left, Illuminance right)
        {
            return new Illuminance(left.lux - right.lux);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Illuminance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Illuminance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="illuminance">An instance of <see cref="Gu.Units.Illuminance"/></param>
        public static Illuminance operator -(Illuminance illuminance)
        {
            return new Illuminance(-1 * illuminance.lux);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Illuminance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="illuminance"/>.
        /// </returns>
        /// <param name="illuminance">An instance of <see cref="Gu.Units.Illuminance"/></param>
        public static Illuminance operator +(Illuminance illuminance)
        {
            return illuminance;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(IlluminanceUnit unit)
        {
            return unit.FromSiUnit(this.lux);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Illuminance"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Illuminance"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 lx\"</param>
        /// <returns>The string representation of the <see cref="Illuminance"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 lx\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Illuminance"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex lx</param>
        /// <returns>The string representation of the <see cref="Illuminance"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex lx</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Illuminance"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(IlluminanceUnit unit)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(IlluminanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(IlluminanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(IlluminanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, IlluminanceUnit unit)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, IlluminanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, IlluminanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, IlluminanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<IlluminanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<IlluminanceUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Illuminance"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Illuminance"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.Illuminance"/> object to compare to this instance.</param>
        public int CompareTo(Illuminance quantity)
        {
            return this.lux.CompareTo(quantity.lux);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Illuminance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Illuminance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Illuminance"/> object to compare with this instance.</param>
        public bool Equals(Illuminance other)
        {
            return this.lux.Equals(other.lux);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Illuminance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Illuminance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Illuminance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Illuminance other, Illuminance tolerance)
        {
            Ensure.GreaterThan(tolerance.lux, 0, nameof(tolerance));
            return Math.Abs(this.lux - other.lux) < tolerance.lux;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Illuminance"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Illuminance"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Illuminance && this.Equals((Illuminance)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.lux.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface,
        /// you should return null (Nothing in Visual Basic) from this method, and instead,
        /// if specifying a custom schema is required, apply the <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
        ///  <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/>
        /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "lux", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.lux);
        }
    }
}