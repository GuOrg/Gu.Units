namespace Gu.Units.Generator
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.CSharp.Scripting;

    internal static class ExpressionParser
    {
        [Obsolete("Don't use this")]
        internal static double Evaluate(double value, string parameter, string expression)
        {
            return EvaluateAsync(value, parameter, expression).Result; // Nasty here.
        }

        internal static Task<double> EvaluateAsync(double value, string parameter, string expression)
        {
            expression = $"double {parameter} = {value.ToString("G17", CultureInfo.InvariantCulture)};\r\n" +
                         $"return {expression};";
            return CSharpScript.EvaluateAsync<double>(expression);
        }
    }
}
