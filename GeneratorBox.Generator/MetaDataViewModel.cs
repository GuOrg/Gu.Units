namespace GeneratorBox.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using GeneratorBox.Generator.Annotations;

    public class MetaDataViewModel : INotifyPropertyChanged
    {
        private bool _isSiUnit;

        public MetaDataViewModel()
            : this(new ValueMetaData(new UnitMetaData("","","",0,""), "", ""), new UnitMetaData("", "", "", 0, ""))
        {
        }

        public MetaDataViewModel(ValueMetaData valueMetaData, UnitMetaData unitMetaData)
        {
            this.UnitMetaData = unitMetaData;
            this.UnitMetaData.ValueType = valueMetaData.ClassName;
            this.ValueMetaData = valueMetaData;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Namespace
        {
            get
            {
                return this.ValueMetaData.Namespace;
            }
            set
            {
                if (value == this.ValueMetaData.Namespace)
                {
                    return;
                }
                this.ValueMetaData.Namespace = value;
                this.OnPropertyChanged();
            }
        }

        public string ValueTypeName
        {
            get
            {
                return this.ValueMetaData.ClassName.ClassName;
            }
            set
            {
                if (value == this.ValueMetaData.ClassName.ClassName)
                {
                    return;
                }
                this.ValueMetaData.ClassName.ClassName = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsSiUnit
        {
            get
            {
                return this._isSiUnit;
            }
            set
            {
                if (value.Equals(this._isSiUnit))
                {
                    return;
                }
                this._isSiUnit = value;
                this.OnPropertyChanged();
            }
        }

        public string UnitTypeName
        {
            get
            {
                return this.UnitMetaData.ClassName;
            }
            set
            {
                if (value == UnitMetaData.ClassName)
                {
                    return;
                }
                UnitMetaData.ClassName = value;
                this.OnPropertyChanged();
            }
        }

        public string UnitName
        {
            get
            {
                return this.UnitMetaData.UnitName;
            }
            set
            {
                if (value == UnitMetaData.UnitName)
                {
                    return;
                }
                UnitMetaData.UnitName = value;
                this.OnPropertyChanged();
            }
        }

        internal ValueMetaData ValueMetaData { get; set; }

        internal UnitMetaData UnitMetaData { get; set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return string.Format("Namespace: {0}, ValueTypeName: {1}, IsSiUnit: {2}, UnitTypeName: {3}, UnitName: {4}, ValueMetaData: {5}, UnitMetaData: {6}", this.Namespace, this.ValueTypeName, this.IsSiUnit, this.UnitTypeName, this.UnitName, this.ValueMetaData, this.UnitMetaData);
        }
    }
}