namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;
    using Reactive;

    public class PartConversionVm : INotifyPropertyChanged
    {
        private readonly Unit unit;

        public PartConversionVm(Unit unit, PartConversion conversion)
        {
            this.unit = unit;
            this.Conversion = conversion;
            this.IsEditable = this.Conversion.Name != unit.Name;
            unit.PartConversions.ObservePropertyChangedSlim()
                .Subscribe(_ => this.OnPropertyChanged(nameof(this.IsUsed))); // no need for IDisposable
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PartConversion Conversion { get; }

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
                    this.unit.PartConversions.Add(this.Conversion);
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

        public bool IsEditable { get; }

        public override string ToString()
        {
            return this.Conversion.Symbol;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsMatch(PartConversion x)
        {
            if (this.Conversion.Factor != x.Factor)
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
