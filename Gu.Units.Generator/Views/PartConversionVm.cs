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
            Conversion = conversion;
            IsEditable = Conversion.Name != unit.Name;
            unit.PartConversions.ObservePropertyChangedSlim()
                .Subscribe(_ => OnPropertyChanged(nameof(IsUsed))); // no need for IDisposable
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PartConversion Conversion { get; }

        public bool IsUsed
        {
            get
            {
                if (!IsEditable)
                {
                    return true;
                }

                return this.unit.PartConversions.Any(IsMatch);
            }
            set
            {
                if (value.Equals(IsUsed) || !IsEditable)
                {
                    return;
                }

                if (value)
                {
                    this.unit.PartConversions.Add(Conversion);
                }
                else
                {
                    var match = this.unit.PartConversions.FirstOrDefault(IsMatch);
                    if (match != null)
                    {
                        this.unit.PartConversions.Remove(match);
                    }
                }

                OnPropertyChanged();
            }
        }

        public bool IsEditable { get; }

        public override string ToString()
        {
            return Conversion.Symbol;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsMatch(PartConversion x)
        {
            if (Conversion.Factor != x.Factor)
            {
                return false;
            }

            if (Conversion.Name != x.Name)
            {
                return false;
            }

            return true;
        }
    }
}
