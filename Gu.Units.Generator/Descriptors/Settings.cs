namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Serialization;

    public class Settings
    {
        private List<Quantity> _quantities = new List<Quantity>();
        private List<SiUnit> _siUnitTypes = new List<SiUnit>();
        private List<Prefix> _prefixes = new List<Prefix>();

        public static Settings Instance
        {
            get
            {
                var serializer = new XmlSerializer(typeof(Settings));
                Settings settings;
                using (var reader = new StringReader(Properties.Resources.GeneratorSettings))
                {
                    settings = (Settings)serializer.Deserialize(reader);
                }
                foreach (var quantity in settings.Quantities)
                {
                    //var siUnit = quantity.SiUnit;
                    //siUnit.SiUnit = siUnit;
                    //siUnit.Quantity = quantity.Type;
                    //foreach (var unit in quantity.Units)
                    //{
                    //    unit.Quantity = quantity.Type;
                    //    siUnit.Related.Add(unit);
                    //    unit.SiUnit = siUnit;
                    //}
                }
                return settings;
            }
        }

        public static string NameSpace
        {
            get
            {
                return "Gu.Units";
            }
        }

        public static string FullFileName
        {
            get
            {
                var directoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
                var directory = directoryInfo.Parent.Parent.Parent.FullName; // Perhaps not the most elegant code ever written
                return System.IO.Path.Combine(directory, "GeneratorSettings.xml");
            }
        }

        public static string ProjectName
        {
            get
            {
                return "Gu.Units";
            }
        }

        public static string FolderName
        {
            get
            {
                return "Units";
            }
        }

        public List<Quantity> Quantities
        {
            get
            {
                return this._quantities;
            }
            set
            {
                this._quantities = value;
            }
        }

        [XmlIgnore]
        public IEnumerable<Unit> UnitTypes
        {
            get
            {
                var units = new List<Unit>();
                foreach (var quantity in Quantities)
                {
                    //units.Add(quantity.SiUnit);
                    //units.AddRange(quantity.Units);
                }
                return units;
            }
        }

        public List<SiUnit> SiUnitTypes
        {
            get { return _siUnitTypes; }
            set { _siUnitTypes = value; }
        }

        public List<Prefix> Prefixes
        {
            get { return _prefixes; }
            set { _prefixes = value; }
        }

        public static Settings FromFile(string fullFileName)
        {
            var serializer = new XmlSerializer(typeof(Settings));
            try
            {
                using (var stream = File.OpenRead(fullFileName))
                {
                    return (Settings)serializer.Deserialize(stream);
                }
            }
            catch (FileNotFoundException)
            {
                var settings = new Settings();
                using (var stream = File.Create(fullFileName))
                {
                    serializer.Serialize(stream, settings);
                }
                return settings;
            }
        }

        public static void Save(Settings settings, string fullFileName)
        {
            var serializer = new XmlSerializer(typeof(Settings));
            using (var stream = File.Create(fullFileName))
            {
                serializer.Serialize(stream, settings);
            }
        }
    }
}
