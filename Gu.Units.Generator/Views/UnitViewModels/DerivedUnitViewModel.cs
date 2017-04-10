namespace Gu.Units.Generator
{
    using System;
    using System.Reactive.Disposables;
    using Reactive;

    public class DerivedUnitViewModel : UnitViewModel<DerivedUnit>
    {
        private static readonly BaseUnit UnknownUnit = new BaseUnit("???", "??", "????");
        private static readonly UnitAndPower[] UnknownUnitAndPowers = { UnitAndPower.Create(UnknownUnit, 1)};
        private readonly SerialDisposable subscription = new SerialDisposable();


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

                this.Unit = new DerivedUnit(this.Unit.Name, this.Unit.Symbol, this.Unit.QuantityName, value);
                this.Subscribe();
                this.OnPropertyChanged();
            }
        }

        private void Subscribe()
        {
            this.subscription.Disposable = this.Unit.ObservePropertyChangedSlim().Subscribe(_ =>
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