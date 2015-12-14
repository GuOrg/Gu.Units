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
        internal static Settings InnerInstance; // huge hairy hack here for T4
        private IReadOnlyList<MissingOverloads> missing;

        public static Settings Instance => InnerInstance ?? FromResource;

        public static Settings FromResource
        {
            get
            {
                InnerInstance = JsonConvert.DeserializeObject<Settings>(Properties.Resources.Units, Persister.SerializerSettings);
                return InnerInstance;
            }
        }

        private Settings()
        {
        }

        public Settings(ObservableCollection<Prefix> prefixes, ObservableCollection<BaseUnit> baseUnits, ObservableCollection<DerivedUnit> derivedUnits)
        {
            if (InnerInstance != null)
            {
                throw new InvalidOperationException("This is nasty design but there can only be one read from file. Reason is resolving units and prefixes by key.");
            }

            Prefixes = prefixes;
            BaseUnits = baseUnits;
            DerivedUnits = derivedUnits;
            InnerInstance = this;

            Observable.Merge(BaseUnits.ObserveCollectionChangedSlim(true),
                             DerivedUnits.ObserveCollectionChangedSlim(true))
                .Subscribe(_ =>
                {
                    this.missing = OverloadFinder.Find(AllUnits);
                    OnPropertyChanged(nameof(Missing));
                    OnPropertyChanged(nameof(AllUnits));
                    OnPropertyChanged(nameof(Quantities));
                });
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public IReadOnlyList<Unit> AllUnits => BaseUnits.Concat<Unit>(DerivedUnits).ToList();

        public IReadOnlyList<Quantity> Quantities => AllUnits.Select(x => x.Quantity).ToList();

        public IReadOnlyList<MissingOverloads> Missing => this.missing; 

        public static Settings CreateEmpty()
        {
            return new Settings(new ObservableCollection<Prefix>(), new ObservableCollection<BaseUnit>(), new ObservableCollection<DerivedUnit>());
        }

        public Unit GetUnitByName(string name)
        {
            try
            {
                var match = AllUnits.SingleOrDefault(x => x.Name == name);
                if (match == null)
                {
                    throw new ArgumentOutOfRangeException($"Did not find a unit with name {name}");
                }
                return match;
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException($"Found more than one unit with name {name}");
            }
        }

        public Quantity GetQuantityByName(string name)
        {
            try
            {
                var match = Quantities.SingleOrDefault(x => x.Name == name);
                if (match == null)
                {
                    throw new ArgumentOutOfRangeException($"Did not find a unit with name {name}");
                }
                return match;
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException($"Found more than one unit with name {name}");
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
