namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Gu.Reactive;

    public sealed class PrefixConversionsVm : INotifyPropertyChanged, IDisposable
    {
        private readonly Settings settings;
        private Unit unit;
        private bool disposed;

        public PrefixConversionsVm(Settings settings)
        {
            this.settings = settings;
            this.UsedConversions = this.AllConversions.AsReadOnlyFilteredView(
                x => x.IsUsed,
                this.AllConversions.ObserveItemPropertyChangedSlim(x => x.IsUsed));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IReadOnlyObservableCollection<ConversionVm> UsedConversions { get; }

        public ObservableBatchCollection<PrefixConversionVm> AllConversions { get; } = new();

        public ObservableCollection<IReadOnlyList<PrefixConversionVm>> Prefixes { get; } = new();

        public Unit Unit
        {
            get => this.unit;
            set
            {
                if (Equals(value, this.unit))
                {
                    return;
                }

                this.unit = value;
                this.OnPropertyChanged();
            }
        }

        public bool HasItems => this.Prefixes.Any();

        public void SetBaseUnit(Unit value)
        {
            this.ThrowIfDisposed();
            this.Unit = value;
            this.Prefixes.Clear();
            foreach (var conversion in this.AllConversions)
            {
                conversion.Dispose();
            }

            this.AllConversions.Clear();
            if (this.unit != null)
            {
                if (this.IsValidPrefixUnit(this.unit))
                {
                    this.Prefixes.Add(this.settings.Prefixes.Select(x => PrefixConversionVm.Create(this.unit, x)).ToArray());
                }

                foreach (var conversion in this.unit.FactorConversions)
                {
                    var prefixConversionVms = this.settings.Prefixes.Select(x => PrefixConversionVm.Create(conversion, x))
                                                                    .Where(x => !string.Equals(x.Conversion.Name, this.unit.Name, StringComparison.OrdinalIgnoreCase)) // filter out kilograms
                                                                    .ToArray();
                    this.Prefixes.Add(prefixConversionVms);
                    this.AllConversions.AddRange(prefixConversionVms);
                }
            }

            this.OnPropertyChanged(nameof(this.HasItems));
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            (this.UsedConversions as IDisposable)?.Dispose();
            foreach (var conversion in this.AllConversions)
            {
                conversion.Dispose();
            }

            this.AllConversions.Clear();
            this.Prefixes.Clear();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(PrefixConversionsVm));
            }
        }

        private bool IsValidPrefixUnit(INameAndSymbol item)
        {
            if (this.settings.Prefixes.Any(p => item.Name.StartsWith(p.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            if (item is BaseUnit)
            {
                return true;
            }

            if (item is DerivedUnit derivedUnit)
            {
                if (SymbolAndPowerReader.TryRead(derivedUnit.Symbol, out var symbolAndPowers))
                {
                    return symbolAndPowers.Count == 1 && symbolAndPowers[0].Power == 1;
                }

                return false;
            }

            return item is FactorConversion;
        }
    }
}
