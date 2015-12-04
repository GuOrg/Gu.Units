namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class ConversionsVm : INotifyPropertyChanged
    {
        private readonly Settings settings;
        private readonly ObservableCollection<PrefixConversionVm> prefixes = new ObservableCollection<PrefixConversionVm>();
        private readonly ObservableCollection<PartConversionVm[]> subParts = new ObservableCollection<PartConversionVm[]>();

        private IUnit baseUnit;
        public ConversionsVm(Settings settings)
        {
            this.settings = settings;
            BaseUnit = settings.AllUnits.FirstOrDefault(x => x.ClassName == "SquareMetres"); // for designtime
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IUnit BaseUnit
        {
            get { return this.baseUnit; }
            set
            {
                if (Equals(value, this.baseUnit))
                {
                    return;
                }

                this.baseUnit = value;
                this.prefixes.Clear();
                this.subParts.Clear();
                if (this.baseUnit == null)
                {
                    return;
                }
                foreach (var prefix in this.settings.Prefixes)
                {
                    this.prefixes.Add(new PrefixConversionVm(prefix, this.baseUnit));
                }
                var derivedUnit = this.baseUnit as DerivedUnit;
                if (derivedUnit != null)
                {
                    if (derivedUnit.Parts.Count == 1)
                    {
                        this.subParts.Add(derivedUnit.Parts.Single().Unit.Conversions.Select(x => new PartConversionVm(this.baseUnit, x)).ToArray());
                    }
                    else if (derivedUnit.Parts.Count == 2)
                    {
                        var partConversionVms = new List<PartConversionVm> { null };
                        partConversionVms.AddRange(derivedUnit.Parts[0].Unit.Conversions.Select(x => new PartConversionVm(this.baseUnit, x)));
                        this.subParts.Add(partConversionVms.ToArray());
                        foreach (var u in derivedUnit.Parts[1].Unit.Conversions)
                        {
                            partConversionVms.Clear();
                            partConversionVms.Add(new PartConversionVm(this.baseUnit, u));
                            partConversionVms.AddRange(derivedUnit.Parts[0].Unit.Conversions.Select(x => new PartConversionVm(this.baseUnit, u, x)));
                            this.subParts.Add(partConversionVms.ToArray());
                        }
                    }
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PrefixConversionVm> Prefixes => this.prefixes;

        public ObservableCollection<PartConversionVm[]> SubParts => this.subParts;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
