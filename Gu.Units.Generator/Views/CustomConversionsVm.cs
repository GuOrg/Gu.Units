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
            this.Conversions.ObserveCollectionChangedSlim(signalInitial: false)
                       .Subscribe(this.Synchronize);
        }

        public ObservableCollection<CustomConversionVm> Conversions { get; } = new ObservableCollection<CustomConversionVm>();

        public void SetUnit(Unit newUnit)
        {
            this.unit = newUnit;
            this.Conversions.Clear();
            if (newUnit == null)
            {
                return;
            }

            try
            {
                this.isUpdating = true;
                foreach (var conversion in newUnit.CustomConversions)
                {
                    this.Conversions.Add(new CustomConversionVm(conversion));
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
