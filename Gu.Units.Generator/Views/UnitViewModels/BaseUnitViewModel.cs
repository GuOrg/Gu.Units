namespace Gu.Units.Generator
{
    using System;
    using System.Reactive.Disposables;
    using Gu.Reactive;

    public class BaseUnitViewModel : UnitViewModel<BaseUnit>
    {
        private readonly SerialDisposable subscription = new();

        public BaseUnitViewModel()
            : this(new BaseUnit(UnknownName, UnknownSymbol, UnknownName))
        {
            this.subscription.Disposable = this.ObserveValue(x => x.Unit)
                .Subscribe(x =>
                {
                    if (Settings.Instance.BaseUnits.Contains(x.Value))
                    {
                        return;
                    }

                    if (!this.IsUnknown)
                    {
                        Settings.Instance.BaseUnits.Add(x.Value);
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
