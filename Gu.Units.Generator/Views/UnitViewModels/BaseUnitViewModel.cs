namespace Gu.Units.Generator
{
    using System;
    using Reactive;

    public class BaseUnitViewModel : UnitViewModel<BaseUnit>
    {
        public BaseUnitViewModel()
            : this(new BaseUnit(UnknownName, UnknownSymbol, UnknownName))
        {
            Unit.ObservePropertyChangedSlim().Subscribe(_ =>
            {
                if (Settings.Instance.BaseUnits.Contains(Unit))
                {
                    return;
                }

                if (!IsUnknown)
                {
                    Settings.Instance.BaseUnits.Add(Unit);
                }
            });
        }

        public BaseUnitViewModel(BaseUnit unit) 
            : base(unit)
        {
        }
    }
}
