namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ParentCollection<TParent, TItem> : ObservableCollection<TItem>
    {
        private readonly TParent _parent;
        private readonly Action<TItem, TParent> _setter;
        public ParentCollection(TParent parent, Action<TItem, TParent> setter)
        {
            _parent = parent;
            _setter = setter;
        }
        public ParentCollection(TParent parent, Action<TItem, TParent> setter, IEnumerable<TItem> items)
            : this(parent, setter)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        protected override void InsertItem(int index, TItem item)
        {
            _setter(item, _parent);
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, TItem item)
        {
            _setter(item, _parent);
            base.SetItem(index, item);
        }
    }
}
