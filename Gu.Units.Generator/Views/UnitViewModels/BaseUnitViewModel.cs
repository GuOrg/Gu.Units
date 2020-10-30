namespace Gu.Units.Generator
{
    using System;
    using System.Reactive.Disposables;
    using Gu.Reactive;

    public class BaseUnitViewModel : UnitViewModel<BaseUnit>
    {
        private readonly SerialDisposable subscription = new SerialDisposable();

        public BaseUnitViewModel()
            : this(new BaseUnit(UnknownName, UnknownSymbol, UnknownName))
        {
            this.subscription.Disposable = this.Unit.ObservePropertyChangedSlim()
                .Subscribe(_ =>
                {
                    if (Settings.Instance.BaseUnits.Contains(this.Unit))
                    {
                        return;
                    }

                    if (!this.IsUnknown)
                    {
                        Settings.Instance.BaseUnits.Add(this.Unit);
                    }
                });
        }

        public BaseUnitViewModel(BaseUnit unit)
            : base(unit)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.subscription.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
