namespace GeneratorBox.Generator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    public class Settings
    {
        private List<ValueMetaData> _valueTypes = new List<ValueMetaData>();

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
                foreach (var value in settings.ValueTypes)
                {
                    foreach (var unit in value.Units)
                    {
                        unit.ValueType = value.ClassName;
                    }
                }
                return settings;
            }
        }

        public static string NameSpace
        {
            get
            {
                return "GeneratorBox";
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
                return "GeneratorBox";
            }
        }

        public static string FolderName
        {
            get
            {
                return "Units";
            }
        }

        public List<ValueMetaData> ValueTypes
        {
            get
            {
                return this._valueTypes;
            }
            set
            {
                this._valueTypes = value;
            }
        }

        [XmlIgnore]
        public IEnumerable<UnitMetaData> UnitTypes
        {
            get
            {
                var datas = new List<UnitMetaData>();
                foreach (var value in ValueTypes)
                {
                    datas.Add(value.SiUnit);
                    datas.AddRange(value.Units);
                }
                return datas;
            }
        }

        [XmlIgnore]
        public IEnumerable<UnitMetaData> SiUnitTypes
        {
            get
            {
                return this.ValueTypes.Select(value => value.SiUnit).ToList();
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
            using (var stream = File.Create(fullFileName))
            {
                serializer.Serialize(stream, settings);
            }
        }
    }
}
