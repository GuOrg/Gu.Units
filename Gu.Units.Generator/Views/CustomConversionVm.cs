namespace Gu.Units.Generator
{
    public class CustomConversionVm
    {
        public CustomConversionVm()
            : this(new CustomConversion("Unknown", null, null, null))
        {
        }

        public CustomConversionVm(CustomConversion conversion)
        {
            this.Conversion = conversion;
        }

        public CustomConversion Conversion { get; }
    }
}