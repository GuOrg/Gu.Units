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
        private string _className;
        private string _ns;

        protected TypeMetaData()
        {
        }
        
        public TypeMetaData(string @namespace,string className)
        {
            _ns = @namespace;
            _className = className;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string Namespace
        {
            get { return _ns; }
            set
            {
                if (value == _ns)
                {
                    return;
                }
                _ns = value;
                OnPropertyChanged();
            }
        }

        public string Ns { get; set; }

        public string ClassName
        {
            get { return _className; }
            set
            {
                if (value == _className)
                {
                    return;
                }
                _className = value;
                OnPropertyChanged();
                OnPropertyChanged("ParameterName");
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
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}