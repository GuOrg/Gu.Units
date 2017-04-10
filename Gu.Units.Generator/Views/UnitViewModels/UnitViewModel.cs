namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;
    using Reactive;
    using State;

    public abstract class UnitViewModel<TUnit> : INotifyPropertyChanged
        where TUnit : Unit
    {
        private static readonly PropertiesSettings ChangeTrackerSettings = CreateChangeTrackerSettings();
        private readonly SerialDisposable subscription = new SerialDisposable();
        private TUnit unit;

        protected const string UnknownName = "Unknown";
        protected const string UnknownSymbol = "??";

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

        public event PropertyChangedEventHandler PropertyChanged;

        public TUnit Unit
        {
            get => this.unit;
            protected set
            {
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

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static PropertiesSettings CreateChangeTrackerSettings()
        {
            var settings = PropertiesSettings.Build()
                                             .AddImmutableType<UnitParts>()
                                             .AddImmutableType<OperatorOverload>()
                                             .AddImmutableType<IEnumerable<IConversion>>()
                                             .CreateSettings();
            return settings;
        }
    }
}