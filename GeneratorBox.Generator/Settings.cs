namespace GeneratorBox.Generator
{
    using System.Collections.Generic;

    public class Settings
    {
        private static string _nameSpace;
        static Settings()
        {
            _nameSpace = "GeneratorBox.Units";
            UnitValueTypes = new List<UnitValueMetaData>
            {
                new UnitValueMetaData("Radians", _nameSpace, "Angle", "Degrees"),
                new UnitValueMetaData("Meters", _nameSpace, "Length","Centimeters","Millimeters"),
            };
            UnitTypes = new List<UnitMetaData>
            {
                new UnitMetaData("Angle", _nameSpace, "Radians", 1.0, "rad")
            };
        }
        public Settings()
        {

        }
        public static List<UnitValueMetaData> UnitValueTypes { get; set; }
        public static List<UnitMetaData> UnitTypes { get; set; }
    }
}
