namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using Gu.Reactive;

    public sealed class CustomConversionsVm : IDisposable
    {
        private readonly IDisposable disposable;
        private Unit unit;
        private bool isUpdating;
        private bool disposed;

        public CustomConversionsVm()
        {
            this.disposable = this.Conversions.ObserveCollectionChangedSlim(signalInitial: false)
                            .Subscribe(this.Synchronize);
        }

        public ObservableCollection<CustomConversionVm> Conversions { get; } = new();

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
                foreach (var conversion in newUnit.CustomConversions)
                {
                    this.Conversions.Add(new CustomConversionVm(conversion));
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
            foreach (var conversion in this.Conversions)
            {
                conversion.Dispose();
            }

            this.Conversions.Clear();
            this.disposable?.Dispose();
        }

        private void Synchronize(NotifyCollectionChangedEventArgs e)
        {
            if (this.isUpdating || this.unit is null)
            {
                return;
            }

            var args = e.As<CustomConversionVm>();
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.unit.CustomConversions.Add((CustomConversion)args.NewItems.Single().Conversion);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.unit.CustomConversions.Remove((CustomConversion)args.OldItems.Single().Conversion);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    // NOP
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(args.Action), (int)args.Action, typeof(NotifyCollectionChangedAction));
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(CustomConversionsVm));
            }
        }
    }
}
