using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gu.Units.Generator.Tests
{
    public class MockSettings
    {
        public readonly string Namespace = "Gu.Units";
        public readonly SiUnit Metres;
        public readonly Quantity Length;

        public readonly SiUnit Seconds;
        public readonly Quantity Time;

        public readonly DerivedUnit MetresPerSecond;
        public readonly Quantity Speed;

        public readonly DerivedUnit SquareMetres;
        public readonly Quantity Area;

        public readonly DerivedUnit CubicMetres;
        public readonly Quantity Volume;

        public readonly Quantity[] Quantities;

        public MockSettings()
        {
            UnitBase.AllUnitsStatic.Clear();
            Metres = new SiUnit(Namespace, "Metres", "m");
            Seconds = new SiUnit(Namespace, "Seconds", "s");
            Length = new Quantity(Namespace, "Length", Metres);
            Time = new Quantity(Namespace, "Time", Seconds);
            MetresPerSecond = new DerivedUnit(Namespace,
                                                    "MetresPerSecond",
                                                    "m/s",
                                                    new UnitAndPower(Metres, 1),
                                                    new UnitAndPower(Seconds, -1));
            Speed = new Quantity(Namespace, "Speed", MetresPerSecond);
            SquareMetres = new DerivedUnit(Namespace, "SquareMetres", "m^2", new UnitAndPower(Metres, 2));
            Area = new Quantity(Namespace, "Area", SquareMetres);

            CubicMetres = new DerivedUnit(Namespace, "CubicMetres", "m^3", new UnitAndPower(Metres, 3));
            Volume = new Quantity(Namespace, "Volume", CubicMetres);
            Quantities = new[] { Length, Time, Speed, Area };
        }
    }
}
