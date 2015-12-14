namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Runtime.CompilerServices;
    using ChangeTracking;
    using JetBrains.Annotations;
    using Reactive;

    public abstract class UnitViewModel<TUnit> : INotifyPropertyChanged
        where TUnit : Unit
    {
        private static readonly ChangeTrackerSettings ChangeTrackerSettings = CreateChangeTrackerSettings();
        private readonly SerialDisposable subscription = new SerialDisposable();
        private TUnit unit;

        protected const string UnknownName = "Unknown";
        protected const string UnknownSymbol = "??";

        protected UnitViewModel(TUnit unit)
        {
            this.unit = unit;
            this.subscription.Disposable = ChangeTracker.Track(unit, ChangeTrackerSettings)
                .ObservePropertyChangedSlim()
                .Subscribe(_ =>
                {
                    OnPropertyChanged(nameof(IsUnknown));
                    OnPropertyChanged(nameof(IsOk));
                });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TUnit Unit
        {
            get { return this.unit; }
            protected set
            {
                if (Equals(value, this.unit))
                {
                    return;
                }
                this.unit = value;
                this.subscription.Disposable = ChangeTracker.Track(this.unit, ChangeTrackerSettings)
                    .ObservePropertyChangedSlim()
                    .Subscribe(_ =>
                    {
                        OnPropertyChanged(nameof(IsUnknown));
                        OnPropertyChanged(nameof(IsOk));
                    });
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsUnknown));
            }
        }

        public bool IsUnknown => Unit.Name == UnknownName ||
                                 Unit.QuantityName == UnknownName ||
                                 Unit.Symbol == UnknownSymbol ||
                                 Unit.Parts.Any(p => p.UnitName.Contains("?"));

        public bool IsOk => IsEverythingOk();

        public ObservableCollection<string> Errors { get; } = new ObservableCollection<string>();

        protected bool IsEverythingOk()
        {
            Errors.Clear();
            if (!Unit.AllConversions.All(c => c.CanRoundtrip))
            {
                foreach (var conversion in Unit.AllConversions.Where(x => !x.CanRoundtrip))
                {
                    Errors.Add($"{conversion.Name} cannot roundtrip");
                }
                return false;
            }

            if (IsUnknown)
            {
                Errors.Add("IsUnknown");
                return false;
            }

            return true;
        }

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static ChangeTrackerSettings CreateChangeTrackerSettings()
        {
            var settings = ChangeTrackerSettings.Default;
            settings.AddImmutableType<UnitParts>();
            settings.AddImmutableType<Quantity>();
            settings.AddImmutableType<OperatorOverload>();
            settings.AddImmutableType<InverseOverload>();
            settings.AddExplicitType<IEnumerable<IConversion>>();
            settings.AddExplicitProperty<IConversion>(x => x.Unit);
            return settings;
        }
    }
}