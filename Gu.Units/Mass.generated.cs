﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Mass"/>.
    /// </summary>
    [TypeConverter(typeof(MassTypeConverter))]
    [Serializable]
    public partial struct Mass : IQuantity<MassUnit>, IComparable<Mass>, IEquatable<Mass>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.MassUnit.Kilograms"/>
        /// </summary>
		public static readonly Mass Zero = new Mass();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MassUnit.Kilograms"/>.
        /// </summary>
        internal readonly double kilograms;

        private Mass(double kilograms)
        {
            this.kilograms = kilograms;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.MassUnit"/>.</param>
        public Mass(double value, MassUnit unit)
        {
            this.kilograms = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MassUnit.Kilograms"/>
        /// </summary>
        public double SiValue => this.kilograms;

        /// <summary>
        /// The <see cref="Gu.Units.MassUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MassUnit SiUnit => MassUnit.Kilograms;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MassUnit.Kilograms;

        /// <summary>
        /// The quantity in kilograms".
        /// </summary>
        public double Kilograms => this.kilograms;


        /// <summary>
        /// The quantity in Grams
        /// </summary>
        public double Grams => 1000 * this.kilograms;


        /// <summary>
        /// The quantity in Milligrams
        /// </summary>
        public double Milligrams => 1000000 * this.kilograms;


        /// <summary>
        /// The quantity in Micrograms
        /// </summary>
        public double Micrograms => 1000000000 * this.kilograms;


        /// <summary>
        /// The quantity in AvoirdupoisPounds
        /// </summary>
        public double AvoirdupoisPounds => this.kilograms / 0.45359237;


        /// <summary>
        /// The quantity in AvoirdupoisOunces
        /// </summary>
        public double AvoirdupoisOunces => this.kilograms / 0.028349523125;


        /// <summary>
        /// The quantity in TroyOunces
        /// </summary>
        public double TroyOunces => this.kilograms / 0.0311034768;


        /// <summary>
        /// The quantity in TroyGrains
        /// </summary>
        public double TroyGrains => this.kilograms / 6.479891E-05;


        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <returns>The <see cref="Gu.Units.Mass"/> parsed from <paramref name="text"/></returns>
		public static Mass Parse(string text)
        {
            return QuantityParser.Parse<MassUnit, Mass>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Mass"/> parsed from <paramref name="text"/></returns>
        public static Mass Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MassUnit, Mass>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Mass"/> parsed from <paramref name="text"/></returns>
        public static Mass Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MassUnit, Mass>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Mass"/> parsed from <paramref name="text"/></returns>
        public static Mass Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MassUnit, Mass>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <param name="result">The parsed <see cref="Mass"/></param>
        /// <returns>True if an instance of <see cref="Mass"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Mass result)
        {
            return QuantityParser.TryParse<MassUnit, Mass>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Mass"/></param>
        /// <returns>True if an instance of <see cref="Mass"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, IFormatProvider provider, out Mass result)
        {
            return QuantityParser.TryParse<MassUnit, Mass>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Mass"/></param>
        /// <returns>True if an instance of <see cref="Mass"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, out Mass result)
        {
            return QuantityParser.TryParse<MassUnit, Mass>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Mass"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Mass"/></param>
        /// <returns>True if an instance of <see cref="Mass"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Mass result)
        {
            return QuantityParser.TryParse<MassUnit, Mass>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Mass"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Mass"/></returns>
        public static Mass ReadFrom(XmlReader reader)
        {
            var v = new Mass();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Mass From(double value, MassUnit unit)
        {
            return new Mass(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="kilograms">The value in <see cref="Gu.Units.MassUnit.Kilograms"/></param>
        public static Mass FromKilograms(double kilograms)
        {
            return new Mass(kilograms);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="grams">The value in g</param>
        public static Mass FromGrams(double grams)
        {
            return new Mass(grams / 1000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="milligrams">The value in mg</param>
        public static Mass FromMilligrams(double milligrams)
        {
            return new Mass(milligrams / 1000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="micrograms">The value in µg</param>
        public static Mass FromMicrograms(double micrograms)
        {
            return new Mass(micrograms / 1000000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="avoirdupoisPounds">The value in lb</param>
        public static Mass FromAvoirdupoisPounds(double avoirdupoisPounds)
        {
            return new Mass(0.45359237 * avoirdupoisPounds);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="avoirdupoisOunces">The value in oz</param>
        public static Mass FromAvoirdupoisOunces(double avoirdupoisOunces)
        {
            return new Mass(0.028349523125 * avoirdupoisOunces);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="troyOunces">The value in troy</param>
        public static Mass FromTroyOunces(double troyOunces)
        {
            return new Mass(0.0311034768 * troyOunces);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="troyGrains">The value in gr</param>
        public static Mass FromTroyGrains(double troyGrains)
        {
            return new Mass(6.479891E-05 * troyGrains);
        }



        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(Mass left, Time right)
        {
            return MassFlow.FromKilogramsPerSecond(left.kilograms / right.seconds);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MolarMass"/> that is the result from the division.</returns>
        public static MolarMass operator /(Mass left, AmountOfSubstance right)
        {
            return MolarMass.FromKilogramsPerMole(left.kilograms / right.moles);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the division.</returns>
        public static AreaDensity operator /(Mass left, Area right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.kilograms / right.squareMetres);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Density"/> that is the result from the division.</returns>
        public static Density operator /(Mass left, Volume right)
        {
            return Density.FromKilogramsPerCubicMetre(left.kilograms / right.cubicMetres);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the division.</returns>
        public static Volume operator /(Mass left, Density right)
        {
            return Volume.FromCubicMetres(left.kilograms / right.kilogramsPerCubicMetre);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the multiplication.</returns>
        public static Momentum operator *(Mass left, Speed right)
        {
            return Momentum.FromNewtonSecond(left.kilograms * right.metresPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(Mass left, Frequency right)
        {
            return MassFlow.FromKilogramsPerSecond(left.kilograms * right.hertz);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Mass left, Acceleration right)
        {
            return Force.FromNewtons(left.kilograms * right.metresPerSecondSquared);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Mass left, SpecificEnergy right)
        {
            return Energy.FromJoules(left.kilograms * right.joulesPerKilogram);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the division.</returns>
        public static Area operator /(Mass left, AreaDensity right)
        {
            return Area.FromSquareMetres(left.kilograms / right.kilogramsPerSquareMetre);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the multiplication.</returns>
        public static Volume operator *(Mass left, SpecificVolume right)
        {
            return Volume.FromCubicMetres(left.kilograms * right.cubicMetresPerKilogram);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Mass left, MassFlow right)
        {
            return Time.FromSeconds(left.kilograms / right.kilogramsPerSecond);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AmountOfSubstance"/> that is the result from the division.</returns>
        public static AmountOfSubstance operator /(Mass left, MolarMass right)
        {
            return AmountOfSubstance.FromMoles(left.kilograms / right.kilogramsPerMole);
        }



        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Mass left, Mass right)
        {
            return left.kilograms / right.kilograms;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Mass"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/>.</param>
        public static bool operator ==(Mass left, Mass right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Mass"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/>.</param>
        public static bool operator !=(Mass left, Mass right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Mass"/> is less than another specified <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/>.</param>
        public static bool operator <(Mass left, Mass right)
        {
            return left.kilograms < right.kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Mass"/> is greater than another specified <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/>.</param>
        public static bool operator >(Mass left, Mass right)
        {
            return left.kilograms > right.kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Mass"/> is less than or equal to another specified <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/>.</param>
        public static bool operator <=(Mass left, Mass right)
        {
            return left.kilograms <= right.kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Mass"/> is greater than or equal to another specified <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/>.</param>
        public static bool operator >=(Mass left, Mass right)
        {
            return left.kilograms >= right.kilograms;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Mass"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Mass"/> with <paramref name="left"/> and returns the result.</returns>
        public static Mass operator *(double left, Mass right)
        {
            return new Mass(left * right.kilograms);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.</returns>
        public static Mass operator *(Mass left, double right)
        {
            return new Mass(left.kilograms * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.</returns>
        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left.kilograms / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Mass"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Mass"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/>.</param>
        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left.kilograms + right.kilograms);
        }

        /// <summary>
        /// Subtracts an Mass from another Mass and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Mass"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Mass"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Mass"/> (the subtrahend).</param>
        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left.kilograms - right.kilograms);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Mass"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Mass"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="mass">An instance of <see cref="Gu.Units.Mass"/></param>
        public static Mass operator -(Mass mass)
        {
            return new Mass(-1 * mass.kilograms);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="mass"/>.
        /// </returns>
        /// <param name="mass">An instance of <see cref="Gu.Units.Mass"/></param>
        public static Mass operator +(Mass mass)
        {
            return mass;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MassUnit unit)
        {
            return unit.FromSiUnit(this.kilograms);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Mass"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Mass"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg\"</param>
        /// <returns>The string representation of the <see cref="Mass"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg\"</param>
		/// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Mass"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex kg</param>
        /// <returns>The string representation of the <see cref="Mass"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex kg</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Mass"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MassUnit unit)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(MassUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(MassUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(MassUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MassUnit unit)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(string valueFormat, MassUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MassUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, MassUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<MassUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Mass"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Mass"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Mass"/> object to compare to this instance.</param>
        public int CompareTo(Mass quantity)
        {
            return this.kilograms.CompareTo(quantity.kilograms);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Mass"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Mass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Mass"/> object to compare with this instance.</param>
        public bool Equals(Mass other)
        {
            return this.kilograms.Equals(other.kilograms);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Mass"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Mass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Mass"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Mass other, Mass tolerance)
        {
            Ensure.GreaterThan(tolerance.kilograms, 0, nameof(tolerance));
            return Math.Abs(this.kilograms - other.kilograms) < tolerance.kilograms;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Mass"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Mass"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Mass && this.Equals((Mass)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.kilograms.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "kilograms", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.kilograms);
        }
    }
}