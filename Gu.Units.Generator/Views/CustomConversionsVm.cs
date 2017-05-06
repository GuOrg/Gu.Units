namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using Reactive;

    public sealed class CustomConversionsVm : IDisposable
    {
        private Unit unit;
        private bool isUpdating;
        private bool disposed;

        public CustomConversionsVm()
        {
            this.Conversions.ObserveCollectionChangedSlim(signalInitial: false)
                       .Subscribe(this.Synchronize);
        }

        public ObservableCollection<CustomConversionVm> Conversions { get; } = new ObservableCollection<CustomConversionVm>();

        public void SetUnit(Unit newUnit)
        {
            this.unit = newUnit;
            foreach (var conversion in this.Conversions)
            {
                conversion.Dispose();
            }

            this.Conversions.Clear();
            if (newUnit == null)
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
        }

        private void Synchronize(NotifyCollectionChangedEventArgs e)
        {
            if (this.isUpdating || this.unit == null)
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
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    throw new NotImplementedException();
                case NotifyCollectionChangedAction.Reset:
                    // NOP
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
    }
}
