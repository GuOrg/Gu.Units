namespace Gu.Units.Generator.Tests.Scripts
{
    using System;
    using System.IO;
    using System.Linq;
    using NUnit.Framework;

    public static class Generate
    {
        [Ignore("Script")]
        [Test]
        public static void Dump()
        {
            var t4 = "         /// <summary>\r\n" +
                           "        /// Calculates the sum <see cref=\"<#= quantity.Name #>\"/> of the values in <paramref name=\"source\"/>\r\n" +
                           "        /// </summary>\r\n" +
                           "        /// <param name=\"source\"><see cref=\"IEnumerable{<#= quantity.Name #>}\"/></param>\r\n" +
                           "        /// <returns>The sum</returns>\r\n" +
                           "        public static <#= quantity.Name #> Sum(this IEnumerable<<#= quantity.Name #>> source)\r\n" +
                           "        {\r\n" +
                           "            if (source == null)\r\n" +
                           "            {\r\n" +
                           "                throw new ArgumentNullException(\"source\");\r\n" +
                           "            }\r\n" +
                           "\r\n" +
                           "            double sum = 0;\r\n" +
                           "            checked\r\n" +
                           "            {\r\n" +
                           "                foreach (var v in source)\r\n" +
                           "                {\r\n" +
                           "                    sum += v.<#= quantity.Unit.ParameterName #>;\r\n" +
                           "                }\r\n" +
                           "            }\r\n" +
                           "\r\n" +
                           "            return <#= quantity.Name #>.From<#= quantity.Unit.Name #>(sum);\r\n" +
                           "        }";

            foreach (var line in File.ReadAllLines("C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units.Generator\\Templates\\Enumerable.tt").Skip(200))
            {
                if (line.Length == 0)
                {
                    Console.WriteLine(".AppendLine()");
                }
                else
                {
                    Console.WriteLine($".AppendLine($\"{line.Replace("{", "{{").Replace("}", "}}").Replace("\"", "\\\"").Replace("<#= ", "{").Replace(" #>", "}")}\")");
                }
            }
        }

        [Ignore("Script")]
        [Test]
        public static void WriteEnumerable()
        {
            Settings.InnerInstance = null;
            File.WriteAllText("C:\\Git\\_GuOrg\\Gu.Units\\Gu.Units\\Enumerable.generated.cs", Gu.Units.Generator.CodeGen.Enumerable.Code(Settings.FromResource));
        }
    }
}
