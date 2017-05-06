namespace Gu.Units.Generator
{
    public class FactorConversionVm
    {
        public FactorConversionVm()
            : this(new FactorConversion("Unknown", "??", 0))
        {
        }

        public FactorConversionVm(FactorConversion conversion)
        {
            this.Conversion = conversion;
        }

        public FactorConversion Conversion { get; }
    }
}