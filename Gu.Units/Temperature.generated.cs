#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Temperature"/>.
    /// </summary>
    [TypeConverter(typeof(TemperatureTypeConverter))]
    [Serializable]
    public partial struct Temperature : IQuantity<TemperatureUnit>, IComparable<Temperature>, IEquatable<Temperature>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.TemperatureUnit.Kelvin"/>
        /// </summary>
        public static readonly Temperature Zero = default(Temperature);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.TemperatureUnit.Kelvin"/>.
        /// </summary>
        internal readonly double kelvin;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Temperature"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.TemperatureUnit"/>.</param>
        public Temperature(double value, TemperatureUnit unit)
        {
            this.kelvin = unit.ToSiUnit(value);
        }

        private Temperature(double kelvin)
        {
            this.kelvin = kelvin;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.TemperatureUnit.Kelvin"/>
        /// </summary>
        public double SiValue => this.kelvin;

        /// <summary>
        /// Gets the <see cref="Gu.Units.TemperatureUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public TemperatureUnit SiUnit => TemperatureUnit.Kelvin;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => TemperatureUnit.Kelvin;

        /// <summary>
        /// Gets the quantity in kelvin".
        /// </summary>
        public double Kelvin => this.kelvin;

        /// <summary>
        /// Gets the quantity in Celsius
        /// </summary>
        public double Celsius => this.kelvin - 273.15;

        /// <summary>
        /// Gets the quantity in Fahrenheit
        /// </summary>
        public double Fahrenheit => (1.8 * this.kelvin) - 459.67;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Temperature left, Temperature right)
        {
            return left.kelvin / right.kelvin;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Temperature"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/>.</param>
        public static bool operator ==(Temperature left, Temperature right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Temperature"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/>.</param>
        public static bool operator !=(Temperature left, Temperature right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Temperature"/> is less than another specified <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/>.</param>
        public static bool operator <(Temperature left, Temperature right)
        {
            return left.kelvin < right.kelvin;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Temperature"/> is greater than another specified <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/>.</param>
        public static bool operator >(Temperature left, Temperature right)
        {
            return left.kelvin > right.kelvin;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Temperature"/> is less than or equal to another specified <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/>.</param>
        public static bool operator <=(Temperature left, Temperature right)
        {
            return left.kelvin <= right.kelvin;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Temperature"/> is greater than or equal to another specified <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/>.</param>
        public static bool operator >=(Temperature left, Temperature right)
        {
            return left.kelvin >= right.kelvin;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Temperature"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Temperature"/> and returns the result.</returns>
        public static Temperature operator *(double left, Temperature right)
        {
            return new Temperature(left * right.kelvin);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Temperature"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Temperature"/> with <paramref name="right"/> and returns the result.</returns>
        public static Temperature operator *(Temperature left, double right)
        {
            return new Temperature(left.kelvin * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Temperature"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Temperature"/> by <paramref name="right"/> and returns the result.</returns>
        public static Temperature operator /(Temperature left, double right)
        {
            return new Temperature(left.kelvin / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Temperature"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Temperature"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/>.</param>
        public static Temperature operator +(Temperature left, Temperature right)
        {
            return new Temperature(left.kelvin + right.kelvin);
        }

        /// <summary>
        /// Subtracts an Temperature from another Temperature and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Temperature"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Temperature"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Temperature"/> (the subtrahend).</param>
        public static Temperature operator -(Temperature left, Temperature right)
        {
            return new Temperature(left.kelvin - right.kelvin);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Temperature"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Temperature"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="temperature">An instance of <see cref="Gu.Units.Temperature"/></param>
        public static Temperature operator -(Temperature temperature)
        {
            return new Temperature(-1 * temperature.kelvin);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="temperature"/>.
        /// </returns>
        /// <param name="temperature">An instance of <see cref="Gu.Units.Temperature"/></param>
        public static Temperature operator +(Temperature temperature)
        {
            return temperature;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <returns>The <see cref="Gu.Units.Temperature"/> parsed from <paramref name="text"/></returns>
        public static Temperature Parse(string text)
        {
            return QuantityParser.Parse<TemperatureUnit, Temperature>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Temperature"/> parsed from <paramref name="text"/></returns>
        public static Temperature Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<TemperatureUnit, Temperature>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Temperature"/> parsed from <paramref name="text"/></returns>
        public static Temperature Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<TemperatureUnit, Temperature>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Temperature"/> parsed from <paramref name="text"/></returns>
        public static Temperature Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<TemperatureUnit, Temperature>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <param name="result">The parsed <see cref="Temperature"/></param>
        /// <returns>True if an instance of <see cref="Temperature"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Temperature result)
        {
            return QuantityParser.TryParse<TemperatureUnit, Temperature>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Temperature"/></param>
        /// <returns>True if an instance of <see cref="Temperature"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Temperature result)
        {
            return QuantityParser.TryParse<TemperatureUnit, Temperature>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Temperature"/></param>
        /// <returns>True if an instance of <see cref="Temperature"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Temperature result)
        {
            return QuantityParser.TryParse<TemperatureUnit, Temperature>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Temperature"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Temperature"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Temperature"/></param>
        /// <returns>True if an instance of <see cref="Temperature"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Temperature result)
        {
            return QuantityParser.TryParse<TemperatureUnit, Temperature>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Temperature"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Temperature"/></returns>
        public static Temperature ReadFrom(XmlReader reader)
        {
            var v = default(Temperature);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Temperature"/></returns>
        public static Temperature From(double value, TemperatureUnit unit)
        {
            return new Temperature(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <param name="kelvin">The value in <see cref="Gu.Units.TemperatureUnit.Kelvin"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Temperature"/></returns>
        public static Temperature FromKelvin(double kelvin)
        {
            return new Temperature(kelvin);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <param name="celsius">The value in °C.</param>
        /// <returns>An instance of <see cref="Gu.Units.Temperature"/></returns>
        public static Temperature FromCelsius(double celsius)
        {
            return new Temperature(celsius + 273.15);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Temperature"/>.
        /// </summary>
        /// <param name="fahrenheit">The value in °F.</param>
        /// <returns>An instance of <see cref="Gu.Units.Temperature"/></returns>
        public static Temperature FromFahrenheit(double fahrenheit)
        {
            return new Temperature((fahrenheit + 459.67) / 1.8);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(TemperatureUnit unit)
        {
            return unit.FromSiUnit(this.kelvin);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Temperature"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Temperature"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 K\"</param>
        /// <returns>The string representation of the <see cref="Temperature"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 K\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Temperature"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex K</param>
        /// <returns>The string representation of the <see cref="Temperature"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex K</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Temperature"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(TemperatureUnit unit)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(TemperatureUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(TemperatureUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(TemperatureUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, TemperatureUnit unit)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, TemperatureUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, TemperatureUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, TemperatureUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TemperatureUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Temperature"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Temperature"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantities of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.Temperature"/> object to compare to this instance.</param>
        public int CompareTo(Temperature quantity)
        {
            return this.kelvin.CompareTo(quantity.kelvin);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Temperature"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Temperature as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Temperature"/> object to compare with this instance.</param>
        public bool Equals(Temperature other)
        {
            return this.kelvin.Equals(other.kelvin);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Temperature"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Temperature as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Temperature"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Temperature other, Temperature tolerance)
        {
            Ensure.GreaterThan(tolerance.kelvin, 0, nameof(tolerance));
            return Math.Abs(this.kelvin - other.kelvin) < tolerance.kelvin;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Temperature"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Temperature"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Temperature other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.kelvin.GetHashCode();
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
        public XmlSchema? GetSchema() => null;

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            var attribute = reader.GetAttribute("Value");
            if (attribute is null)
            {
                throw new XmlException($"Could not find attribute named: Value");
            }

            this  = new Temperature(XmlConvert.ToDouble(attribute), TemperatureUnit.Kelvin);
            reader.ReadStartElement();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Value");
            writer.WriteValue(this.kelvin);
            writer.WriteEndAttribute();
        }

        internal string ToString(QuantityFormat<TemperatureUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
