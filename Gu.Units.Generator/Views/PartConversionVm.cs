namespace Gu.Units.Generator
{
    using System;
    using System.Linq;
    using Reactive;

    public class PartConversionVm : ConversionVm
    {
        private readonly Unit unit;

        public PartConversionVm(Unit unit, PartConversion conversion)
            : base(conversion)
        {
            this.unit = unit;
            this.IsEditable = this.Conversion.Name != unit.Name;
            unit.PartConversions.ObservePropertyChangedSlim()
                .Subscribe(_ => this.OnPropertyChanged(nameof(this.IsUsed))); // no need for IDisposable
        }

        public bool IsEditable { get; }

        public bool IsUsed
        {
            get
            {
                if (!this.IsEditable)
                {
                    return true;
                }

                return this.unit.PartConversions.Any(this.IsMatch);
            }

            set
            {
                if (value.Equals(this.IsUsed) || !this.IsEditable)
                {
                    return;
                }

                if (value)
                {
                    this.unit.PartConversions.Add((PartConversion)this.Conversion);
                }
                else
                {
                    var match = this.unit.PartConversions.FirstOrDefault(this.IsMatch);
                    if (match != null)
                    {
                        this.unit.PartConversions.Remove(match);
                    }
                }

                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return this.Conversion.Symbol;
        }

        private bool IsMatch(PartConversion x)
        {
            //// ReSharper disable once CompareOfFloatsByEqualityOperator
            if (((PartConversion)this.Conversion).Factor != x.Factor)
            {
                return false;
            }

            if (this.Conversion.Name != x.Name)
            {
                return false;
            }

            return true;
        }
    }
}
