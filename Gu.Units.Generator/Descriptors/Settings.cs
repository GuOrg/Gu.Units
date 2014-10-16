namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    public class Settings
    {
        private readonly List<DerivedUnit> _derivedUnits = new List<DerivedUnit>();
        private readonly List<SiUnit> _siUnits = new List<SiUnit>();
        private readonly List<Prefix> _prefixes = new List<Prefix>();
        private readonly List<Quantity> _quantities = new List<Quantity>();
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

                    foreach (var unit in settings.SiUnits)
                    {
                        unit.Namespace = NameSpace;
                        var quantity = new Quantity(unit.Namespace, unit.QuantityName, unit);
                        unit.Quantity = quantity;
                        settings._quantities.Add(quantity);
                    }
                    foreach (var unit in settings.DerivedUnits)
                    {
                        unit.Namespace = NameSpace;
                        var quantity = new Quantity(unit.Namespace, unit.QuantityName, unit);
                        settings._quantities.Add(quantity);
                        unit.Quantity = quantity;
                        foreach (var unitPart in unit.Parts)
                        {
                            if (unitPart.Unit == null)
                            {
                                unitPart.Unit = UnitBase.AllUnitsStatic.Single(x => x.ClassName == unitPart.UnitName);
                            }
                        }
                    }
                    return settings;
                }
                catch (Exception e)
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
                return null;
            }
        }

        public List<DerivedUnit> DerivedUnits
        {
            get
            {
                return _derivedUnits;
            }
        }

        public List<SiUnit> SiUnits
        {
            get { return _siUnits; }
        }

        public List<Prefix> Prefixes
        {
            get { return _prefixes; }
        }

        public List<Quantity> Quantities
        {
            get
            {
                return _quantities;
            }
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
            var toSave = new Settings();
            toSave.DerivedUnits.AddRange(settings.DerivedUnits.Where(x => x != null && !x.IsEmpty));
            toSave.SiUnits.AddRange(settings.SiUnits.Where(x => x != null && !x.IsEmpty));
            toSave.Prefixes.AddRange(settings.Prefixes.Where(x => x != null).OrderBy(x => x.Factor));
            using (var stream = File.Create(fullFileName))
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    serializer.Serialize(writer, toSave);
                }
            }
        }
    }
}
