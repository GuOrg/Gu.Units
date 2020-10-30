namespace Gu.Units.Generator
{
    using System;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Gu.Reactive;

    public sealed class PartConversionVm : ConversionVm, IDisposable
    {
        private readonly Unit unit;
        private readonly IDisposable disposable;

        private bool disposed;

        public PartConversionVm(Unit unit, PartConversion conversion)
            : base(conversion)
        {
            this.unit = unit;
            this.IsEditable = this.Conversion.Name != unit.Name;
            this.disposable = new CompositeDisposable
            {
                unit.PartConversions.ObservePropertyChangedSlim()
                    .SubscribeOn(TaskPoolScheduler.Default)
                    .Subscribe(_ => this.OnPropertyChanged(nameof(this.IsUsed))),
                conversion.ObservePropertyChanged(x => x.Symbol)
                    .SubscribeOn(TaskPoolScheduler.Default)
                    .Where(_ => this.IsUsed)
                    .Subscribe(_ => this.UpdateAsync()),
            };
        }

        public bool IsEditable { get; }

        public bool IsUsed
        {
            get
            {
                if (!this.IsEditable)
                {
                    return true;
                }

                return this.unit.PartConversions.Any(this.IsMatch);
            }

            set
            {
                this.ThrowIfDisposed();
                if (value.Equals(this.IsUsed) || !this.IsEditable)
                {
                    return;
                }

                if (value)
                {
                    this.unit.PartConversions.Add((PartConversion)this.Conversion);
                }
                else
                {
                    var match = this.unit.PartConversions.FirstOrDefault(this.IsMatch);
                    if (match != null)
                    {
                        this.unit.PartConversions.Remove(match);
                    }
                }

                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return this.Conversion.Symbol;
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

        private bool IsMatch(PartConversion x)
        {
            //// ReSharper disable once CompareOfFloatsByEqualityOperator
            if (((PartConversion)this.Conversion).Factor != x.Factor)
            {
                return false;
            }

            if (this.Conversion.Name != x.Name)
            {
                return false;
            }

            return true;
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(PartConversionVm));
            }
        }
    }
}
