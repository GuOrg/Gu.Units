namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class UnitCollection<T> : ObservableCollection<T>
        where T : IUnit
    {
        private readonly List<T> _units;
        private readonly Func<T, T> _creator;
        private bool _initialized;
        public UnitCollection(List<T> units, Func<T, T> creator)
        {
            this._units = units;
            _creator = creator;
            foreach (var unit in units)
            {
                base.Add(unit);
                //var item = creator(unit);
                //item.Quantity = unit.Quantity;
                //base.Add(item);
            }
            this.InvokeAddRange(units);
            _initialized = true;
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
        }
    }
}
