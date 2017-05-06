namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Reactive;

    [DebuggerDisplay("{Conversion.Symbol}")]
    public sealed class PrefixConversionVm : ConversionVm, IDisposable
    {
        private readonly IList<PrefixConversion> conversions;
        private readonly IDisposable disposable;
        private bool disposed;

        private PrefixConversionVm(ObservableCollection<PrefixConversion> conversions, PrefixConversion prefixConversion)
            : base(prefixConversion)
        {
            this.conversions = conversions;
            this.disposable = new CompositeDisposable
            {
                conversions.ObservePropertyChangedSlim()
                    .SubscribeOn(TaskPoolScheduler.Default)
                    .Subscribe(_ => this.OnPropertyChanged(nameof(this.IsUsed))),

                prefixConversion.ObservePropertyChanged(x => x.Symbol)
                    .SubscribeOn(TaskPoolScheduler.Default)
                    .Where(_ => this.IsUsed)
                    .Subscribe(_ => this.UpdateAsync())
            };
        }

        public bool IsUsed
        {
            get => this.conversions.Any(this.IsMatch);
            set
            {
                if (value.Equals(this.IsUsed))
                {
                    return;
                }

                if (value)
                {
                    this.conversions.Add((PrefixConversion)this.Conversion);
                }
                else
                {
                    var match = this.conversions.FirstOrDefault(this.IsMatch);
                    if (match != null)
                    {
                        this.conversions.Remove(match);
                    }
                }

                this.OnPropertyChanged();
            }
        }

        public static PrefixConversionVm Create(Unit unit, Prefix prefix)
        {
            var prefixConversion = PrefixConversion.Create(unit, prefix);
            return new PrefixConversionVm(unit.PrefixConversions, prefixConversion);
        }

        public static PrefixConversionVm Create(FactorConversion factorConversion, Prefix prefix)
        {
            var prefixConversion = PrefixConversion.Create(factorConversion, prefix);
            return new PrefixConversionVm(factorConversion.PrefixConversions, prefixConversion);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.disposable.Dispose();
        }

        private bool IsMatch(PrefixConversion x)
        {
            if (((PrefixConversion)this.Conversion).Prefix.Power != x.Prefix.Power)
            {
                return false;
            }

            return true;
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