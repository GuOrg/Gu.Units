namespace Gu.Units.Generator
{
    public class FactorConversionVm
    {
        public FactorConversionVm(FactorConversion conversion)
        {
            this.Conversion = conversion;
        }

        public FactorConversionVm()
        {
            this.Conversion = new FactorConversion("Unknown", "??", 0);
        }

        public FactorConversion Conversion { get; }
    }
}