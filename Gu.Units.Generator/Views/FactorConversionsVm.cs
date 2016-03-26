namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using Reactive;

    public class FactorConversionsVm
    {
        private Unit unit;
        private bool isUpdating;
        public FactorConversionsVm()
        {
            this.Conversions.ObserveCollectionChangedSlim(false)
                       .Subscribe(this.Synchronize);
        }

        public ObservableCollection<FactorConversionVm> Conversions { get; } = new ObservableCollection<FactorConversionVm>();

        public void SetUnit(Unit unit)
        {
            this.unit = unit;
            this.Conversions.Clear();
            if (unit == null)
            {
                return;
            }
            try
            {
                this.isUpdating = true;
                foreach (var conversion in unit.FactorConversions)
                {
                    this.Conversions.Add(new FactorConversionVm(conversion));
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
            var args = e.As<FactorConversionVm>();
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.unit.FactorConversions.Add(args.NewItems.Single().Conversion);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.unit.FactorConversions.Remove(args.OldItems.Single().Conversion);
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
