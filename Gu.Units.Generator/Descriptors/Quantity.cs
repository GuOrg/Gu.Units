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
            Unit = unit;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Unit Unit { get; }

        public string Name => Unit.QuantityName;

        public string UnitName => Unit.ClassName;

        public string ParameterName => Name.ToParameterName();

        public ObservableCollection<OperatorOverload> OperatorOverloads { get; } = new ObservableCollection<OperatorOverload>();

        public InverseOverload Inverse
        {
            get { return this.inverse; }
            internal set
            {
                if (Equals(value, this.inverse))
                    return;
                this.inverse = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
