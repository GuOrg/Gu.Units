namespace GeneratorBox.Generator
{
    using System.Collections.Generic;

    public class Settings
    {
        private static string _nameSpace;
        static Settings()
        {
            _nameSpace = "GeneratorBox.Units";
            Descriptors = new List<UnitValueMetaData>
            {
                new UnitValueMetaData("Radians", _nameSpace, "Angle", "Degrees"),
                new UnitValueMetaData("Meters", _nameSpace, "Length","Centimeters","Millimeters"),
            };
        }
        public Settings()
        {

        }
        public static List<UnitValueMetaData> Descriptors { get; set; }
    }
}
