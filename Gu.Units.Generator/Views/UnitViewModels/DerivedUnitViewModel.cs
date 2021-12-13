namespace Gu.Units.Generator
{
    using System;
    using System.Reactive.Disposables;
    using Gu.Reactive;

    public class DerivedUnitViewModel : UnitViewModel<DerivedUnit>
    {
        private static readonly BaseUnit UnknownUnit = new("???", "??", "????");
        private static readonly UnitAndPower[] UnknownUnitAndPowers = { UnitAndPower.Create(UnknownUnit, 1) };
        private readonly SerialDisposable subscription = new();

        public DerivedUnitViewModel()
            : this(new DerivedUnit(UnknownName, UnknownSymbol, UnknownName, UnknownUnitAndPowers))
        {
            this.Subscribe();
        }

        public DerivedUnitViewModel(DerivedUnit unit)
            : base(unit)
        {
        }

        public UnitParts UnitParts
        {
            get => this.Unit.Parts;
            set
            {
                if (Equals(value, this.UnitParts))
                {
                    return;
                }

                var symbol = this.Unit.Symbol == UnknownSymbol
                    ? value?.ToString()
                    : this.Unit.Symbol;
                this.Unit = new DerivedUnit(this.Unit.Name, symbol, this.Unit.QuantityName, value);
                this.Subscribe();
                this.OnPropertyChanged();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.subscription.Dispose();
            }

            base.Dispose(disposing);
        }

        private void Subscribe()
        {
            this.subscription.Disposable = this.Unit.ObservePropertyChangedSlim()
                .Subscribe(_ =>
                {
                    if (Settings.Instance.DerivedUnits.Contains(this.Unit))
                    {
                        this.subscription.Disposable.Dispose();
                        return;
                    }

                    if (!this.IsUnknown)
                    {
                        Settings.Instance.DerivedUnits.Add(this.Unit);
                    }
                });
        }
    }
}