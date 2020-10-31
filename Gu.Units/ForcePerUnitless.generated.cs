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
    /// A type for the quantity <see cref="Gu.Units.ForcePerUnitless"/>.
    /// </summary>
    [TypeConverter(typeof(ForcePerUnitlessTypeConverter))]
    [Serializable]
    public partial struct ForcePerUnitless : IQuantity<ForcePerUnitlessUnit>, IComparable<ForcePerUnitless>, IEquatable<ForcePerUnitless>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.ForcePerUnitlessUnit.NewtonsPerUnitless"/>
        /// </summary>
        public static readonly ForcePerUnitless Zero = default(ForcePerUnitless);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.ForcePerUnitlessUnit.NewtonsPerUnitless"/>.
        /// </summary>
        internal readonly double newtonsPerUnitless;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.ForcePerUnitless"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.ForcePerUnitlessUnit"/>.</param>
        public ForcePerUnitless(double value, ForcePerUnitlessUnit unit)
        {
            this.newtonsPerUnitless = unit.ToSiUnit(value);
        }

        private ForcePerUnitless(double newtonsPerUnitless)
        {
            this.newtonsPerUnitless = newtonsPerUnitless;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.ForcePerUnitlessUnit.NewtonsPerUnitless"/>
        /// </summary>
        public double SiValue => this.newtonsPerUnitless;

        /// <summary>
        /// Gets the <see cref="Gu.Units.ForcePerUnitlessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ForcePerUnitlessUnit SiUnit => ForcePerUnitlessUnit.NewtonsPerUnitless;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ForcePerUnitlessUnit.NewtonsPerUnitless;

        /// <summary>
        /// Gets the quantity in newtonsPerUnitless".
        /// </summary>
        public double NewtonsPerUnitless => this.newtonsPerUnitless;

        /// <summary>
        /// Gets the quantity in NewtonsPerPercent
        /// </summary>
        public double NewtonsPerPercent => this.newtonsPerUnitless / 100;

        /// <summary>
        /// Gets the quantity in KilonewtonsPerPercent
        /// </summary>
        public double KilonewtonsPerPercent => this.newtonsPerUnitless / 100000;

        /// <summary>
        /// Gets the quantity in MeganewtonsPerPercent
        /// </summary>
        public double MeganewtonsPerPercent => this.newtonsPerUnitless / 100000000;

        /// <summary>
        /// Gets the quantity in GiganewtonsPerPercent
        /// </summary>
        public double GiganewtonsPerPercent => this.newtonsPerUnitless / 100000000000;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(ForcePerUnitless left, Unitless right)
        {
            return Force.FromNewtons(left.newtonsPerUnitless * right.scalar);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LengthPerUnitless"/> that is the result from the division.</returns>
        public static LengthPerUnitless operator /(ForcePerUnitless left, Stiffness right)
        {
            return LengthPerUnitless.FromMetresPerUnitless(left.newtonsPerUnitless / right.newtonsPerMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LengthPerUnitless"/> that is the result from the multiplication.</returns>
        public static LengthPerUnitless operator *(ForcePerUnitless left, Flexibility right)
        {
            return LengthPerUnitless.FromMetresPerUnitless(left.newtonsPerUnitless * right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the division.</returns>
        public static Stiffness operator /(ForcePerUnitless left, LengthPerUnitless right)
        {
            return Stiffness.FromNewtonsPerMetre(left.newtonsPerUnitless / right.metresPerUnitless);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless / right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForcePerUnitless"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator ==(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForcePerUnitless"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator !=(ForcePerUnitless left, ForcePerUnitless right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is less than another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator <(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless < right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is greater than another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator >(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless > right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is less than or equal to another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator <=(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless <= right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is greater than or equal to another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator >=(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless >= right.newtonsPerUnitless;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.ForcePerUnitless"/> and returns the result.</returns>
        public static ForcePerUnitless operator *(double left, ForcePerUnitless right)
        {
            return new ForcePerUnitless(left * right.newtonsPerUnitless);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static ForcePerUnitless operator *(ForcePerUnitless left, double right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.ForcePerUnitless"/> by <paramref name="right"/> and returns the result.</returns>
        public static ForcePerUnitless operator /(ForcePerUnitless left, double right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.ForcePerUnitless"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ForcePerUnitless"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static ForcePerUnitless operator +(ForcePerUnitless left, ForcePerUnitless right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless + right.newtonsPerUnitless);
        }

        /// <summary>
        /// Subtracts an ForcePerUnitless from another ForcePerUnitless and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ForcePerUnitless"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitless"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitless"/> (the subtrahend).</param>
        public static ForcePerUnitless operator -(ForcePerUnitless left, ForcePerUnitless right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless - right.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.ForcePerUnitless"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ForcePerUnitless"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="forcePerUnitless">An instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        public static ForcePerUnitless operator -(ForcePerUnitless forcePerUnitless)
        {
            return new ForcePerUnitless(-1 * forcePerUnitless.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="forcePerUnitless"/>.
        /// </returns>
        /// <param name="forcePerUnitless">An instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        public static ForcePerUnitless operator +(ForcePerUnitless forcePerUnitless)
        {
            return forcePerUnitless;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <returns>The <see cref="Gu.Units.ForcePerUnitless"/> parsed from <paramref name="text"/></returns>
        public static ForcePerUnitless Parse(string text)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.ForcePerUnitless"/> parsed from <paramref name="text"/></returns>
        public static ForcePerUnitless Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.ForcePerUnitless"/> parsed from <paramref name="text"/></returns>
        public static ForcePerUnitless Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.ForcePerUnitless"/> parsed from <paramref name="text"/></returns>
        public static ForcePerUnitless Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="result">The parsed <see cref="ForcePerUnitless"/></param>
        /// <returns>True if an instance of <see cref="ForcePerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out ForcePerUnitless result)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="ForcePerUnitless"/></param>
        /// <returns>True if an instance of <see cref="ForcePerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out ForcePerUnitless result)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="ForcePerUnitless"/></param>
        /// <returns>True if an instance of <see cref="ForcePerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out ForcePerUnitless result)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="ForcePerUnitless"/></param>
        /// <returns>True if an instance of <see cref="ForcePerUnitless"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out ForcePerUnitless result)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.ForcePerUnitless"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless ReadFrom(XmlReader reader)
        {
            var v = default(ForcePerUnitless);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless From(double value, ForcePerUnitlessUnit unit)
        {
            return new ForcePerUnitless(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="newtonsPerUnitless">The value in <see cref="Gu.Units.ForcePerUnitlessUnit.NewtonsPerUnitless"/></param>
        /// <returns>An instance of <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless FromNewtonsPerUnitless(double newtonsPerUnitless)
        {
            return new ForcePerUnitless(newtonsPerUnitless);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="newtonsPerPercent">The value in N/%.</param>
        /// <returns>An instance of <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless FromNewtonsPerPercent(double newtonsPerPercent)
        {
            return new ForcePerUnitless(100 * newtonsPerPercent);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="kilonewtonsPerPercent">The value in kN/%.</param>
        /// <returns>An instance of <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless FromKilonewtonsPerPercent(double kilonewtonsPerPercent)
        {
            return new ForcePerUnitless(100000 * kilonewtonsPerPercent);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="meganewtonsPerPercent">The value in MN/%.</param>
        /// <returns>An instance of <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless FromMeganewtonsPerPercent(double meganewtonsPerPercent)
        {
            return new ForcePerUnitless(100000000 * meganewtonsPerPercent);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="giganewtonsPerPercent">The value in GN/%.</param>
        /// <returns>An instance of <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless FromGiganewtonsPerPercent(double giganewtonsPerPercent)
        {
            return new ForcePerUnitless(100000000000 * giganewtonsPerPercent);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ForcePerUnitlessUnit unit)
        {
            return unit.FromSiUnit(this.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/ul\"</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/ul\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N/ul</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N/ul</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForcePerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForcePerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForcePerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForcePerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ForcePerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ForcePerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ForcePerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, ForcePerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.ForcePerUnitless"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.ForcePerUnitless"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.ForcePerUnitless"/> object to compare to this instance.</param>
        public int CompareTo(ForcePerUnitless quantity)
        {
            return this.newtonsPerUnitless.CompareTo(quantity.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ForcePerUnitless"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ForcePerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ForcePerUnitless"/> object to compare with this instance.</param>
        public bool Equals(ForcePerUnitless other)
        {
            return this.newtonsPerUnitless.Equals(other.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ForcePerUnitless"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ForcePerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ForcePerUnitless"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(ForcePerUnitless other, ForcePerUnitless tolerance)
        {
            Ensure.GreaterThan(tolerance.newtonsPerUnitless, 0, nameof(tolerance));
            return Math.Abs(this.newtonsPerUnitless - other.newtonsPerUnitless) < tolerance.newtonsPerUnitless;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ForcePerUnitless"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.ForcePerUnitless"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is ForcePerUnitless other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.newtonsPerUnitless.GetHashCode();
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

            this  = new ForcePerUnitless(XmlConvert.ToDouble(attribute), ForcePerUnitlessUnit.NewtonsPerUnitless);
            reader.ReadStartElement();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Value");
            writer.WriteValue(this.newtonsPerUnitless);
            writer.WriteEndAttribute();
        }

        internal string ToString(QuantityFormat<ForcePerUnitlessUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
