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
        private static Settings _instance;
        private readonly ParentCollection<Settings, DerivedUnit> _derivedUnits;
        private readonly ParentCollection<Settings, SiUnit> _siUnits;
        private readonly ObservableCollection<Prefix> _prefixes = new ObservableCollection<Prefix>();

        protected Settings()
        {
            _derivedUnits = new ParentCollection<Settings, DerivedUnit>(this, (unit, settings) => unit.Settings = settings);
            _siUnits = new ParentCollection<Settings, SiUnit>(this, (unit, settings) => unit.Settings = settings);
        }

        public static Settings Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                try
                {
                    var serializer = new XmlSerializer(typeof(Settings));
                    Settings settings;
                    using (var reader = new StringReader(Properties.Resources.GeneratorSettings))
                    {
                        settings = (Settings)serializer.Deserialize(reader);
                    }
                    _instance = settings;
                    return settings;
                }
                catch (Exception e)
                {
                    _instance = new Settings();
                    return _instance;
                }
            }
        }

        public static string Namespace
        {
            get
            {
                return "Gu.Units"; // Hardcoding to avoid ref
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

        /// <summary>
        /// The extension for the generated files, set to txt if it does not build so you can´inspect the reult
        /// cs when everything works
        /// </summary>
        public static string Extension
        {
            get
            {
                return "cs";
            }
        }

        public ObservableCollection<DerivedUnit> DerivedUnits
        {
            get
            {
                return _derivedUnits;
            }
        }

        public ObservableCollection<SiUnit> SiUnits
        {
            get { return _siUnits; }
        }

        public ObservableCollection<Prefix> Prefixes
        {
            get { return _prefixes; }
        }

        public IReadOnlyList<IUnit> AllUnits => SiUnits.Concat<IUnit>(DerivedUnits).ToList();

        public IReadOnlyList<Quantity> Quantities => AllUnits.Select(x => x.Quantity).ToList();

        public static Settings FromFile(string fullFileName)
        {
            var serializer = new XmlSerializer(typeof(Settings));
            try
            {
                Settings settings;
                using (var reader = new StringReader(fullFileName))
                {
                    settings = (Settings)serializer.Deserialize(reader);
                }
                return settings;
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
            toSave.DerivedUnits.InvokeAddRange(settings.DerivedUnits.Where(x => x != null && !x.IsEmpty));
            toSave.SiUnits.InvokeAddRange(settings.SiUnits.Where(x => x != null && !x.IsEmpty));
            toSave.Prefixes.InvokeAddRange(settings.Prefixes.Where(x => x != null).OrderBy(x => x.Power));
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
