﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Jerk"/>.
    /// </summary>
    [TypeConverter(typeof(JerkTypeConverter))]
    [Serializable]
    public partial struct Jerk : IQuantity<JerkUnit>, IComparable<Jerk>, IEquatable<Jerk>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.JerkUnit.MetresPerSecondCubed"/>
        /// </summary>
		public static readonly Jerk Zero = new Jerk();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.JerkUnit.MetresPerSecondCubed"/>.
        /// </summary>
        internal readonly double metresPerSecondCubed;

        private Jerk(double metresPerSecondCubed)
        {
            this.metresPerSecondCubed = metresPerSecondCubed;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.JerkUnit"/>.</param>
        public Jerk(double value, JerkUnit unit)
        {
            this.metresPerSecondCubed = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.JerkUnit.MetresPerSecondCubed"/>
        /// </summary>
        public double SiValue => this.metresPerSecondCubed;

        /// <summary>
        /// The <see cref="Gu.Units.JerkUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public JerkUnit SiUnit => JerkUnit.MetresPerSecondCubed;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => JerkUnit.MetresPerSecondCubed;

        /// <summary>
        /// The quantity in metresPerSecondCubed".
        /// </summary>
        public double MetresPerSecondCubed => this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in MillimetresPerSecondCubed
        /// </summary>
        public double MillimetresPerSecondCubed => 1000 * this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in CentimetresPerSecondCubed
        /// </summary>
        public double CentimetresPerSecondCubed => 100 * this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in MillimetresPerHourCubed
        /// </summary>
        public double MillimetresPerHourCubed => 46656000000000 * this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in MillimetresPerMinuteCubed
        /// </summary>
        public double MillimetresPerMinuteCubed => 216000000 * this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in MetresPerHourCubed
        /// </summary>
        public double MetresPerHourCubed => 46656000000 * this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in MetresPerMinuteCubed
        /// </summary>
        public double MetresPerMinuteCubed => 216000 * this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in CentimetresPerHourCubed
        /// </summary>
        public double CentimetresPerHourCubed => 4665600000000 * this.metresPerSecondCubed;


        /// <summary>
        /// The quantity in CentimetresPerMinuteCubed
        /// </summary>
        public double CentimetresPerMinuteCubed => 21600000 * this.metresPerSecondCubed;


        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <returns>The <see cref="Gu.Units.Jerk"/> parsed from <paramref name="text"/></returns>
		public static Jerk Parse(string text)
        {
            return QuantityParser.Parse<JerkUnit, Jerk>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Jerk"/> parsed from <paramref name="text"/></returns>
        public static Jerk Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<JerkUnit, Jerk>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Jerk"/> parsed from <paramref name="text"/></returns>
        public static Jerk Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<JerkUnit, Jerk>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Jerk"/> parsed from <paramref name="text"/></returns>
        public static Jerk Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<JerkUnit, Jerk>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <param name="result">The parsed <see cref="Jerk"/></param>
        /// <returns>True if an instance of <see cref="Jerk"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Jerk result)
        {
            return QuantityParser.TryParse<JerkUnit, Jerk>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Jerk"/></param>
        /// <returns>True if an instance of <see cref="Jerk"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, IFormatProvider provider, out Jerk result)
        {
            return QuantityParser.TryParse<JerkUnit, Jerk>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Jerk"/></param>
        /// <returns>True if an instance of <see cref="Jerk"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, out Jerk result)
        {
            return QuantityParser.TryParse<JerkUnit, Jerk>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Jerk"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Jerk"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Jerk"/></param>
        /// <returns>True if an instance of <see cref="Jerk"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Jerk result)
        {
            return QuantityParser.TryParse<JerkUnit, Jerk>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Jerk"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Jerk"/></returns>
        public static Jerk ReadFrom(XmlReader reader)
        {
            var v = new Jerk();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Jerk From(double value, JerkUnit unit)
        {
            return new Jerk(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="metresPerSecondCubed">The value in <see cref="Gu.Units.JerkUnit.MetresPerSecondCubed"/></param>
        public static Jerk FromMetresPerSecondCubed(double metresPerSecondCubed)
        {
            return new Jerk(metresPerSecondCubed);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="millimetresPerSecondCubed">The value in mm⋅s⁻³</param>
        public static Jerk FromMillimetresPerSecondCubed(double millimetresPerSecondCubed)
        {
            return new Jerk(millimetresPerSecondCubed / 1000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="centimetresPerSecondCubed">The value in cm⋅s⁻³</param>
        public static Jerk FromCentimetresPerSecondCubed(double centimetresPerSecondCubed)
        {
            return new Jerk(centimetresPerSecondCubed / 100);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="millimetresPerHourCubed">The value in mm⋅h⁻³</param>
        public static Jerk FromMillimetresPerHourCubed(double millimetresPerHourCubed)
        {
            return new Jerk(millimetresPerHourCubed / 46656000000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="millimetresPerMinuteCubed">The value in mm⋅min⁻³</param>
        public static Jerk FromMillimetresPerMinuteCubed(double millimetresPerMinuteCubed)
        {
            return new Jerk(millimetresPerMinuteCubed / 216000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="metresPerHourCubed">The value in m⋅h⁻³</param>
        public static Jerk FromMetresPerHourCubed(double metresPerHourCubed)
        {
            return new Jerk(metresPerHourCubed / 46656000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="metresPerMinuteCubed">The value in m⋅min⁻³</param>
        public static Jerk FromMetresPerMinuteCubed(double metresPerMinuteCubed)
        {
            return new Jerk(metresPerMinuteCubed / 216000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="centimetresPerHourCubed">The value in cm⋅h⁻³</param>
        public static Jerk FromCentimetresPerHourCubed(double centimetresPerHourCubed)
        {
            return new Jerk(centimetresPerHourCubed / 4665600000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <param name="centimetresPerMinuteCubed">The value in cm⋅min⁻³</param>
        public static Jerk FromCentimetresPerMinuteCubed(double centimetresPerMinuteCubed)
        {
            return new Jerk(centimetresPerMinuteCubed / 21600000);
        }



        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the multiplication.</returns>
        public static Acceleration operator *(Jerk left, Time right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.metresPerSecondCubed * right.seconds);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the division.</returns>
        public static Acceleration operator /(Jerk left, Frequency right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.metresPerSecondCubed / right.hertz);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(Jerk left, Acceleration right)
        {
            return Frequency.FromHertz(left.metresPerSecondCubed / right.metresPerSecondSquared);
        }



        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Jerk left, Jerk right)
        {
            return left.metresPerSecondCubed / right.metresPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Jerk"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        public static bool operator ==(Jerk left, Jerk right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Jerk"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        public static bool operator !=(Jerk left, Jerk right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Jerk"/> is less than another specified <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        public static bool operator <(Jerk left, Jerk right)
        {
            return left.metresPerSecondCubed < right.metresPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Jerk"/> is greater than another specified <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        public static bool operator >(Jerk left, Jerk right)
        {
            return left.metresPerSecondCubed > right.metresPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Jerk"/> is less than or equal to another specified <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        public static bool operator <=(Jerk left, Jerk right)
        {
            return left.metresPerSecondCubed <= right.metresPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Jerk"/> is greater than or equal to another specified <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        public static bool operator >=(Jerk left, Jerk right)
        {
            return left.metresPerSecondCubed >= right.metresPerSecondCubed;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Jerk"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Jerk"/> with <paramref name="left"/> and returns the result.</returns>
        public static Jerk operator *(double left, Jerk right)
        {
            return new Jerk(left * right.metresPerSecondCubed);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Jerk"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Jerk"/> with <paramref name="right"/> and returns the result.</returns>
        public static Jerk operator *(Jerk left, double right)
        {
            return new Jerk(left.metresPerSecondCubed * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Jerk"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Jerk"/> with <paramref name="right"/> and returns the result.</returns>
        public static Jerk operator /(Jerk left, double right)
        {
            return new Jerk(left.metresPerSecondCubed / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Jerk"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Jerk"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/>.</param>
        public static Jerk operator +(Jerk left, Jerk right)
        {
            return new Jerk(left.metresPerSecondCubed + right.metresPerSecondCubed);
        }

        /// <summary>
        /// Subtracts an Jerk from another Jerk and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Jerk"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Jerk"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Jerk"/> (the subtrahend).</param>
        public static Jerk operator -(Jerk left, Jerk right)
        {
            return new Jerk(left.metresPerSecondCubed - right.metresPerSecondCubed);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Jerk"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Jerk"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="jerk">An instance of <see cref="Gu.Units.Jerk"/></param>
        public static Jerk operator -(Jerk jerk)
        {
            return new Jerk(-1 * jerk.metresPerSecondCubed);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Jerk"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="jerk"/>.
        /// </returns>
        /// <param name="jerk">An instance of <see cref="Gu.Units.Jerk"/></param>
        public static Jerk operator +(Jerk jerk)
        {
            return jerk;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(JerkUnit unit)
        {
            return unit.FromSiUnit(this.metresPerSecondCubed);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Jerk"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Jerk"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/s³\"</param>
        /// <returns>The string representation of the <see cref="Jerk"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/s³\"</param>
		/// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Jerk"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m/s³</param>
        /// <returns>The string representation of the <see cref="Jerk"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m/s³</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Jerk"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(JerkUnit unit)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(JerkUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(JerkUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(JerkUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, JerkUnit unit)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(string valueFormat, JerkUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, JerkUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, JerkUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<JerkUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<JerkUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Jerk"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Jerk"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Jerk"/> object to compare to this instance.</param>
        public int CompareTo(Jerk quantity)
        {
            return this.metresPerSecondCubed.CompareTo(quantity.metresPerSecondCubed);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Jerk"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Jerk as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Jerk"/> object to compare with this instance.</param>
        public bool Equals(Jerk other)
        {
            return this.metresPerSecondCubed.Equals(other.metresPerSecondCubed);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Jerk"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Jerk as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Jerk"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Jerk other, Jerk tolerance)
        {
            Ensure.GreaterThan(tolerance.metresPerSecondCubed, 0, nameof(tolerance));
            return Math.Abs(this.metresPerSecondCubed - other.metresPerSecondCubed) < tolerance.metresPerSecondCubed;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Jerk"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Jerk"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Jerk && this.Equals((Jerk)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.metresPerSecondCubed.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "metresPerSecondCubed", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metresPerSecondCubed);
        }
    }
}