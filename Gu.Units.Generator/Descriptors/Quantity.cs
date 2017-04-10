namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    [DebuggerDisplay("{Name}")]
    [Serializable]
    public class Quantity : MarshalByRefObject, INotifyPropertyChanged
    {
        private InverseOverload inverse;

        public Quantity(Unit unit)
        {
            this.Unit = unit;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Unit Unit { get; }

        public string Name => this.Unit.QuantityName;

        public string UnitName => this.Unit.ClassName;

        public string ParameterName => this.Name.ToParameterName();

        public ObservableCollection<OperatorOverload> OperatorOverloads { get; } = new ObservableCollection<OperatorOverload>();

        public InverseOverload Inverse
        {
            get => this.inverse;
            internal set
            {
                if (Equals(value, this.inverse))
                    return;
                this.inverse = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
