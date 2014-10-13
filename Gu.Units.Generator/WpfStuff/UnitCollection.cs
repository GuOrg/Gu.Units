namespace Gu.Units.Generator.WpfStuff
{
    using System.Collections.ObjectModel;

    public class UnitCollection<T> : ObservableCollection<T>
        where T : IUnit
    {
        protected override void InsertItem(int index, T item)
        {

            base.InsertItem(index, item);
        }
    }
}
