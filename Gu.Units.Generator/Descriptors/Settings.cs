namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;
    using Newtonsoft.Json;
    using Reactive;

    [Serializable]
    public class Settings : INotifyPropertyChanged
    {
#pragma warning disable SA1401 // Fields must be private
        internal static Settings InnerInstance; // huge hairy hack here for T4
#pragma warning restore SA1401 // Fields must be private
        private IReadOnlyList<MissingOverloads> missing;

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

            Observable.Merge(
                          this.BaseUnits.ObserveCollectionChangedSlim(signalInitial: true),
                          this.DerivedUnits.ObserveCollectionChangedSlim(signalInitial: true))
                      .Subscribe(
                          _ =>
                              {
                                  this.missing = OverloadFinder.Find(this.AllUnits);
                                  this.OnPropertyChanged(nameof(this.Missing));
                                  this.OnPropertyChanged(nameof(this.AllUnits));
                                  this.OnPropertyChanged(nameof(this.Quantities));
                              });
        }

        private Settings()
        {
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public static Settings Instance => InnerInstance ?? FromResource;

        public static Settings FromResource
        {
            get
            {
#pragma warning disable WPF1012 // Notify when property changes.
                InnerInstance = JsonConvert.DeserializeObject<Settings>(Properties.Resources.Units, Persister.SerializerSettings);
#pragma warning restore WPF1012 // Notify when property changes.
                return InnerInstance;
            }
        }

        public static string Namespace => "Gu.Units";

        public static string ProjectName => "Gu.Units";

        /// <summary>
        /// The extension for the generated files, set to txt if it does not build so you can´inspect the reult
        /// cs when everything works
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

        public Unit GetUnitByName(string name)
        {
            try
            {
                var match = this.AllUnits.SingleOrDefault(x => x.Name == name);
                if (match == null)
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

        public Quantity GetQuantityByName(string name)
        {
            try
            {
                var match = this.Quantities.SingleOrDefault(x => x.Name == name);
                if (match == null)
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
