namespace Gu.Units.Tests.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Internals.Parsing;

    public class ConversionProvider : List<ConversionProvider.IConversion<IQuantity>>
    {
        public ConversionProvider()
        {
            Add("1.2cm", "0.012m", Length.Parse);
            Add("1.2cm", "12mm", Length.Parse);
            Add("1.2mm^2", "1.2E-6m^2", Area.Parse);
            Add("90°", "1.5707963267948966rad", Angle.Parse);
            Add("1°", "0.017453292519943295rad", Angle.Parse);
            Add("0°C", "32°F", Temperature.Parse);
            Add("100°C", "211.99999999999994°F", Temperature.Parse);
            Add("100°F", "37.777777777777828°C", Temperature.Parse);
            Add("0K", "-273.15°C", Temperature.Parse);
            Add("0K", "-459.67°F", Temperature.Parse);
            Add("100K", "-173.14999999999998°C", Temperature.Parse);
            Add("100K", "-279.67°F", Temperature.Parse);
            Add("1ul", "100%", Unitless.Parse);
            Add("1%", "0.01ul", Unitless.Parse);
            Add("1%", "10‰", Unitless.Parse);
            Add("100N", "0.1kN", Force.Parse);
            Add("1.2 Pa", "0.000012 bar", Pressure.Parse);
            Add("0.12 MPa", "1.2 bar", Pressure.Parse);
            Add("1.2 Pa", "0.012 mbar", Pressure.Parse);
            Add("1.2 mm/s^2", "0.0012 m/s^2", Acceleration.Parse);
            Add("1.2 mm/s^2", "0.0012 m/s^2", Acceleration.Parse);
        }

        public void Add<TQuantity>(string @from,
            string to,
            Func<string, TQuantity> parser) where TQuantity : IQuantity
        {
            Add(new Conversion<TQuantity>(@from, to, parser));
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
            private readonly Func<string, T> _parser;

            public Conversion(string from, string to, Func<string, T> parser)
            {
                using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
                {
                    this._parser = parser;
                    this.From = @from;
                    FromQuantity = Parse(from);
                    this.To = to;
                    ToQuantity = Parse(to);
                }
            }

            public T Parse(string s)
            {
                return _parser(s);
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
