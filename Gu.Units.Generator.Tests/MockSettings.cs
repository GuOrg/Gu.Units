﻿namespace Gu.Units.Generator.Tests
{
    using System.Collections.ObjectModel;

    public class MockSettings : Settings
    {
        public readonly BaseUnit Metres;
        public readonly Quantity Length;

        public readonly BaseUnit Kilograms;
        public readonly FactorConversion Grams;
        public readonly Quantity Mass;

        public readonly BaseUnit Kelvins;
        public readonly Quantity Temperature;

        public readonly BaseUnit Seconds;
        public readonly Quantity Time;

        public readonly DerivedUnit MetresPerSecond;
        public readonly Quantity Speed;

        public readonly DerivedUnit MetresPerSecondSquared;
        public readonly Quantity Acceleration;

        public readonly DerivedUnit SquareMetres;
        public readonly Quantity Area;

        public readonly DerivedUnit CubicMetres;
        public readonly Quantity Volume;

        public readonly DerivedUnit KilogramsPerCubicMetre;
        public readonly Quantity Density;

        public readonly BaseUnit Amperes;
        public readonly Quantity Current;

        public readonly DerivedUnit Newtons;
        public readonly Quantity Force;

        public readonly DerivedUnit Joules;
        public readonly Quantity Energy;

        public readonly DerivedUnit Watts;
        public readonly Quantity Power;

        public readonly DerivedUnit Volts;
        public readonly Quantity Voltage;

        public readonly DerivedUnit Coulombs;
        public readonly Quantity ElectricCharge;

        public readonly DerivedUnit Hertz;
        public readonly Quantity Frequency;
        public readonly Prefix Micro = new Prefix("Micro", "µ", -6);
        public readonly Prefix Milli = new Prefix("Milli", "m", -3);
        public readonly Prefix Kilo = new Prefix("Kilo", "k", 3);

        private MockSettings()
            : base(new ObservableCollection<Prefix>(), new ObservableCollection<BaseUnit>(), new ObservableCollection<DerivedUnit>())
        {
            this.Prefixes.Add(this.Micro);
            this.Prefixes.Add(this.Milli);
            this.Prefixes.Add(this.Kilo);
            this.Metres = new BaseUnit("Metres", "m", "Length");
            this.BaseUnits.Add(this.Metres);
            this.Length = this.Metres.Quantity;

            this.Kelvins = new BaseUnit("Kelvin", "K", "Temperature");
            this.BaseUnits.Add(this.Kelvins);
            this.Temperature = this.Kelvins.Quantity;

            this.Seconds = new BaseUnit("Seconds", "s", "Time");
            this.BaseUnits.Add(this.Seconds);
            this.Time = this.Seconds.Quantity;

            this.Kilograms = new BaseUnit("Kilograms", "kg", "Mass");
            this.Grams = new FactorConversion("Grams", "g", 0.001);
            this.Kilograms.FactorConversions.Add(this.Grams);
            this.BaseUnits.Add(this.Kilograms);
            this.Mass = this.Kilograms.Quantity;

            this.Amperes = new BaseUnit("Amperes", "A", "ElectricalCurrent");
            this.BaseUnits.Add(this.Amperes);
            this.Current = this.Amperes.Quantity;

            this.MetresPerSecond = new DerivedUnit(
                "MetresPerSecond",
                "m/s",
                "Speed",
                new[] { UnitAndPower.Create(this.Metres, 1), UnitAndPower.Create(this.Seconds, -1) });
            this.DerivedUnits.Add(this.MetresPerSecond);
            this.Speed = this.MetresPerSecond.Quantity;

            this.MetresPerSecondSquared = new DerivedUnit(
                "MetresPerSecondSquared",
                "m/s^2",
                "Acceleration",
                new[] { UnitAndPower.Create(this.Metres, 1), UnitAndPower.Create(this.Seconds, -2) });
            this.DerivedUnits.Add(this.MetresPerSecondSquared);
            this.Acceleration = this.MetresPerSecondSquared.Quantity;

            this.Newtons = new DerivedUnit(
                "Newtons",
                "N",
                "Force",
#pragma warning disable SA1118 // Parameter should not span multiple lines
                new[]
                    {
                        UnitAndPower.Create(this.Kilograms, 1),
                        UnitAndPower.Create(this.Metres, 1),
                        UnitAndPower.Create(this.Seconds, -2),
                    });
#pragma warning restore SA1118 // Parameter should not span multiple lines
            this.DerivedUnits.Add(this.Newtons);
            this.Force = this.Newtons.Quantity;

            this.Joules = new DerivedUnit(
                "Joules",
                "J",
                "Energy",
                new[] { UnitAndPower.Create(this.Newtons, 1), UnitAndPower.Create(this.Metres, 1) });
            this.DerivedUnits.Add(this.Joules);
            this.Energy = this.Joules.Quantity;

            this.Watts = new DerivedUnit(
                "Watts",
                "W",
                "Power",
                new[] { UnitAndPower.Create(this.Joules, 1), UnitAndPower.Create(this.Seconds, -1) });
            this.DerivedUnits.Add(this.Watts);
            this.Power = this.Watts.Quantity;

            this.Volts = new DerivedUnit(
                "Volts",
                "V",
                "Voltage",
                new[] { UnitAndPower.Create(this.Watts, 1), UnitAndPower.Create(this.Amperes, -1) });
            this.DerivedUnits.Add(this.Volts);
            this.Voltage = this.Volts.Quantity;

            this.Coulombs = new DerivedUnit(
                "Coulombs",
                "C",
                "ElectricCharge",
                new[] { UnitAndPower.Create(this.Seconds, 1), UnitAndPower.Create(this.Amperes, 1) });
            this.DerivedUnits.Add(this.Coulombs);
            this.ElectricCharge = this.Coulombs.Quantity;

            this.SquareMetres = new DerivedUnit("SquareMetres", "m^2", "Area", new[] { UnitAndPower.Create(this.Metres, 2) });
            this.DerivedUnits.Add(this.SquareMetres);
            this.Area = this.SquareMetres.Quantity;

            this.CubicMetres = new DerivedUnit("CubicMetres", "m^3", "Volume", new[] { UnitAndPower.Create(this.Metres, 3) });
            this.DerivedUnits.Add(this.CubicMetres);
            this.Volume = this.CubicMetres.Quantity;

            this.KilogramsPerCubicMetre = new DerivedUnit("KilogramsPerCubicMetre", "kg/m^3", "Density", new[] { UnitAndPower.Create(this.Kilograms, 1), UnitAndPower.Create(this.Metres, -3) });
            this.DerivedUnits.Add(this.KilogramsPerCubicMetre);
            this.Density = this.CubicMetres.Quantity;

            this.Hertz = new DerivedUnit("Hertz", "1/s", "Frequency", new[] { UnitAndPower.Create(this.Seconds, -1) });

            this.DerivedUnits.Add(this.Hertz);
            this.Frequency = this.Hertz.Quantity;
        }

        public static MockSettings Create()
        {
            InnerInstance = null;
            return new MockSettings();
        }
    }
}
