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
    /// A type for the quantity <see cref="Gu.Units.LengthPerUnitless"/>.
    /// </summary>
    [TypeConverter(typeof(LengthPerUnitlessTypeConverter))]
    [Serializable]
    public partial struct LengthPerUnitless : IQuantity<LengthPerUnitlessUnit>, IComparable<LengthPerUnitless>, IEquatable<LengthPerUnitless>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.LengthPerUnitlessUnit.MetresPerUnitless"/>
        /// </summary>
        public static readonly LengthPerUnitless Zero = default(LengthPerUnitless);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.LengthPerUnitlessUnit.MetresPerUnitless"/>.
        /// </summary>
        internal readonly double metresPerUnitless;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.LengthPerUnitless"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.LengthPerUnitlessUnit"/>.</param>
        public LengthPerUnitless(double value, LengthPerUnitlessUnit unit)
        {
            this.metresPerUnitless = unit.ToSiUnit(value);
        }

        private LengthPerUnitless(double metresPerUnitless)
        {
            this.metresPerUnitless = metresPerUnitless;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.LengthPerUnitlessUnit.MetresPerUnitless"/>
        /// </summary>
        public double SiValue => this.metresPerUnitless;

        /// <summary>
        /// Gets the <see cref="Gu.Units.LengthPerUnitlessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public LengthPerUnitlessUnit SiUnit => LengthPerUnitlessUnit.MetresPerUnitless;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => LengthPerUnitlessUnit.MetresPerUnitless;

        /// <summary>
        /// Gets the quantity in metresPerUnitless".
        /// </summary>
        public double MetresPerUnitless => this.metresPerUnitless;

        /// <summary>
        /// Gets the quantity in MillimetresPerPercent
        /// </summary>
        public double MillimetresPerPercent => 10 * this.metresPerUnitless;

        /// <summary>
        /// Gets the quantity in MicrometresPerPercent
        /// </summary>
        public double MicrometresPerPercent => 10000 * this.metresPerUnitless;

        /// <summary>
        /// Gets the quantity in MetresPerPercent
        /// </summary>
        public double MetresPerPercent => this.metresPerUnitless / 100;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the multiplication.</returns>
        public static Length operator *(LengthPerUnitless left, Unitless right)
        {
            return Length.FromMetres(left.metresPerUnitless * right.scalar);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ForcePerUnitless"/> that is the result from the multiplication.</returns>
        public static ForcePerUnitless operator *(LengthPerUnitless left, Stiffness right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.metresPerUnitless * right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ForcePerUnitless"/> that is the result from the division.</returns>
        public static ForcePerUnitless operator /(LengthPerUnitless left, Flexibility right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.metresPerUnitless / right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Flexibility"/> that is the result from the division.</returns>
        public static Flexibility operator /(LengthPerUnitless left, ForcePerUnitless right)
        {
            return Flexibility.FromMetresPerNewton(left.metresPerUnitless / right.newtonsPerUnitless);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless / right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthPerUnitless"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator ==(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthPerUnitless"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator !=(LengthPerUnitless left, LengthPerUnitless right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is less than another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator <(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless < right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is greater than another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator >(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless > right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is less than or equal to another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator <=(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless <= right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is greater than or equal to another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator >=(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless >= right.metresPerUnitless;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.LengthPerUnitless"/> and returns the result.</returns>
        public static LengthPerUnitless operator *(double left, LengthPerUnitless right)
        {
            return new LengthPerUnitless(left * right.metresPerUnitless);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static LengthPerUnitless operator *(LengthPerUnitless left, double right)
        {
            return new LengthPerUnitless(left.metresPerUnitless * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.LengthPerUnitless"/> by <paramref name="right"/> and returns the result.</returns>
        public static LengthPerUnitless operator /(LengthPerUnitless left, double right)
        {
            return new LengthPerUnitless(left.metresPerUnitless / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.LengthPerUnitless"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LengthPerUnitless"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static LengthPerUnitless operator +(LengthPerUnitless left, LengthPerUnitless right)
        {
            return new LengthPerUnitless(left.metresPerUnitless + right.metresPerUnitless);
        }

        /// <summary>
        /// Subtracts an LengthPerUnitless from another LengthPerUnitless and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LengthPerUnitless"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthPerUnitless"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthPerUnitless"/> (the subtrahend).</param>
        public static LengthPerUnitless operator -(LengthPerUnitless left, LengthPerUnitless right)
        {
            return new LengthPerUnitless(left.metresPerUnitless - right.metresPerUnitless);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.LengthPerUnitless"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LengthPerUnitless"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="lengthPerUnitless">An instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        public static LengthPerUnitless operator -(LengthPerUnitless lengthPerUnitless)
        {
            return new LengthPerUnitless(-1 * lengthPerUnitless.metresPerUnitless);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="lengthPerUnitless"/>.
        /// </returns>
        /// <param name="lengthPerUnitless">An instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        public static LengthPerUnitless operator +(LengthPerUnitless lengthPerUnitless)
        {
            return lengthPerUnitless;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns>The <see cref="Gu.Units.LengthPerUnitless"/> parsed from <paramref name="text"/></returns>
        public static LengthPerUnitless Parse(string text)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.LengthPerUnitless"/> parsed from <paramref name="text"/></returns>
        public static LengthPerUnitless Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.LengthPerUnitless"/> parsed from <paramref name="text"/></returns>
        public static LengthPerUnitless Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.LengthPerUnitless"/> parsed from <paramref name="text"/></returns>
        public static LengthPerUnitless Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="result">The parsed <see cref="LengthPerUnitless"/></param>
        /// <returns>True if an instance of <see cref="LengthPerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="LengthPerUnitless"/></param>
        /// <returns>True if an instance of <see cref="LengthPerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="LengthPerUnitless"/></param>
        /// <returns>True if an instance of <see cref="LengthPerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="LengthPerUnitless"/></param>
        /// <returns>True if an instance of <see cref="LengthPerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.LengthPerUnitless"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.LengthPerUnitless"/></returns>
        public static LengthPerUnitless ReadFrom(XmlReader reader)
        {
            var v = default(LengthPerUnitless);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.LengthPerUnitless"/></returns>
        public static LengthPerUnitless From(double value, LengthPerUnitlessUnit unit)
        {
            return new LengthPerUnitless(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="metresPerUnitless">The value in <see cref="Gu.Units.LengthPerUnitlessUnit.MetresPerUnitless"/></param>
        /// <returns>An instance of <see cref="Gu.Units.LengthPerUnitless"/></returns>
        public static LengthPerUnitless FromMetresPerUnitless(double metresPerUnitless)
        {
            return new LengthPerUnitless(metresPerUnitless);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="millimetresPerPercent">The value in mm/%.</param>
        /// <returns>An instance of <see cref="Gu.Units.LengthPerUnitless"/></returns>
        public static LengthPerUnitless FromMillimetresPerPercent(double millimetresPerPercent)
        {
            return new LengthPerUnitless(millimetresPerPercent / 10);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="micrometresPerPercent">The value in μm/%.</param>
        /// <returns>An instance of <see cref="Gu.Units.LengthPerUnitless"/></returns>
        public static LengthPerUnitless FromMicrometresPerPercent(double micrometresPerPercent)
        {
            return new LengthPerUnitless(micrometresPerPercent / 10000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="metresPerPercent">The value in m/%.</param>
        /// <returns>An instance of <see cref="Gu.Units.LengthPerUnitless"/></returns>
        public static LengthPerUnitless FromMetresPerPercent(double metresPerPercent)
        {
            return new LengthPerUnitless(100 * metresPerPercent);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(LengthPerUnitlessUnit unit)
        {
            return unit.FromSiUnit(this.metresPerUnitless);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/ul\"</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/ul\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m/ul</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m/ul</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthPerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthPerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthPerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthPerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthPerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthPerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthPerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, LengthPerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.LengthPerUnitless"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.LengthPerUnitless"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.LengthPerUnitless"/> object to compare to this instance.</param>
        public int CompareTo(LengthPerUnitless quantity)
        {
            return this.metresPerUnitless.CompareTo(quantity.metresPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LengthPerUnitless"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LengthPerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.LengthPerUnitless"/> object to compare with this instance.</param>
        public bool Equals(LengthPerUnitless other)
        {
            return this.metresPerUnitless.Equals(other.metresPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LengthPerUnitless"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LengthPerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.LengthPerUnitless"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(LengthPerUnitless other, LengthPerUnitless tolerance)
        {
            Ensure.GreaterThan(tolerance.metresPerUnitless, 0, nameof(tolerance));
            return Math.Abs(this.metresPerUnitless - other.metresPerUnitless) < tolerance.metresPerUnitless;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LengthPerUnitless"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.LengthPerUnitless"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is LengthPerUnitless other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.metresPerUnitless.GetHashCode();
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
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "metresPerUnitless", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metresPerUnitless);
        }

        internal string ToString(QuantityFormat<LengthPerUnitlessUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
