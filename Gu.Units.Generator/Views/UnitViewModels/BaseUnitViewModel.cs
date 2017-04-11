namespace Gu.Units.Generator
{
    using System;
    using Reactive;

    public class BaseUnitViewModel : UnitViewModel<BaseUnit>
    {
        public BaseUnitViewModel()
            : this(new BaseUnit(UnknownName, UnknownSymbol, UnknownName))
        {
            this.Unit.ObservePropertyChangedSlim().Subscribe(_ =>
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
    }
}
