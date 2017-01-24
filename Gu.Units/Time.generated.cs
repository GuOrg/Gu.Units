﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Time"/>.
    /// </summary>
    [TypeConverter(typeof(TimeTypeConverter))]
    [Serializable]
    public partial struct Time : IQuantity<TimeUnit>, IComparable<Time>, IEquatable<Time>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.TimeUnit.Seconds"/>
        /// </summary>
		public static readonly Time Zero = new Time();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.TimeUnit.Seconds"/>.
        /// </summary>
        internal readonly double seconds;

        private Time(double seconds)
        {
            this.seconds = seconds;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.TimeUnit"/>.</param>
        public Time(double value, TimeUnit unit)
        {
            this.seconds = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.TimeUnit.Seconds"/>
        /// </summary>
        public double SiValue => this.seconds;

        /// <summary>
        /// The <see cref="Gu.Units.TimeUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public TimeUnit SiUnit => TimeUnit.Seconds;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => TimeUnit.Seconds;

        /// <summary>
        /// The quantity in seconds".
        /// </summary>
        public double Seconds => this.seconds;


        /// <summary>
        /// The quantity in Hours
        /// </summary>
        public double Hours => this.seconds / 3600;


        /// <summary>
        /// The quantity in Minutes
        /// </summary>
        public double Minutes => this.seconds / 60;


        /// <summary>
        /// The quantity in Nanoseconds
        /// </summary>
        public double Nanoseconds => 1000000000 * this.seconds;


        /// <summary>
        /// The quantity in Microseconds
        /// </summary>
        public double Microseconds => 1000000 * this.seconds;


        /// <summary>
        /// The quantity in Milliseconds
        /// </summary>
        public double Milliseconds => 1000 * this.seconds;


        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <returns>The <see cref="Gu.Units.Time"/> parsed from <paramref name="text"/></returns>
		public static Time Parse(string text)
        {
            return QuantityParser.Parse<TimeUnit, Time>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Time"/> parsed from <paramref name="text"/></returns>
        public static Time Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<TimeUnit, Time>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Time"/> parsed from <paramref name="text"/></returns>
        public static Time Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<TimeUnit, Time>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Time"/> parsed from <paramref name="text"/></returns>
        public static Time Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<TimeUnit, Time>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <param name="result">The parsed <see cref="Time"/></param>
        /// <returns>True if an instance of <see cref="Time"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Time result)
        {
            return QuantityParser.TryParse<TimeUnit, Time>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Time"/></param>
        /// <returns>True if an instance of <see cref="Time"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, IFormatProvider provider, out Time result)
        {
            return QuantityParser.TryParse<TimeUnit, Time>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Time"/></param>
        /// <returns>True if an instance of <see cref="Time"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, out Time result)
        {
            return QuantityParser.TryParse<TimeUnit, Time>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Time"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Time"/></param>
        /// <returns>True if an instance of <see cref="Time"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Time result)
        {
            return QuantityParser.TryParse<TimeUnit, Time>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Time"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Time"/></returns>
        public static Time ReadFrom(XmlReader reader)
        {
            var v = new Time();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Time From(double value, TimeUnit unit)
        {
            return new Time(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="seconds">The value in <see cref="Gu.Units.TimeUnit.Seconds"/></param>
        public static Time FromSeconds(double seconds)
        {
            return new Time(seconds);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="hours">The value in h</param>
        public static Time FromHours(double hours)
        {
            return new Time(3600 * hours);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="minutes">The value in min</param>
        public static Time FromMinutes(double minutes)
        {
            return new Time(60 * minutes);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="nanoseconds">The value in ns</param>
        public static Time FromNanoseconds(double nanoseconds)
        {
            return new Time(nanoseconds / 1000000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="microseconds">The value in µs</param>
        public static Time FromMicroseconds(double microseconds)
        {
            return new Time(microseconds / 1000000);
        }


        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <param name="milliseconds">The value in ms</param>
        public static Time FromMilliseconds(double milliseconds)
        {
            return new Time(milliseconds / 1000);
        }



        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the multiplication.</returns>
        public static ElectricCharge operator *(Time left, Current right)
        {
            return ElectricCharge.FromCoulombs(left.seconds * right.amperes);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the multiplication.</returns>
        public static Momentum operator *(Time left, Force right)
        {
            return Momentum.FromNewtonSecond(left.seconds * right.newtons);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Time left, Power right)
        {
            return Energy.FromJoules(left.seconds * right.watts);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the multiplication.</returns>
        public static Length operator *(Time left, Speed right)
        {
            return Length.FromMetres(left.seconds * right.metresPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Angle"/> that is the result from the multiplication.</returns>
        public static Angle operator *(Time left, AngularSpeed right)
        {
            return Angle.FromRadians(left.seconds * right.radiansPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the multiplication.</returns>
        public static Speed operator *(Time left, Acceleration right)
        {
            return Speed.FromMetresPerSecond(left.seconds * right.metresPerSecondSquared);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(Time left, Stiffness right)
        {
            return MassFlow.FromKilogramsPerSecond(left.seconds * right.newtonsPerMetre);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the multiplication.</returns>
        public static Volume operator *(Time left, VolumetricFlow right)
        {
            return Volume.FromCubicMetres(left.seconds * right.cubicMetresPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFlux"/> that is the result from the multiplication.</returns>
        public static MagneticFlux operator *(Time left, Voltage right)
        {
            return MagneticFlux.FromWebers(left.seconds * right.volts);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Inductance"/> that is the result from the multiplication.</returns>
        public static Inductance operator *(Time left, Resistance right)
        {
            return Inductance.FromHenrys(left.seconds * right.ohms);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Capacitance"/> that is the result from the division.</returns>
        public static Capacitance operator /(Time left, Resistance right)
        {
            return Capacitance.FromFarads(left.seconds / right.ohms);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(Time left, SpecificEnergy right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.seconds * right.joulesPerKilogram);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the division.</returns>
        public static ElectricalConductance operator /(Time left, Inductance right)
        {
            return ElectricalConductance.FromSiemens(left.seconds / right.henrys);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Resistance"/> that is the result from the division.</returns>
        public static Resistance operator /(Time left, Capacitance right)
        {
            return Resistance.FromOhms(left.seconds / right.farads);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(Time left, Flexibility right)
        {
            return MassFlow.FromKilogramsPerSecond(left.seconds / right.metresPerNewton);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the multiplication.</returns>
        public static AngularSpeed operator *(Time left, AngularAcceleration right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.seconds * right.radiansPerSecondSquared);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularAcceleration"/> that is the result from the multiplication.</returns>
        public static AngularAcceleration operator *(Time left, AngularJerk right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.seconds * right.radiansPerSecondCubed);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the multiplication.</returns>
        public static Acceleration operator *(Time left, Jerk right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.seconds * right.metresPerSecondCubed);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Capacitance"/> that is the result from the multiplication.</returns>
        public static Capacitance operator *(Time left, ElectricalConductance right)
        {
            return Capacitance.FromFarads(left.seconds * right.siemens);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Inductance"/> that is the result from the division.</returns>
        public static Inductance operator /(Time left, ElectricalConductance right)
        {
            return Inductance.FromHenrys(left.seconds / right.siemens);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AmountOfSubstance"/> that is the result from the multiplication.</returns>
        public static AmountOfSubstance operator *(Time left, CatalyticActivity right)
        {
            return AmountOfSubstance.FromMoles(left.seconds * right.katals);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the multiplication.</returns>
        public static Mass operator *(Time left, MassFlow right)
        {
            return Mass.FromKilograms(left.seconds * right.kilogramsPerSecond);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Flexibility"/> that is the result from the division.</returns>
        public static Flexibility operator /(Time left, MassFlow right)
        {
            return Flexibility.FromMetresPerNewton(left.seconds / right.kilogramsPerSecond);
        }


        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the multiplication.</returns>
        public static Area operator *(Time left, KinematicViscosity right)
        {
            return Area.FromSquareMetres(left.seconds * right.squareMetresPerSecond);
        }



        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The Frequency that is the result from the division.</returns>
        public static Frequency operator /(double left, Time right)
        {
            return Frequency.FromHertz(left / right.seconds);
        }


        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Time left, Time right)
        {
            return left.seconds / right.seconds;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Time"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/>.</param>
        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Time"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/>.</param>
        public static bool operator !=(Time left, Time right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Time"/> is less than another specified <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/>.</param>
        public static bool operator <(Time left, Time right)
        {
            return left.seconds < right.seconds;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Time"/> is greater than another specified <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/>.</param>
        public static bool operator >(Time left, Time right)
        {
            return left.seconds > right.seconds;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Time"/> is less than or equal to another specified <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/>.</param>
        public static bool operator <=(Time left, Time right)
        {
            return left.seconds <= right.seconds;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Time"/> is greater than or equal to another specified <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/>.</param>
        public static bool operator >=(Time left, Time right)
        {
            return left.seconds >= right.seconds;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Time"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Time"/> with <paramref name="left"/> and returns the result.</returns>
        public static Time operator *(double left, Time right)
        {
            return new Time(left * right.seconds);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Time"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Time"/> with <paramref name="right"/> and returns the result.</returns>
        public static Time operator *(Time left, double right)
        {
            return new Time(left.seconds * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Time"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Time"/> with <paramref name="right"/> and returns the result.</returns>
        public static Time operator /(Time left, double right)
        {
            return new Time(left.seconds / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Time"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Time"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/>.</param>
        public static Time operator +(Time left, Time right)
        {
            return new Time(left.seconds + right.seconds);
        }

        /// <summary>
        /// Subtracts an Time from another Time and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Time"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Time"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Time"/> (the subtrahend).</param>
        public static Time operator -(Time left, Time right)
        {
            return new Time(left.seconds - right.seconds);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Time"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Time"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="time">An instance of <see cref="Gu.Units.Time"/></param>
        public static Time operator -(Time time)
        {
            return new Time(-1 * time.seconds);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="time"/>.
        /// </returns>
        /// <param name="time">An instance of <see cref="Gu.Units.Time"/></param>
        public static Time operator +(Time time)
        {
            return time;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(TimeUnit unit)
        {
            return unit.FromSiUnit(this.seconds);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Time"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Time"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 s\"</param>
        /// <returns>The string representation of the <see cref="Time"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 s\"</param>
		/// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Time"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex s</param>
        /// <returns>The string representation of the <see cref="Time"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex s</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Time"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(TimeUnit unit)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(TimeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(TimeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(TimeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, TimeUnit unit)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(string valueFormat, TimeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, TimeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, TimeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<TimeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<TimeUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Time"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Time"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Time"/> object to compare to this instance.</param>
        public int CompareTo(Time quantity)
        {
            return this.seconds.CompareTo(quantity.seconds);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Time"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Time as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Time"/> object to compare with this instance.</param>
        public bool Equals(Time other)
        {
            return this.seconds.Equals(other.seconds);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Time"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Time as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Time"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Time other, Time tolerance)
        {
            Ensure.GreaterThan(tolerance.seconds, 0, nameof(tolerance));
            return Math.Abs(this.seconds - other.seconds) < tolerance.seconds;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Time"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Time"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Time && this.Equals((Time)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.seconds.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "seconds", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.seconds);
        }
    }
}