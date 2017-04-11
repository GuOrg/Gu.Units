namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reactive.Disposables;

    using Reactive;
    using State;

    public abstract class UnitViewModel<TUnit> : UnitViewModel, IDisposable
        where TUnit : Unit
    {
        protected const string UnknownName = "Unknown";
        protected const string UnknownSymbol = "??";

        private readonly SerialDisposable subscription = new SerialDisposable();

        private TUnit unit;
        private bool disposed;

        protected UnitViewModel(TUnit unit)
        {
            this.unit = unit;
            this.subscription.Disposable = Track.Changes(unit, ChangeTrackerSettings)
                .ObservePropertyChangedSlim()
                .Subscribe(_ =>
                {
                    this.OnPropertyChanged(nameof(this.IsUnknown));
                    this.OnPropertyChanged(nameof(this.IsOk));
                });
        }

        public TUnit Unit
        {
            get => this.unit;
            protected set
            {
                this.ThrowIfDisposed();
                if (Equals(value, this.unit))
                {
                    return;
                }

                this.unit = value;
                this.subscription.Disposable = Track.Changes(this.unit, ChangeTrackerSettings)
                    .ObservePropertyChangedSlim()
                    .Subscribe(_ =>
                    {
                        this.OnPropertyChanged(nameof(this.IsUnknown));
                        this.OnPropertyChanged(nameof(this.IsOk));
                    });
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.IsUnknown));
            }
        }

        public bool IsUnknown => this.Unit.Name == UnknownName || this.Unit.QuantityName == UnknownName || this.Unit.Symbol == UnknownSymbol || this.Unit.Parts.Any(p => p.UnitName.Contains("?"));

        public bool IsOk => this.IsEverythingOk();

        public ObservableCollection<string> Errors { get; } = new ObservableCollection<string>();

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            if (disposing)
            {
            }

            this.subscription.Dispose();
        }

        protected bool IsEverythingOk()
        {
            this.Errors.Clear();
            if (!this.Unit.AllConversions.All(c => c.CanRoundtrip))
            {
                foreach (var conversion in this.Unit.AllConversions.Where(x => !x.CanRoundtrip))
                {
                    this.Errors.Add($"{conversion.Name} cannot roundtrip");
                }

                return false;
            }

            if (this.IsUnknown)
            {
                this.Errors.Add("IsUnknown");
                return false;
            }

            return true;
        }

        protected void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
    }
}