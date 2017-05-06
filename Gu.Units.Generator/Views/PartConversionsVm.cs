namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Reactive;

    public sealed class PartConversionsVm : INotifyPropertyChanged, IDisposable
    {
        private readonly ObservableCollection<PartConversionVm[]> conversions = new ObservableCollection<PartConversionVm[]>();
        private Unit unit;
        private bool disposed;

        public PartConversionsVm()
        {
            this.UsedConversions = this.AllConversions.AsReadOnlyFilteredView(
                x => x.IsUsed,
                this.AllConversions.ObserveItemPropertyChangedSlim(x => x.IsUsed));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IReadOnlyObservableCollection<PartConversionVm> UsedConversions { get; }

        public ObservableBatchCollection<PartConversionVm> AllConversions { get; } = new ObservableBatchCollection<PartConversionVm>();

        public ObservableCollection<PartConversionVm[]> Conversions => this.conversions;

        public bool HasItems => this.Conversions.Any(x => x.Length > 0);

        public void SetUnit(Unit value)
        {
            this.unit = value;
            foreach (var conversion in this.AllConversions)
            {
                conversion.Dispose();
            }

            this.conversions.Clear();

            if (this.unit == null)
            {
                this.OnPropertyChanged(nameof(this.HasItems));
                return;
            }

            if (this.unit.Parts.BaseParts.Count == 1)
            {
                var part = this.unit.Parts.BaseParts.Single();
                if (part.Power == 1)
                {
                    return;
                }

                var unitParts = this.unit.Parts.BaseParts.ToArray();
                var powerParts = CreatePowerParts(unitParts, 0);

                var partConversionVms = powerParts.Select(x => new PartConversionVm(this.unit, PartConversion.Create(this.unit, x)))
                    .ToArray();
                if (partConversionVms.Any())
                {
                    this.conversions.Add(partConversionVms);
                }
            }
            else if (this.unit.Parts.Count == 2)
            {
                var unitParts = this.unit.Parts.ToArray();
                var p0s = CreatePowerParts(unitParts, 0);
                var p1s = CreatePowerParts(unitParts, 1);
                foreach (var c1 in p0s)
                {
                    var cs = new List<PartConversionVm>();

                    foreach (var c2 in p1s)
                    {
                        cs.Add(new PartConversionVm(this.unit, PartConversion.Create(this.unit, c1, c2)));
                    }

                    var conversionVms = cs.ToArray();
                    if (conversionVms.Any())
                    {
                        this.conversions.Add(conversionVms);
                    }
                }
            }

            foreach (var items in this.conversions)
            {
                this.AllConversions.AddRange(items);
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
            this.Conversions.Clear();
        }

        private static IReadOnlyList<PartConversion.PowerPart> CreatePowerParts(IReadOnlyList<UnitAndPower> parts, int index)
        {
            var powerParts = new List<PartConversion.PowerPart>();
            var unitAndPower = parts[index];
            powerParts.Add(new PartConversion.PowerPart(unitAndPower.Power, new PartConversion.IdentityConversion(unitAndPower.Unit)));
            powerParts.AddRange(unitAndPower.Unit.AllConversions.OfType<IFactorConversion>().Select(x => new PartConversion.PowerPart(unitAndPower.Power, x)));
            return powerParts;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
