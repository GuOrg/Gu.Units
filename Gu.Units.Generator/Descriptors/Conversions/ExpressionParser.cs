namespace Gu.Units.Generator
{
    using System.Globalization;
    using Microsoft.CodeAnalysis.CSharp.Scripting;

    internal static class ExpressionParser
    {
        internal static double Evaluate(double value, string parameter, string expression)
        {
            expression = $"double {parameter} = {value.ToString("G17", CultureInfo.InvariantCulture)};\r\n" +
                         $"return {expression};";
           return CSharpScript.EvaluateAsync<double>(expression).Result; // don't feel like async all the way :)
        }
    }
}
