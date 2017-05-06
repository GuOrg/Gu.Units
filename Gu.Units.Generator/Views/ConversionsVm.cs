namespace Gu.Units.Generator
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Data;
    using System.Windows.Input;
    using Wpf.Reactive;

    public sealed class ConversionsVm : INotifyPropertyChanged, IDisposable
    {
        private Unit unit;
        private IConversion selectedConversion;
        private BaseUnitViewModel selectedBaseUnit;
        private DerivedUnitViewModel selectedDerivedUnit;
        private bool disposed;

        public ConversionsVm(Settings settings)
        {
            this.PrefixConversions = new PrefixConversionsVm(settings);
            this.PartConversions = new PartConversionsVm();
            this.Unit = settings.AllUnits.FirstOrDefault(x => x.QuantityName == "Angle"); // for designtime
            this.DeleteSelectedCommand = new RelayCommand(this.DeleteSelected);
            this.AllConversions = new CompositeCollection
            {
                new CollectionContainer { Collection = this.PrefixConversions.UsedConversions },
                new CollectionContainer { Collection = this.PartConversions.UsedConversions },
                new CollectionContainer { Collection = this.FactorConversions.Conversions },
                new CollectionContainer { Collection = this.CustomConversions.Conversions },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Unit Unit
        {
            get => this.unit;
            set
            {
                if (Equals(value, this.unit))
                {
                    return;
                }

                this.SelectedConversion = null;
                this.unit = value;
                this.PrefixConversions.SetBaseUnit(value);
                this.PartConversions.SetUnit(value);
                this.FactorConversions.SetUnit(value);
                this.CustomConversions.SetUnit(value);
                this.OnPropertyChanged();
            }
        }

        public PrefixConversionsVm PrefixConversions { get; }

        public PartConversionsVm PartConversions { get; }

        public FactorConversionsVm FactorConversions { get; } = new FactorConversionsVm();

        public CustomConversionsVm CustomConversions { get; } = new CustomConversionsVm();

        public IConversion SelectedConversion
        {
            get => this.selectedConversion;
            set
            {
                if (Equals(value, this.selectedConversion))
                {
                    return;
                }

                this.selectedConversion = value;
                this.OnPropertyChanged();
            }
        }

        public CompositeCollection AllConversions { get; }

        public ICommand DeleteSelectedCommand { get; }

        public object SelectedBaseUnit
        {
            get => this.selectedBaseUnit;
            set
            {
                var selected = value as BaseUnitViewModel;
                if (Equals(selected, this.selectedBaseUnit))
                {
                    return;
                }

                this.selectedBaseUnit = selected;
                if (selected != null && !selected.IsUnknown)
                {
                    this.Unit = selected.Unit;
                }

                this.OnPropertyChanged();
            }
        }

        public object SelectedDerivedUnit
        {
            get => this.selectedDerivedUnit;
            set
            {
                var selected = value as DerivedUnitViewModel;
                if (Equals(selected, this.selectedDerivedUnit))
                {
                    return;
                }

                this.selectedDerivedUnit = selected;
                if (selected != null && !selected.IsUnknown)
                {
                    this.Unit = selected.Unit;
                }

                this.OnPropertyChanged();
            }
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.PrefixConversions.Dispose();
            this.PartConversions.Dispose();
            this.FactorConversions.Dispose();
            this.CustomConversions.Dispose();
        }

        private static void TryRemove<T>(ObservableCollection<T> collection, IConversion item)
            where T : IConversion
        {
            ((IList)collection).Remove(item);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteSelected()
        {
            if (this.selectedConversion == null || this.unit == null)
            {
                return;
            }

            TryRemove(this.unit.FactorConversions, this.selectedConversion);
            foreach (var factorConversion in this.unit.FactorConversions)
            {
                TryRemove(factorConversion.PrefixConversions, this.selectedConversion);
            }

            TryRemove(this.unit.CustomConversions, this.selectedConversion);
            TryRemove(this.unit.PrefixConversions, this.selectedConversion);
            TryRemove(this.unit.PartConversions, this.selectedConversion);
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
    }
}
