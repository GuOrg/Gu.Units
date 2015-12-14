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
            Subscribe();
        }


        public DerivedUnitViewModel(DerivedUnit unit)
            : base(unit)
        {
        }

        public UnitParts UnitParts
        {
            get { return Unit.Parts; }
            set
            {
                if (Equals(value, UnitParts))
                {
                    return;
                }

                Unit = new DerivedUnit(Unit.Name, Unit.Symbol, Unit.QuantityName, value);
                Subscribe();
                OnPropertyChanged();
            }
        }

        private void Subscribe()
        {
            this.subscription.Disposable = Unit.ObservePropertyChangedSlim().Subscribe(_ =>
            {
                if (Settings.Instance.DerivedUnits.Contains(Unit))
                {
                    this.subscription.Disposable.Dispose();
                    return;
                }

                if (!IsUnknown)
                {
                    Settings.Instance.DerivedUnits.Add(Unit);
                }
            });
        }
    }
}