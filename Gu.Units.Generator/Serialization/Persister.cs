namespace Gu.Units.Generator
{
    using System.IO;
    using System.Reflection;
    using Newtonsoft.Json;

    public static class Persister
    {
        public static readonly JsonSerializerSettings SerializerSettings = CreateSettings();
        public static string SettingsFileName
        {
            get
            {
                var directoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
                var directory = directoryInfo.Parent.Parent.Parent.FullName; // Perhaps not the most elegant code ever written
                return System.IO.Path.Combine(directory, "Units.txt");
            }
        }

        public static bool IsDirty
        {
            get
            {
                if (Settings.Instance == null)
                {
                    return true;
                }

                var json = JsonConvert.SerializeObject(Settings.Instance, SerializerSettings);
                var file = File.ReadAllText(SettingsFileName);
                return json != file;
            }
        }

        public static Settings GetSettingsFromFile()
        {
            if (Settings.Instance == null)
            {
                var json = File.ReadAllText(SettingsFileName);
                Settings.InnerInstance = JsonConvert.DeserializeObject<Settings>(json, SerializerSettings);
            }
            return Settings.Instance;
        }

        public static void Save(string fileName)
        {
            var json = JsonConvert.SerializeObject(Settings.Instance, SerializerSettings);
            File.WriteAllText(fileName, json);
        }

        private static JsonSerializerSettings CreateSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                ContractResolver = ExcludeCalculatedResolver.Default,
                MissingMemberHandling = MissingMemberHandling.Error
            };
        }
    }
}
