namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;

    using Gu.Reactive;

    public sealed class FactorConversionsVm : IDisposable
    {
        private readonly IDisposable disposable;

        private Unit unit;
        private bool isUpdating;
        private bool disposed;

        public FactorConversionsVm()
        {
            this.disposable = this.Conversions.ObserveCollectionChangedSlim(signalInitial: false)
                .Subscribe(this.Synchronize);
        }

        public ObservableCollection<FactorConversionVm> Conversions { get; } = new();

        public void SetUnit(Unit newUnit)
        {
            this.ThrowIfDisposed();
            this.unit = newUnit;
            foreach (var conversion in this.Conversions)
            {
                conversion.Dispose();
            }

            this.Conversions.Clear();
            if (newUnit is null)
            {
                return;
            }

            try
            {
                this.isUpdating = true;
                foreach (var conversion in newUnit.FactorConversions)
                {
                    this.Conversions.Add(new FactorConversionVm(conversion));
                }
            }
            finally
            {
                this.isUpdating = false;
            }
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

        private void Synchronize(NotifyCollectionChangedEventArgs e)
        {
            if (this.isUpdating || this.unit is null)
            {
                return;
            }

            var args = e.As<FactorConversionVm>();
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.unit.FactorConversions.Add((FactorConversion)args.NewItems.Single().Conversion);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.unit.FactorConversions.Remove((FactorConversion)args.OldItems.Single().Conversion);
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    throw new NotSupportedException();
                case NotifyCollectionChangedAction.Reset:
                    // NOP
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(e), e.Action, "Not handling");
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(FactorConversionsVm));
            }
        }
    }
}
