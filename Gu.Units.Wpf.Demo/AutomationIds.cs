namespace Gu.Units.Wpf.Demo
{
    using System.Runtime.CompilerServices;

    public static class AutomationIds
    {
        public static readonly string MainWindow = Create();
        public static readonly string UnitsOnlyTab = Create();
        public static readonly string InputOptionsTab = Create();
        public static readonly string SymbolFormatTab = Create();
        public static readonly string StringFormatTab = Create();
        public static readonly string QuantityExtensionsTab = Create();

        public static readonly string MillimetresPerSecondInDataTemplate = Create();
        public static readonly string MillimetresPerSecondAndValueFormatF2 = Create();
        public static readonly string MillimetresPerSecondSignedSuperScriptAndValueFormatF2 = Create();
        public static readonly string CmF2BindingStringFormat = Create();
        public static readonly string F2CmInDataTemplate = Create();
        public static readonly string NullableLengthCm = Create();
        public static readonly string F2CmBindingStringFormatInControlTemplate = Create();
        public static readonly string CentimetresStringCtor = Create();
        public static readonly string MillimetresPerSecondStringProp = Create();
        public static readonly string MetresCtor = Create();
        public static readonly string MillimetresProp = Create();
        public static readonly string MillimetresDoubleBox = Create();
        public static readonly string MillimetresDoubleBoxInControlTemplate = Create();
        public static readonly string DoubleBoxNullableMillimetresStringCtor = Create();
        public static readonly string DoubleBoxMillimetresStringCtor = Create();
        public static readonly string DoubleControlNewtonsPerSquareMillimetreStringCtor = Create();
        public static readonly string DoubleControlMPaStringCtor = Create();

        public static readonly string ScalarOnly = Create();
        public static readonly string SymbolAllowed = Create();
        public static readonly string SymbolRequired = Create();

        public static readonly string SignedHatPowers = Create();
        public static readonly string FractionHatPowers = Create();
        public static readonly string SignedSuperScript = Create();
        public static readonly string FractionSuperScript = Create();

        public static readonly string F2CmBindingStringFormat = Create();
        public static readonly string F3MmStringFormat = Create();
        public static readonly string F2CmStringFormat = Create();

        private static string Create([CallerMemberName] string name = null)
        {
            return name;
        }
    }
}
