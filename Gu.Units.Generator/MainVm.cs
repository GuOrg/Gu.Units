namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Gu.Reactive;

    public sealed class MainVm : INotifyPropertyChanged, IDisposable
    {
        public static readonly MainVm Instance = new MainVm();
        private readonly Settings settings;

        private string nameSpace;
        private bool disposed;

        private MainVm()
        {
            this.settings = Settings.FromResource;
            this.nameSpace = Settings.ProjectName;
            this.BaseUnits = new ObservableCollection<BaseUnitViewModel>(this.settings.BaseUnits.Select(x => new BaseUnitViewModel(x)));
            this.BaseUnits.ObserveCollectionChangedSlim(signalInitial: false)
                .Subscribe(this.OnBaseUnitsChanged);
            this.DerivedUnits = new ObservableCollection<DerivedUnitViewModel>(this.settings.DerivedUnits.Select(x => new DerivedUnitViewModel(x)));

            this.DerivedUnits.ObserveCollectionChangedSlim(signalInitial: false)
                .Subscribe(this.OnDerivedUnitsChanged);
            this.Conversions = new ConversionsVm(this.settings);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Prefix> Prefixes => this.settings.Prefixes;

        public ObservableCollection<BaseUnitViewModel> BaseUnits { get; }

        public ObservableCollection<DerivedUnitViewModel> DerivedUnits { get; }

        public ConversionsVm Conversions { get; }

        public string NameSpace
        {
            get => this.nameSpace;
            set
            {
                if (value == this.nameSpace)
                {
                    return;
                }

                this.nameSpace = value;
                this.OnPropertyChanged();
            }
        }

        public void Save()
        {
            this.ThrowIfDisposed();
            Persister.Save(Persister.SettingsFileName);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.Conversions.Dispose();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnBaseUnitsChanged(NotifyCollectionChangedEventArgs args)
        {
            var typedArgs = args.As<BaseUnitViewModel>();
            switch (typedArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    // NOP
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.settings.BaseUnits.Remove(typedArgs.OldItems.Single().Unit);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnDerivedUnitsChanged(NotifyCollectionChangedEventArgs args)
        {
            var typedArgs = args.As<DerivedUnitViewModel>();
            switch (typedArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    // NOP
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.settings.DerivedUnits.Remove(typedArgs.OldItems.Single().Unit);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(MainVm));
            }
        }
    }
}
