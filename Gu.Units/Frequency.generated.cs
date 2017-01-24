﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Frequency"/>.
    /// </summary>
    [TypeConverter(typeof(FrequencyTypeConverter))]
    [Serializable]
    public partial struct Frequency : IQuantity<FrequencyUnit>, IComparable<Frequency>, IEquatable<Frequency>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.FrequencyUnit.Hertz"/>
        /// </summary>
		public static readonly Frequency Zero = new Frequency();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.FrequencyUnit.Hertz"/>.
        /// </summary>
        internal readonly double hertz;

        private Frequency(double hertz)
        {
            this.hertz = hertz;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.FrequencyUnit"/>.</param>
        public Frequency(double value, FrequencyUnit unit)
        {
            this.hertz = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.FrequencyUnit.Hertz"/>
        /// </summary>
        public double SiValue => this.hertz;

        /// <summary>
        /// The <see cref="Gu.Units.FrequencyUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public FrequencyUnit SiUnit => FrequencyUnit.Hertz;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => FrequencyUnit.Hertz;

        /// <summary>
        /// The quantity in hertz".
        /// </summary>
        public double Hertz => this.hertz;


        /// <summary>
        /// The quantity in Millihertz
        /// </summary>
        public double Millihertz => 1000 * this.hertz;


        /// <summary>
        /// The quantity in Kilohertz
        /// </summary>
        public double Kilohertz => this.hertz / 1000;


        /// <summary>
        /// The quantity in Megahertz
        /// </summary>
        public double Megahertz => this.hertz / 1000000;


        /// <summary>
        /// The quantity in Gigahertz
        /// </summary>
        public double Gigahertz => this.hertz / 1000000000;


        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <returns>The <see cref="Gu.Units.Frequency"/> parsed from <paramref name="text"/></returns>
		public static Frequency Parse(string text)
        {
            return QuantityParser.Parse<FrequencyUnit, Frequency>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Frequency"/> parsed from <paramref name="text"/></returns>
        public static Frequency Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<FrequencyUnit, Frequency>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Frequency"/> parsed from <paramref name="text"/></returns>
        public static Frequency Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<FrequencyUnit, Frequency>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Frequency"/> parsed from <paramref name="text"/></returns>
        public static Frequency Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<FrequencyUnit, Frequency>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <param name="result">The parsed <see cref="Frequency"/></param>
        /// <returns>True if an instance of <see cref="Frequency"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Frequency result)
        {
            return QuantityParser.TryParse<FrequencyUnit, Frequency>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Frequency"/></param>
        /// <returns>True if an instance of <see cref="Frequency"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, IFormatProvider provider, out Frequency result)
        {
            return QuantityParser.TryParse<FrequencyUnit, Frequency>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Frequency"/></param>
        /// <returns>True if an instance of <see cref="Frequency"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, out Frequency result)
        {
            return QuantityParser.TryParse<FrequencyUnit, Frequency>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Frequency"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Frequency"/></param>
        /// <returns>True if an instance of <see cref="Frequency"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Frequency result)
        {
            return QuantityParser.TryParse<FrequencyUnit, Frequency>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Frequency"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Frequency"/></returns>
        public static Frequency ReadFrom(XmlReader reader)
        {
            var v = new Frequency();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Frequency From(double value, FrequencyUnit unit)
        {
            return new Frequency(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="hertz">The value in <see cref="Gu.Units.FrequencyUnit.Hertz"/></param>
        public static Frequency FromHertz(double hertz)
        {
            return new Frequency(hertz);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="millihertz">The value in mHz</param>
        public static Frequency FromMillihertz(double millihertz)
        {
            return new Frequency(millihertz / 1000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="kilohertz">The value in kHz</param>
        public static Frequency FromKilohertz(double kilohertz)
        {
            return new Frequency(1000 * kilohertz);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="megahertz">The value in MHz</param>
        public static Frequency FromMegahertz(double megahertz)
        {
            return new Frequency(1000000 * megahertz);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="gigahertz">The value in GHz</param>
        public static Frequency FromGigahertz(double gigahertz)
        {
            return new Frequency(1000000000 * gigahertz);
        }



        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(Frequency left, Mass right)
        {
            return MassFlow.FromKilogramsPerSecond(left.hertz * right.kilograms);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the multiplication.</returns>
        public static Speed operator *(Frequency left, Length right)
        {
            return Speed.FromMetresPerSecond(left.hertz * right.metres);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the multiplication.</returns>
        public static AngularSpeed operator *(Frequency left, Angle right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.hertz * right.radians);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="CatalyticActivity"/> that is the result from the multiplication.</returns>
        public static CatalyticActivity operator *(Frequency left, AmountOfSubstance right)
        {
            return CatalyticActivity.FromKatals(left.hertz * right.moles);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(Frequency left, Area right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.hertz * right.squareMetres);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(Frequency left, Volume right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.hertz * right.cubicMetres);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(Frequency left, Energy right)
        {
            return Power.FromWatts(left.hertz * right.joules);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the multiplication.</returns>
        public static Acceleration operator *(Frequency left, Speed right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.hertz * right.metresPerSecond);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(Frequency left, Speed right)
        {
            return Wavenumber.FromReciprocalMetres(left.hertz / right.metresPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularAcceleration"/> that is the result from the multiplication.</returns>
        public static AngularAcceleration operator *(Frequency left, AngularSpeed right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.hertz * right.radiansPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Jerk"/> that is the result from the multiplication.</returns>
        public static Jerk operator *(Frequency left, Acceleration right)
        {
            return Jerk.FromMetresPerSecondCubed(left.hertz * right.metresPerSecondSquared);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Current"/> that is the result from the multiplication.</returns>
        public static Current operator *(Frequency left, ElectricCharge right)
        {
            return Current.FromAmperes(left.hertz * right.coulombs);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Resistance"/> that is the result from the multiplication.</returns>
        public static Resistance operator *(Frequency left, Inductance right)
        {
            return Resistance.FromOhms(left.hertz * right.henrys);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the multiplication.</returns>
        public static ElectricalConductance operator *(Frequency left, Capacitance right)
        {
            return ElectricalConductance.FromSiemens(left.hertz * right.farads);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularJerk"/> that is the result from the multiplication.</returns>
        public static AngularJerk operator *(Frequency left, AngularAcceleration right)
        {
            return AngularJerk.FromRadiansPerSecondCubed(left.hertz * right.radiansPerSecondSquared);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the multiplication.</returns>
        public static Voltage operator *(Frequency left, MagneticFlux right)
        {
            return Voltage.FromVolts(left.hertz * right.webers);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Frequency left, Momentum right)
        {
            return Force.FromNewtons(left.hertz * right.newtonSecond);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(Frequency left, Wavenumber right)
        {
            return Speed.FromMetresPerSecond(left.hertz / right.reciprocalMetres);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(Frequency left, MassFlow right)
        {
            return Stiffness.FromNewtonsPerMetre(left.hertz * right.kilogramsPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the multiplication.</returns>
        public static SpecificEnergy operator *(Frequency left, KinematicViscosity right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.hertz * right.squareMetresPerSecond);
        }



        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The Time that is the result from the division.</returns>
        public static Time operator /(double left, Frequency right)
        {
            return Time.FromSeconds(left / right.hertz);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Frequency left, Frequency right)
        {
            return left.hertz / right.hertz;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Frequency"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        public static bool operator ==(Frequency left, Frequency right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Frequency"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        public static bool operator !=(Frequency left, Frequency right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Frequency"/> is less than another specified <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        public static bool operator <(Frequency left, Frequency right)
        {
            return left.hertz < right.hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Frequency"/> is greater than another specified <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        public static bool operator >(Frequency left, Frequency right)
        {
            return left.hertz > right.hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Frequency"/> is less than or equal to another specified <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        public static bool operator <=(Frequency left, Frequency right)
        {
            return left.hertz <= right.hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Frequency"/> is greater than or equal to another specified <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        public static bool operator >=(Frequency left, Frequency right)
        {
            return left.hertz >= right.hertz;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.</returns>
        public static Frequency operator *(double left, Frequency right)
        {
            return new Frequency(left * right.hertz);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator *(Frequency left, double right)
        {
            return new Frequency(left.hertz * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator /(Frequency left, double right)
        {
            return new Frequency(left.hertz / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Frequency"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Frequency"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/>.</param>
        public static Frequency operator +(Frequency left, Frequency right)
        {
            return new Frequency(left.hertz + right.hertz);
        }

        /// <summary>
        /// Subtracts an Frequency from another Frequency and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Frequency"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Frequency"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Frequency"/> (the subtrahend).</param>
        public static Frequency operator -(Frequency left, Frequency right)
        {
            return new Frequency(left.hertz - right.hertz);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Frequency"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Frequency"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="frequency">An instance of <see cref="Gu.Units.Frequency"/></param>
        public static Frequency operator -(Frequency frequency)
        {
            return new Frequency(-1 * frequency.hertz);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="frequency"/>.
        /// </returns>
        /// <param name="frequency">An instance of <see cref="Gu.Units.Frequency"/></param>
        public static Frequency operator +(Frequency frequency)
        {
            return frequency;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(FrequencyUnit unit)
        {
            return unit.FromSiUnit(this.hertz);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Frequency"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Frequency"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Hz\"</param>
        /// <returns>The string representation of the <see cref="Frequency"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Hz\"</param>
		/// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Frequency"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex Hz</param>
        /// <returns>The string representation of the <see cref="Frequency"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex Hz</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Frequency"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(FrequencyUnit unit)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(FrequencyUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(FrequencyUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(FrequencyUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, FrequencyUnit unit)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(string valueFormat, FrequencyUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, FrequencyUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, FrequencyUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FrequencyUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<FrequencyUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Frequency"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Frequency"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Frequency"/> object to compare to this instance.</param>
        public int CompareTo(Frequency quantity)
        {
            return this.hertz.CompareTo(quantity.hertz);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Frequency"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Frequency"/> object to compare with this instance.</param>
        public bool Equals(Frequency other)
        {
            return this.hertz.Equals(other.hertz);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Frequency"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Frequency"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Frequency other, Frequency tolerance)
        {
            Ensure.GreaterThan(tolerance.hertz, 0, nameof(tolerance));
            return Math.Abs(this.hertz - other.hertz) < tolerance.hertz;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Frequency"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Frequency"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Frequency && this.Equals((Frequency)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.hertz.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "hertz", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.hertz);
        }
    }
}