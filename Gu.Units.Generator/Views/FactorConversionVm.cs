namespace Gu.Units.Generator
{
    using System;
    using Reactive;

    public class FactorConversionVm : ConversionVm
    {
        public FactorConversionVm()
            : this(new FactorConversion("Unknown", "??", 0))
        {
        }

        public FactorConversionVm(FactorConversion conversion)
            : base(conversion)
        {
            conversion.ObservePropertyChanged(x => x.Factor)
                .Subscribe(_ => this.UpdateAsync());
        }
    }
}