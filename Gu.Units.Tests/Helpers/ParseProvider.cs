namespace Gu.Units.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ParseProvider : IEnumerable
    {
        private readonly List<ParseData> _datas;

        public ParseProvider()
        {
            this._datas = new List<ParseData>
                         {
                             new ParseData("1.2m^2", s=>Area.Parse(s),Area.FromSquareMetres(1.2)),
                             new ParseData("1.2m²", s=>Area.Parse(s),Area.FromSquareMetres(1.2)),
                             new ParseData("1.2s", s=>Time.Parse(s), Time.FromSeconds(1.2)),
                             new ParseData("1.2h", s=>Time.Parse(s), Time.FromHours(1.2)),
                             new ParseData("1.2ms", s=>Time.Parse(s), Time.FromMilliseconds(1.2)),
                             new ParseData("1.2kg", s=>Mass.Parse(s), Mass.FromKilograms(1.2)),
                             new ParseData("1.2g", s=>Mass.Parse(s), Mass.FromGrams(1.2)),
                             new ParseData("1.2m³", s=>Volume.Parse(s), Volume.FromCubicMetres(1.2)),
                             new ParseData("1.2m^3", s=>Volume.Parse(s), Volume.FromCubicMetres(1.2)),
                             new ParseData("1.2m/s", s=>Speed.Parse(s), Speed.FromMetresPerSecond(1.2)),
                             new ParseData("1.2m⋅s⁻¹", s=>Speed.Parse(s), Speed.FromMetresPerSecond(1.2)),
                             new ParseData("1.2m*s⁻¹", s=>Speed.Parse(s), Speed.FromMetresPerSecond(1.2)),
                             new ParseData("1.2m¹⋅s⁻¹", s=>Speed.Parse(s), Speed.FromMetresPerSecond(1.2)),
                             new ParseData("1.2m^1⋅s⁻¹", s=>Speed.Parse(s), Speed.FromMetresPerSecond(1.2)),
                             new ParseData("1.2m^1⋅s^-1", s=>Speed.Parse(s), Speed.FromMetresPerSecond(1.2)),
                             new ParseData("1.2m^1/s^2", s=>Acceleration.Parse(s), Acceleration.FromMetresPerSecondSquared(1.2)),
                             new ParseData("1.2m/s^2", s=>Acceleration.Parse(s), Acceleration.FromMetresPerSecondSquared(1.2)),
                             new ParseData("1.2 m/s^2", s=>Acceleration.Parse(s), Acceleration.FromMetresPerSecondSquared(1.2)),
                             new ParseData("1.2 m / s^2", s=>Acceleration.Parse(s), Acceleration.FromMetresPerSecondSquared(1.2)),
                             new ParseData("1.2 m / s²", s=>Acceleration.Parse(s), Acceleration.FromMetresPerSecondSquared(1.2)),
                         };

        }
        public IEnumerator GetEnumerator()
        {
            return this._datas.GetEnumerator();
        }

        public class ParseData
        {
            public ParseData(string stringValue, Func<string, IQuantity> parseMethod, IQuantity quantity)
            {
                this.StringValue = stringValue;
                this.ParseMethod = parseMethod;
                this.Quantity = quantity;
            }

            public string StringValue { get; private set; }

            public Func<string, IQuantity> ParseMethod { get; private set; }

            public IQuantity Quantity { get; private set; }

            public override string ToString()
            {
                return string.Format("\"{0}\" -> {1}", this.StringValue, this.Quantity);
            }
        }
    }
}