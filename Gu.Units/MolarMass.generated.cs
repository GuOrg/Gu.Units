namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.MolarMass"/>.
    /// </summary>
    [TypeConverter(typeof(MolarMassTypeConverter))]
    [Serializable]
    public partial struct MolarMass : IQuantity<MolarMassUnit>, IComparable<MolarMass>, IEquatable<MolarMass>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.MolarMassUnit.KilogramsPerMole"/>
        /// </summary>
        public static readonly MolarMass Zero = default(MolarMass);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.MolarMassUnit.KilogramsPerMole"/>.
        /// </summary>
        internal readonly double kilogramsPerMole;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.MolarMass"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.MolarMassUnit"/>.</param>
        public MolarMass(double value, MolarMassUnit unit)
        {
            this.kilogramsPerMole = unit.ToSiUnit(value);
        }

        private MolarMass(double kilogramsPerMole)
        {
            this.kilogramsPerMole = kilogramsPerMole;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.MolarMassUnit.KilogramsPerMole"/>
        /// </summary>
        public double SiValue => this.kilogramsPerMole;

        /// <summary>
        /// Gets the <see cref="Gu.Units.MolarMassUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MolarMassUnit SiUnit => MolarMassUnit.KilogramsPerMole;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MolarMassUnit.KilogramsPerMole;

        /// <summary>
        /// Gets the quantity in kilogramsPerMole".
        /// </summary>
        public double KilogramsPerMole => this.kilogramsPerMole;

        /// <summary>
        /// Gets the quantity in GramsPerMole
        /// </summary>
        public double GramsPerMole => 1000 * this.kilogramsPerMole;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the multiplication.</returns>
        public static Mass operator *(MolarMass left, AmountOfSubstance right)
        {
            return Mass.FromKilograms(left.kilogramsPerMole * right.moles);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(MolarMass left, CatalyticActivity right)
        {
            return MassFlow.FromKilogramsPerSecond(left.kilogramsPerMole * right.katals);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(MolarMass left, MolarMass right)
        {
            return left.kilogramsPerMole / right.kilogramsPerMole;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarMass"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/>.</param>
        public static bool operator ==(MolarMass left, MolarMass right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarMass"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/>.</param>
        public static bool operator !=(MolarMass left, MolarMass right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarMass"/> is less than another specified <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/>.</param>
        public static bool operator <(MolarMass left, MolarMass right)
        {
            return left.kilogramsPerMole < right.kilogramsPerMole;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarMass"/> is greater than another specified <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/>.</param>
        public static bool operator >(MolarMass left, MolarMass right)
        {
            return left.kilogramsPerMole > right.kilogramsPerMole;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarMass"/> is less than or equal to another specified <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/>.</param>
        public static bool operator <=(MolarMass left, MolarMass right)
        {
            return left.kilogramsPerMole <= right.kilogramsPerMole;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarMass"/> is greater than or equal to another specified <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/>.</param>
        public static bool operator >=(MolarMass left, MolarMass right)
        {
            return left.kilogramsPerMole >= right.kilogramsPerMole;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MolarMass"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.MolarMass"/> and returns the result.</returns>
        public static MolarMass operator *(double left, MolarMass right)
        {
            return new MolarMass(left * right.kilogramsPerMole);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MolarMass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.MolarMass"/> with <paramref name="right"/> and returns the result.</returns>
        public static MolarMass operator *(MolarMass left, double right)
        {
            return new MolarMass(left.kilogramsPerMole * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.MolarMass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.MolarMass"/> by <paramref name="right"/> and returns the result.</returns>
        public static MolarMass operator /(MolarMass left, double right)
        {
            return new MolarMass(left.kilogramsPerMole / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.MolarMass"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MolarMass"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/>.</param>
        public static MolarMass operator +(MolarMass left, MolarMass right)
        {
            return new MolarMass(left.kilogramsPerMole + right.kilogramsPerMole);
        }

        /// <summary>
        /// Subtracts an MolarMass from another MolarMass and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MolarMass"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarMass"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarMass"/> (the subtrahend).</param>
        public static MolarMass operator -(MolarMass left, MolarMass right)
        {
            return new MolarMass(left.kilogramsPerMole - right.kilogramsPerMole);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.MolarMass"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MolarMass"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="molarMass">An instance of <see cref="Gu.Units.MolarMass"/></param>
        public static MolarMass operator -(MolarMass molarMass)
        {
            return new MolarMass(-1 * molarMass.kilogramsPerMole);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="molarMass"/>.
        /// </returns>
        /// <param name="molarMass">An instance of <see cref="Gu.Units.MolarMass"/></param>
        public static MolarMass operator +(MolarMass molarMass)
        {
            return molarMass;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <returns>The <see cref="Gu.Units.MolarMass"/> parsed from <paramref name="text"/></returns>
        public static MolarMass Parse(string text)
        {
            return QuantityParser.Parse<MolarMassUnit, MolarMass>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MolarMass"/> parsed from <paramref name="text"/></returns>
        public static MolarMass Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MolarMassUnit, MolarMass>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.MolarMass"/> parsed from <paramref name="text"/></returns>
        public static MolarMass Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MolarMassUnit, MolarMass>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MolarMass"/> parsed from <paramref name="text"/></returns>
        public static MolarMass Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MolarMassUnit, MolarMass>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="result">The parsed <see cref="MolarMass"/></param>
        /// <returns>True if an instance of <see cref="MolarMass"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MolarMass result)
        {
            return QuantityParser.TryParse<MolarMassUnit, MolarMass>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MolarMass"/></param>
        /// <returns>True if an instance of <see cref="MolarMass"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out MolarMass result)
        {
            return QuantityParser.TryParse<MolarMassUnit, MolarMass>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="MolarMass"/></param>
        /// <returns>True if an instance of <see cref="MolarMass"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out MolarMass result)
        {
            return QuantityParser.TryParse<MolarMassUnit, MolarMass>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MolarMass"/></param>
        /// <returns>True if an instance of <see cref="MolarMass"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out MolarMass result)
        {
            return QuantityParser.TryParse<MolarMassUnit, MolarMass>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.MolarMass"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.MolarMass"/></returns>
        public static MolarMass ReadFrom(XmlReader reader)
        {
            var v = default(MolarMass);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.MolarMass"/></returns>
        public static MolarMass From(double value, MolarMassUnit unit)
        {
            return new MolarMass(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <param name="kilogramsPerMole">The value in <see cref="Gu.Units.MolarMassUnit.KilogramsPerMole"/></param>
        /// <returns>An instance of <see cref="Gu.Units.MolarMass"/></returns>
        public static MolarMass FromKilogramsPerMole(double kilogramsPerMole)
        {
            return new MolarMass(kilogramsPerMole);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MolarMass"/>.
        /// </summary>
        /// <param name="gramsPerMole">The value in g/mol.</param>
        /// <returns>An instance of <see cref="Gu.Units.MolarMass"/></returns>
        public static MolarMass FromGramsPerMole(double gramsPerMole)
        {
            return new MolarMass(gramsPerMole / 1000);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MolarMassUnit unit)
        {
            return unit.FromSiUnit(this.kilogramsPerMole);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MolarMass"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MolarMass"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/mol\"</param>
        /// <returns>The string representation of the <see cref="MolarMass"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/mol\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MolarMass"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex kg/mol</param>
        /// <returns>The string representation of the <see cref="MolarMass"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex kg/mol</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="MolarMass"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MolarMassUnit unit)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MolarMassUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MolarMassUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MolarMassUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MolarMassUnit unit)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MolarMassUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MolarMassUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, MolarMassUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarMassUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.MolarMass"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.MolarMass"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.MolarMass"/> object to compare to this instance.</param>
        public int CompareTo(MolarMass quantity)
        {
            return this.kilogramsPerMole.CompareTo(quantity.kilogramsPerMole);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarMass"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MolarMass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MolarMass"/> object to compare with this instance.</param>
        public bool Equals(MolarMass other)
        {
            return this.kilogramsPerMole.Equals(other.kilogramsPerMole);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarMass"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MolarMass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MolarMass"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(MolarMass other, MolarMass tolerance)
        {
            Ensure.GreaterThan(tolerance.kilogramsPerMole, 0, nameof(tolerance));
            return Math.Abs(this.kilogramsPerMole - other.kilogramsPerMole) < tolerance.kilogramsPerMole;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarMass"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.MolarMass"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MolarMass && this.Equals((MolarMass)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.kilogramsPerMole.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "kilogramsPerMole", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.kilogramsPerMole);
        }

        internal string ToString(QuantityFormat<MolarMassUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
