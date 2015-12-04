namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class PartConversionsVm : INotifyPropertyChanged
    {
        private readonly ObservableCollection<PartConversionVm[]> subParts = new ObservableCollection<PartConversionVm[]>();
        private readonly Settings settings;
        private IUnit baseUnit;

        public PartConversionsVm(Settings settings)
        {
            this.settings = settings;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PartConversionVm[]> SubParts => this.subParts;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetBaseUnit(IUnit value)
        {
            this.baseUnit = value;
            this.subParts.Clear();

            var derivedUnit = this.baseUnit as DerivedUnit;
            if (derivedUnit == null)
            {
                return;
            }

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
    }
}
