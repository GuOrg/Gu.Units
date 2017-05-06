namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Reactive.Linq;
    using Reactive;

    public class CustomConversionVm : ConversionVm
    {
        public CustomConversionVm()
            : this(new CustomConversion("Unknown", null, null, null))
        {
        }

        public CustomConversionVm(CustomConversion conversion)
            : base(conversion)
        {
            Observable.Merge(
                    conversion.ObservePropertyChangedSlim(x => x.Symbol, signalInitial: false),
                    conversion.ObservePropertyChangedSlim(x => x.ToSi, signalInitial: false),
                    conversion.ObservePropertyChangedSlim(x => x.FromSi, signalInitial: false))
                .StartWith(new PropertyChangedEventArgs(null))
                .Subscribe(_ => this.UpdateAsync());
        }
    }
}