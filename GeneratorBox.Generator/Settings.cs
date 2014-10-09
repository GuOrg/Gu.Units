namespace GeneratorBox.Generator
{
    using System.Collections.Generic;

    public class Settings
    {
        private static string _nameSpace;
        static Settings()
        {
            _nameSpace = "GeneratorBox.Units";
            Descriptors = new List<UnitValue>
            {
                new UnitValue("Radians", _nameSpace, "Angle", "Degrees"),
                new UnitValue("Meters", _nameSpace, "Length","Centimeters","Millimeters"),
            };
        }
        public Settings()
        {

        }
        public static List<UnitValue> Descriptors { get; set; }
    }
}
