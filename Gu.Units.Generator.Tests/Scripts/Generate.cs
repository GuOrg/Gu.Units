namespace Gu.Units.Generator.Tests.Scripts
{
    using System;
    using System.IO;

    using Gu.Units.Generator.CodeGen;

    using NUnit.Framework;

    [Ignore("Script")]
    public static class Generate
    {
        [Test]
        public static void Dump()
        {
            foreach (var line in File.ReadAllLines("C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units.Generator\\Templates\\UnitWpf.tt"))
            {
                if (line.Length == 0)
                {
                    Console.WriteLine("                .AppendLine()");
                }
                else
                {
                    Console.WriteLine($"                .AppendLine($\"{Replace()}\")");

                    string Replace()
                    {
                        return line.Replace("{", "{{")
                                   .Replace("}", "}}")
                                   .Replace("\\", "\\\\")
                                   .Replace("\"", "\\\"")
                                   .Replace("<#= Settings.Namespace #>", "Gu.Units")
                                   .Replace("<#= ", "{")
                                   .Replace(" #>", "}");
                    }
                }
            }
        }

        [Test]
        public static void WriteEnumerable()
        {
            var settings = Settings();
            File.WriteAllText("C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units\\Enumerable.generated.cs", EnumerableGenerator.Code(settings));
        }

        [Test]
        public static void WriteQuantities()
        {
            var settings = Settings();
            foreach (var quantity in settings.Quantities)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units\\{quantity.Name}.generated.cs", QuantityGenerator.Code(quantity));
            }
        }

        [Test]
        public static void WriteQuantityTypeConverters()
        {
            var settings = Settings();
            foreach (var quantity in settings.Quantities)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units\\{quantity.Name}TypeConverter.generated.cs", QuantityTypeConverterGenerator.Code(quantity));
            }
        }

        [Test]
        public static void WriteUnits()
        {
            var settings = Settings();
            foreach (var unit in settings.AllUnits)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units\\{unit.ClassName}.generated.cs", UnitGenerator.Code(unit));
            }
        }

        [Test]
        public static void WriteUnitTypeConverters()
        {
            var settings = Settings();
            foreach (var unit in settings.AllUnits)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units\\{unit.ClassName}TypeConverter.generated.cs", UnitTypeConverterGenerator.Code(unit));
            }
        }

        [Test]
        public static void WriteUnitWpfProxys()
        {
            var settings = Settings();
            foreach (var unit in settings.AllUnits)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units.Wpf\\{unit.ClassName}.generated.cs", UnitWpfProxyGenerator.Code(unit));
            }
        }

        [Test]
        public static void WriteJsonConverters()
        {
            var settings = Settings();
            foreach (var quantity in settings.Quantities)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units.Json\\{quantity.Name}JsonConverter.generated.cs", JsonConverterGenerator.Code(quantity));
            }
        }

        [Test]
        public static void WriteMarkupExtensions()
        {
            var settings = Settings();
            foreach (var quantity in settings.Quantities)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units.Wpf\\{quantity.Name}Extension.generated.cs", MarkupExtensionGenerator.Code(quantity));
            }
        }

        [Test]
        public static void WriteValueConverters()
        {
            var settings = Settings();
            foreach (var quantity in settings.Quantities)
            {
                File.WriteAllText($"C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units.Wpf\\{quantity.Name}Converter.generated.cs", ValueConverterGenerator.Code(quantity));
            }
        }

        private static Settings Settings()
        {
            Gu.Units.Generator.Settings.InnerInstance = null;
            return Gu.Units.Generator.Settings.FromResource;
        }
    }
}
