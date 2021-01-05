namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Runtime.CompilerServices;
    using Gu.Reactive;
    using Newtonsoft.Json;

    public class Settings : INotifyPropertyChanged, IDisposable
    {
#pragma warning disable SA1401 // Fields must be private
        internal static Settings InnerInstance; // huge hairy hack here for T4
#pragma warning restore SA1401 // Fields must be private

        private readonly IDisposable disposable;
        private IReadOnlyList<MissingOverloads> missing;
        private bool disposed;

        public Settings(ObservableCollection<Prefix> prefixes, ObservableCollection<BaseUnit> baseUnits, ObservableCollection<DerivedUnit> derivedUnits)
        {
            if (InnerInstance != null)
            {
                throw new InvalidOperationException("This is nasty design but there can only be one read from file. Reason is resolving units and prefixes by key.");
            }

            this.Prefixes = prefixes;
            this.BaseUnits = baseUnits;
            this.DerivedUnits = derivedUnits;
            InnerInstance = this;

            // redundant call here. T4 has trouble finding rx
            this.missing = Overloads.Find(this.AllUnits);
            this.disposable = Observable.Merge(
                          this.BaseUnits.ObserveCollectionChangedSlim(signalInitial: false),
                          this.DerivedUnits.ObserveCollectionChangedSlim(signalInitial: false))
                      .Subscribe(
                          _ =>
                              {
                                  this.missing = Overloads.Find(this.AllUnits);
                                  this.OnPropertyChanged(nameof(this.Missing));
                                  this.OnPropertyChanged(nameof(this.AllUnits));
                                  this.OnPropertyChanged(nameof(this.Quantities));
                              });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static Settings Instance => InnerInstance ?? FromResource;

        public static Settings FromResource
        {
            get
            {
#pragma warning disable INPC003 // Notify when property changes.
                InnerInstance = JsonConvert.DeserializeObject<Settings>(Properties.Resources.Units, Persister.SerializerSettings);
#pragma warning restore INPC003 // Notify when property changes.
                return InnerInstance;
            }
        }

        public static string Namespace => "Gu.Units";

        public static string ProjectName => "Gu.Units";

        /// <summary>
        /// The extension for the generated files, set to txt if it does not build so you can´inspect the result
        /// cs when everything works.
        /// </summary>
        public static string Extension => "cs";

        public ObservableCollection<Prefix> Prefixes { get; }

        public ObservableCollection<BaseUnit> BaseUnits { get; }

        public ObservableCollection<DerivedUnit> DerivedUnits { get; }

        public IReadOnlyList<Unit> AllUnits => this.BaseUnits.Concat<Unit>(this.DerivedUnits).ToList();

        public IReadOnlyList<Quantity> Quantities => this.AllUnits.Select(x => x.Quantity).ToList();

        public IReadOnlyList<MissingOverloads> Missing => this.missing;

        public static Settings CreateEmpty()
        {
            return new Settings(new ObservableCollection<Prefix>(), new ObservableCollection<BaseUnit>(), new ObservableCollection<DerivedUnit>());
        }

        // Used by T4
        public Unit GetUnitByName(string name)
        {
            try
            {
                var match = this.AllUnits.SingleOrDefault(x => x.Name == name);
                if (match is null)
                {
                    throw new ArgumentOutOfRangeException($"Did not find a unit with name {name}");
                }

                return match;
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException($"Found more than one unit with name {name}", e);
            }
        }

        // Used by T4
        public Quantity GetQuantityByName(string name)
        {
            try
            {
                var match = this.Quantities.SingleOrDefault(x => x.Name == name);
                if (match is null)
                {
                    throw new ArgumentOutOfRangeException($"Did not find a unit with name {name}");
                }

                return match;
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException($"Found more than one unit with name {name}", e);
            }
        }

        public virtual void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.disposable?.Dispose();
            GC.SuppressFinalize(this);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
