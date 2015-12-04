namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    using Annotations;
    using WpfStuff;

    [TypeConverter(typeof(TypeMetaDataConverter))]
    public class TypeMetaData : MarshalByRefObject, INotifyPropertyChanged
    {
        private string className;

        protected TypeMetaData()
        {
        }
        
        public TypeMetaData(string className)
        {
            this.className = className;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ClassName
        {
            get { return this.className; }
            set
            {
                if (value == this.className)
                {
                    return;
                }
                this.className = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ParameterName));
            }
        }

        [XmlIgnore]
        public string ParameterName
        {
            get
            {
                if (string.IsNullOrEmpty(ClassName))
                {
                    return "### ERROR string.IsNullOrEmpty(TypeMetaData.Type)";
                }
                return Char.ToLower(ClassName[0]) + ClassName.Substring(1);
            }
        }

        public override string ToString()
        {
            return ClassName;
        }
       
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}