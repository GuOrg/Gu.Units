namespace Gu.Units.Generator
{
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.CSharp.Scripting;

    internal static class ExpressionParser
    {
        internal static Task<double> EvaluateAsync(double value, string parameter, string expression)
        {
            expression = $"double {parameter} = {value.ToString("G17", CultureInfo.InvariantCulture)};\r\n" +
                         $"return {expression};";
            return CSharpScript.EvaluateAsync<double>(expression);
        }
    }
}
