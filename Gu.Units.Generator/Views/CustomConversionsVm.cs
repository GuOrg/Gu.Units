namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using Reactive;

    public class CustomConversionsVm
    {
        private Unit unit;
        private bool isUpdating;

        public CustomConversionsVm()
        {
            Conversions.ObserveCollectionChangedSlim(false)
                       .Subscribe(Synchronize);
        }

        public ObservableCollection<CustomConversionVm> Conversions { get; } = new ObservableCollection<CustomConversionVm>();

        public void SetUnit(Unit unit)
        {
            this.unit = unit;
            Conversions.Clear();
            if (unit == null)
            {
                return;
            }
            try
            {
                this.isUpdating = true;
                foreach (var conversion in unit.CustomConversions)
                {
                    Conversions.Add(new CustomConversionVm(conversion));
                }
            }
            finally
            {
                this.isUpdating = false;
            }
        }

        private void Synchronize(NotifyCollectionChangedEventArgs e)
        {
            if (this.isUpdating || this.unit == null)
            {
                return;
            }
            var args = e.As<CustomConversionVm>();
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.unit.CustomConversions.Add(args.NewItems.Single().Conversion);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.unit.CustomConversions.Remove(args.OldItems.Single().Conversion);
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    throw new NotImplementedException();
                case NotifyCollectionChangedAction.Reset:
                    // NOP
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
