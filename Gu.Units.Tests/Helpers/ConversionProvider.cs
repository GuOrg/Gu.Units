namespace Gu.Units.Tests.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ConversionProvider : IEnumerable
    {
        private readonly List<IConversion<IQuantity>> _datas;

        public ConversionProvider()
        {
            _datas = new List<IConversion<IQuantity>>
                                        {
                                            new Conversion<Length>("1.2cm","0.012m", Length.Parse),
                                            new Conversion<Length>("1.2cm","12mm", Length.Parse),
                                            new Conversion<Area>("1.2mm^2","1.2E-6m^2", Area.Parse),
                                            new Conversion<Angle>("90°","1.5707963267948966rad", Angle.Parse),
                                            new Conversion<Angle>("1°","0.017453292519943295rad", Angle.Parse),
                                            new Conversion<Temperature>("0°C","32°F", Temperature.Parse),
                                            new Conversion<Temperature>("100°C","211.99999999999994°F", Temperature.Parse),
                                            new Conversion<Temperature>("100°F","37.777777777777828°C", Temperature.Parse),
                                            new Conversion<Temperature>("0K","-273.15°C", Temperature.Parse),
                                            new Conversion<Temperature>("0K","-459.67°F", Temperature.Parse),
                                            new Conversion<Temperature>("100K","-173.14999999999998°C", Temperature.Parse),
                                            new Conversion<Temperature>("100K","-279.67°F", Temperature.Parse),
                                            new Conversion<Unitless>("1ul","100%", Unitless.Parse),
                                            new Conversion<Unitless>("1%","0.01ul", Unitless.Parse),
                                            new Conversion<Unitless>("1%","10‰", Unitless.Parse),
                                            new Conversion<Force>("100N","0.1kN", Force.Parse),
                                            new Conversion<Pressure>("1.2 Pa","0.000012 bar", Pressure.Parse),
                                            new Conversion<Pressure>("0.12 MPa","1.2 bar", Pressure.Parse),
                                            new Conversion<Pressure>("1.2 Pa","0.012 mbar", Pressure.Parse),
                                            new Conversion<Acceleration>("1.2 mm/s^2","0.0012 m/s^2", Acceleration.Parse),
                                        };

        }
        public IEnumerator GetEnumerator()
        {
            return _datas.GetEnumerator();
        }

        public interface IConversion<out T> 
        {
            string From { get; }
            T FromQuantity { get; }
            string To { get; }
            T ToQuantity { get; }
        }

        public class Conversion<T> : IConversion<IQuantity>
            where T : IQuantity
        {
            public Conversion(string from, string to, Func<string, T> parseMethod)
            {
                this.From = @from;
                FromQuantity = parseMethod(@from);
                this.To = to;
                ToQuantity = parseMethod(to);
            }

            public string From { get; private set; }

            public IQuantity FromQuantity { get; private set; }

            public string To { get; private set; }

            public IQuantity ToQuantity { get; private set; }

            public override string ToString()
            {
                return string.Format("{0} -> {1}", From, To);
            }
        }
    }
}
