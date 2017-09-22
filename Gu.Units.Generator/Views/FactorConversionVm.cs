namespace Gu.Units.Generator
{
    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using Reactive;

    public sealed class FactorConversionVm : ConversionVm, IDisposable
    {
        private readonly IDisposable disposable;
        private bool disposed;

        public FactorConversionVm()
            : this(new FactorConversion("Unknown", "??", 0))
        {
        }

        public FactorConversionVm(FactorConversion conversion)
            : base(conversion)
        {
            this.disposable = conversion.ObservePropertyChanged(x => x.Factor)
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