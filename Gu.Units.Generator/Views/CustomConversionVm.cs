namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using Gu.Reactive;

    public sealed class CustomConversionVm : ConversionVm, IDisposable
    {
        private readonly IDisposable disposable;

        private bool disposed;

        public CustomConversionVm()
            : this(new CustomConversion("Unknown", null, null, null))
        {
        }

        public CustomConversionVm(CustomConversion conversion)
            : base(conversion)
        {
            this.disposable = Observable.Merge(
                    conversion.ObservePropertyChangedSlim(x => x.Symbol, signalInitial: false),
                    conversion.ObservePropertyChangedSlim(x => x.ToSi, signalInitial: false),
                    conversion.ObservePropertyChangedSlim(x => x.FromSi, signalInitial: false))
                .StartWith(new PropertyChangedEventArgs(null))
                .SubscribeOn(TaskPoolScheduler.Default)
                .Subscribe(_ => this.UpdateAsync());
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.disposable?.Dispose();
        }
    }
}