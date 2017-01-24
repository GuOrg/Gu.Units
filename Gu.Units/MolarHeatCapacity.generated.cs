





namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.MolarHeatCapacity"/>.
    /// </summary>
    [TypeConverter(typeof(MolarHeatCapacityTypeConverter))]
    [Serializable]
    public partial struct MolarHeatCapacity : IQuantity<MolarHeatCapacityUnit>, IComparable<MolarHeatCapacity>, IEquatable<MolarHeatCapacity>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.MolarHeatCapacityUnit.JoulesPerKelvinMole"/>
        /// </summary>
		public static readonly MolarHeatCapacity Zero = new MolarHeatCapacity();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MolarHeatCapacityUnit.JoulesPerKelvinMole"/>.
        /// </summary>
        internal readonly double joulesPerKelvinMole;

        private MolarHeatCapacity(double joulesPerKelvinMole)
        {
            this.joulesPerKelvinMole = joulesPerKelvinMole;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.MolarHeatCapacityUnit"/>.</param>
        public MolarHeatCapacity(double value, MolarHeatCapacityUnit unit)
        {
            this.joulesPerKelvinMole = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MolarHeatCapacityUnit.JoulesPerKelvinMole"/>
        /// </summary>
        public double SiValue => this.joulesPerKelvinMole;

        /// <summary>
        /// The <see cref="Gu.Units.MolarHeatCapacityUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MolarHeatCapacityUnit SiUnit => MolarHeatCapacityUnit.JoulesPerKelvinMole;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MolarHeatCapacityUnit.JoulesPerKelvinMole;

        /// <summary>
        /// The quantity in joulesPerKelvinMole".
        /// </summary>
        public double JoulesPerKelvinMole => this.joulesPerKelvinMole;


        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <returns>The <see cref="Gu.Units.MolarHeatCapacity"/> parsed from <paramref name="text"/></returns>
		public static MolarHeatCapacity Parse(string text)
        {
            return QuantityParser.Parse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MolarHeatCapacity"/> parsed from <paramref name="text"/></returns>
        public static MolarHeatCapacity Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.MolarHeatCapacity"/> parsed from <paramref name="text"/></returns>
        public static MolarHeatCapacity Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MolarHeatCapacity"/> parsed from <paramref name="text"/></returns>
        public static MolarHeatCapacity Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="result">The parsed <see cref="MolarHeatCapacity"/></param>
        /// <returns>True if an instance of <see cref="MolarHeatCapacity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MolarHeatCapacity result)
        {
            return QuantityParser.TryParse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MolarHeatCapacity"/></param>
        /// <returns>True if an instance of <see cref="MolarHeatCapacity"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, IFormatProvider provider, out MolarHeatCapacity result)
        {
            return QuantityParser.TryParse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="MolarHeatCapacity"/></param>
        /// <returns>True if an instance of <see cref="MolarHeatCapacity"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, out MolarHeatCapacity result)
        {
            return QuantityParser.TryParse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MolarHeatCapacity"/></param>
        /// <returns>True if an instance of <see cref="MolarHeatCapacity"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out MolarHeatCapacity result)
        {
            return QuantityParser.TryParse<MolarHeatCapacityUnit, MolarHeatCapacity>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.MolarHeatCapacity"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.MolarHeatCapacity"/></returns>
        public static MolarHeatCapacity ReadFrom(XmlReader reader)
        {
            var v = new MolarHeatCapacity();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static MolarHeatCapacity From(double value, MolarHeatCapacityUnit unit)
        {
            return new MolarHeatCapacity(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <param name="joulesPerKelvinMole">The value in <see cref="Gu.Units.MolarHeatCapacityUnit.JoulesPerKelvinMole"/></param>
        public static MolarHeatCapacity FromJoulesPerKelvinMole(double joulesPerKelvinMole)
        {
            return new MolarHeatCapacity(joulesPerKelvinMole);
        }




        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return left.joulesPerKelvinMole / right.joulesPerKelvinMole;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarHeatCapacity"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public static bool operator ==(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarHeatCapacity"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public static bool operator !=(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarHeatCapacity"/> is less than another specified <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public static bool operator <(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return left.joulesPerKelvinMole < right.joulesPerKelvinMole;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarHeatCapacity"/> is greater than another specified <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public static bool operator >(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return left.joulesPerKelvinMole > right.joulesPerKelvinMole;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarHeatCapacity"/> is less than or equal to another specified <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public static bool operator <=(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return left.joulesPerKelvinMole <= right.joulesPerKelvinMole;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MolarHeatCapacity"/> is greater than or equal to another specified <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public static bool operator >=(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return left.joulesPerKelvinMole >= right.joulesPerKelvinMole;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MolarHeatCapacity"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.MolarHeatCapacity"/> with <paramref name="left"/> and returns the result.</returns>
        public static MolarHeatCapacity operator *(double left, MolarHeatCapacity right)
        {
            return new MolarHeatCapacity(left * right.joulesPerKelvinMole);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MolarHeatCapacity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.MolarHeatCapacity"/> with <paramref name="right"/> and returns the result.</returns>
        public static MolarHeatCapacity operator *(MolarHeatCapacity left, double right)
        {
            return new MolarHeatCapacity(left.joulesPerKelvinMole * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.MolarHeatCapacity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.MolarHeatCapacity"/> with <paramref name="right"/> and returns the result.</returns>
        public static MolarHeatCapacity operator /(MolarHeatCapacity left, double right)
        {
            return new MolarHeatCapacity(left.joulesPerKelvinMole / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.MolarHeatCapacity"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MolarHeatCapacity"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public static MolarHeatCapacity operator +(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return new MolarHeatCapacity(left.joulesPerKelvinMole + right.joulesPerKelvinMole);
        }

        /// <summary>
        /// Subtracts an MolarHeatCapacity from another MolarHeatCapacity and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MolarHeatCapacity"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarHeatCapacity"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarHeatCapacity"/> (the subtrahend).</param>
        public static MolarHeatCapacity operator -(MolarHeatCapacity left, MolarHeatCapacity right)
        {
            return new MolarHeatCapacity(left.joulesPerKelvinMole - right.joulesPerKelvinMole);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.MolarHeatCapacity"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MolarHeatCapacity"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="molarHeatCapacity">An instance of <see cref="Gu.Units.MolarHeatCapacity"/></param>
        public static MolarHeatCapacity operator -(MolarHeatCapacity molarHeatCapacity)
        {
            return new MolarHeatCapacity(-1 * molarHeatCapacity.joulesPerKelvinMole);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.MolarHeatCapacity"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="molarHeatCapacity"/>.
        /// </returns>
        /// <param name="molarHeatCapacity">An instance of <see cref="Gu.Units.MolarHeatCapacity"/></param>
        public static MolarHeatCapacity operator +(MolarHeatCapacity molarHeatCapacity)
        {
            return molarHeatCapacity;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MolarHeatCapacityUnit unit)
        {
            return unit.FromSiUnit(this.joulesPerKelvinMole);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MolarHeatCapacity"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MolarHeatCapacity"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 J/K⋅mol\"</param>
        /// <returns>The string representation of the <see cref="MolarHeatCapacity"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 J/K⋅mol\"</param>
		/// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MolarHeatCapacity"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex J/K⋅mol</param>
        /// <returns>The string representation of the <see cref="MolarHeatCapacity"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex J/K⋅mol</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="MolarHeatCapacity"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MolarHeatCapacityUnit unit)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(MolarHeatCapacityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(MolarHeatCapacityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(MolarHeatCapacityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MolarHeatCapacityUnit unit)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(string valueFormat, MolarHeatCapacityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MolarHeatCapacityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>/// 
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MolarHeatCapacityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MolarHeatCapacityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<MolarHeatCapacityUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.MolarHeatCapacity"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.MolarHeatCapacity"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// 
        ///                     Value
        /// 
        ///                     Description
        /// 
        ///                     A negative integer
        /// 
        ///                     This instance is smaller than <paramref name="quantity"/>.
        /// 
        ///                     Zero
        /// 
        ///                     This instance is equal to <paramref name="quantity"/>.
        /// 
        ///                     A positive integer
        /// 
        ///                     This instance is larger than <paramref name="quantity"/>.
        /// 
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.MolarHeatCapacity"/> object to compare to this instance.</param>
        public int CompareTo(MolarHeatCapacity quantity)
        {
            return this.joulesPerKelvinMole.CompareTo(quantity.joulesPerKelvinMole);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarHeatCapacity"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MolarHeatCapacity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MolarHeatCapacity"/> object to compare with this instance.</param>
        public bool Equals(MolarHeatCapacity other)
        {
            return this.joulesPerKelvinMole.Equals(other.joulesPerKelvinMole);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarHeatCapacity"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MolarHeatCapacity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MolarHeatCapacity"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(MolarHeatCapacity other, MolarHeatCapacity tolerance)
        {
            Ensure.GreaterThan(tolerance.joulesPerKelvinMole, 0, nameof(tolerance));
            return Math.Abs(this.joulesPerKelvinMole - other.joulesPerKelvinMole) < tolerance.joulesPerKelvinMole;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarHeatCapacity"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.MolarHeatCapacity"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MolarHeatCapacity && this.Equals((MolarHeatCapacity)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.joulesPerKelvinMole.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "joulesPerKelvinMole", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.joulesPerKelvinMole);
        }
    }
}