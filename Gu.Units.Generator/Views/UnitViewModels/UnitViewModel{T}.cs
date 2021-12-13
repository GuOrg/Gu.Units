namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    using Gu.Reactive;
    using Gu.State;

    public abstract class UnitViewModel<TUnit> : UnitViewModel, IDisposable
        where TUnit : Unit
    {
        protected const string UnknownName = "Unknown";
        protected const string UnknownSymbol = "??";

        private readonly SerialDisposable subscription = new();

        private IChangeTracker tracker;
        private TUnit unit;
        private bool disposed;
        private bool? isOk;

        protected UnitViewModel(TUnit unit)
        {
            this.unit = unit;
            this.OnUnitChanged();
        }

        public bool? IsOk
        {
            get => this.isOk;

            private set
            {
                if (value == this.isOk)
                {
                    return;
                }

                this.isOk = value;
                this.OnPropertyChanged();
            }
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
                this.OnPropertyChanged();
                this.OnUnitChanged();
                this.OnPropertyChanged(nameof(this.IsUnknown));
            }
        }

        public bool IsUnknown => this.Unit.Name == UnknownName || this.Unit.QuantityName == UnknownName || this.Unit.Symbol == UnknownSymbol || this.Unit.Parts.Any(p => p.UnitName.Contains("?"));

        public ObservableCollection<string> Errors { get; } = new();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
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
                this.tracker?.Dispose();
                this.subscription.Dispose();
            }
        }

        protected async Task<bool> IsEverythingOkAsync()
        {
            this.Errors.Clear();
            foreach (var conversion in this.unit.AllConversions.ToList())
            {
                var canRoundtrip = await conversion.CanRoundtripAsync().ConfigureAwait(false);
                if (!canRoundtrip)
                {
                    this.Errors.Add($"{conversion.Name} cannot roundtrip");
                }
            }

            if (this.IsUnknown)
            {
                this.Errors.Add("IsUnknown");
            }

            return this.Errors.Count == 0;
        }

        protected void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

        private void OnUnitChanged()
        {
            this.tracker?.Dispose();
            this.tracker = Track.Changes(this.unit, ChangeTrackerSettings);
            this.subscription.Disposable = this.tracker
                .ObservePropertyChangedSlim(x => x.Changes)
                .Throttle(TimeSpan.FromMilliseconds(10))
                .ObserveOn(TaskPoolScheduler.Default)
                .SubscribeAsync(async () =>
                {
                    this.OnPropertyChanged(nameof(this.IsUnknown));
                    this.IsOk = await this.IsEverythingOkAsync().ConfigureAwait(false);
                });
        }
    }
}