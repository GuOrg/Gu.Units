namespace Gu.Units.Generator.Tests.Scripts
{
    using System;
    using System.IO;

    using Gu.Units.Generator.CodeGen;

    using NUnit.Framework;

    public static class Generate
    {
        // [Ignore("Script")]
        [Test]
        public static void Dump()
        {
            foreach (var line in File.ReadAllLines("C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units.Generator\\Templates\\Quantity.tt"))
            {
                if (line.Length == 0)
                {
                    Console.WriteLine(".AppendLine()");
                }
                else
                {
                    Console.WriteLine($".AppendLine($\"{Replace()}\")");

                    string Replace()
                    {
                        return line.Replace("{", "{{")
                                   .Replace("}", "}}")
                                   .Replace("\"", "\\\"")
                                   .Replace("<#= ", "{")
                                   .Replace(" #>", "}")
                                   .Replace("<#= Settings.Namespace #>", "Gu.Units");
                    }
                }
            }
        }

        [Ignore("Script")]
        [Test]
        public static void WriteEnumerable()
        {
            Settings.InnerInstance = null;
            File.WriteAllText("C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units\\Enumerable.generated.cs", EnumerableGenerator.Code(Settings.FromResource));
        }
    }
}
