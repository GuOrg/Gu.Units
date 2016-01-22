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
        public static readonly string MillimetresPerSecondInDataTemplate = Create();
        public static readonly string CentimetresInControlTemplate = Create();
        public static readonly string CentimetresStringCtor = Create();
        public static readonly string MillimetresPerSecondStringProp = Create();
        public static readonly string MetresCtor = Create();
        public static readonly string MillimetresProp = Create();
        public static readonly string DoubleControlMillimetresStringCtor = Create();
        public static readonly string DoubleControlNewtonsPerSquareMillimetreStringCtor = Create();
        public static readonly string DoubleControlMPaStringCtor = Create();

        public static readonly string ScalarOnly = Create();
        public static readonly string SymbolAllowed = Create();
        public static readonly string SymbolRequired = Create();

        public static readonly string SignedHatPowers = Create();
        public static readonly string FractionHatPowers = Create();
        public static readonly string SignedSuperScript = Create();
        public static readonly string FractionSuperScript = Create();

        public static readonly string BindingCentimetreFormat = Create();
        public static readonly string ConverterMillimetreFormat = Create();
        public static readonly string ConverterCentimetreFormat = Create();

        private static string Create([CallerMemberName] string name = null)
        {
            return name;
        }
    }
}
