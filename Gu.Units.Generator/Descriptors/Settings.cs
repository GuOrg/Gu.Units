namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Serialization;

    public class Settings
    {
        private readonly ObservableCollection<Quantity> composites = new ObservableCollection<Quantity>();
        private readonly ObservableCollection<SiUnit> _siUnitTypes = new ObservableCollection<SiUnit>();
        private readonly ObservableCollection<Prefix> _prefixes = new ObservableCollection<Prefix>();

        public static Settings Instance
        {
            get
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(Settings));
                    Settings settings;
                    using (var reader = new StringReader(Properties.Resources.GeneratorSettings))
                    {
                        settings = (Settings)serializer.Deserialize(reader);
                    }
                    foreach (var unit in settings.SiUnitTypes)
                    {
                        unit.Quantity.Units.Clear();
                        unit.Quantity.Units.Add(new UnitAndPower(unit));
                    }
                    return settings;
                }
                catch (Exception)
                {
                    return new Settings();
                }
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

        public ObservableCollection<Quantity> Composites
        {
            get
            {
                return composites;
            }
        }

        [XmlIgnore]
        public IEnumerable<Unit> UnitTypes
        {
            get
            {
                var units = new List<Unit>();
                foreach (var quantity in this.Composites)
                {
                    //units.Add(quantity.SiUnit);
                    //units.AddRange(quantity.Units);
                }
                return units;
            }
        }

        public ObservableCollection<SiUnit> SiUnitTypes
        {
            get { return _siUnitTypes; }
        }

        public ObservableCollection<Prefix> Prefixes
        {
            get { return _prefixes; }
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
