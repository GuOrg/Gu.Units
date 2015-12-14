namespace Gu.Units.Generator
{
    public class FactorConversionVm
    {
        public FactorConversionVm(FactorConversion conversion)
        {
            Conversion = conversion;
        }

        public FactorConversionVm()
        {
            Conversion = new FactorConversion("Unknown", "??", 0);
        }

        public FactorConversion Conversion { get; }
    }
}