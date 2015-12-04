namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml.Serialization;
    using Annotations;
    using WpfStuff;

    [TypeConverter(typeof(StringToFormulaConverter))]
    public class ConversionFormula : INotifyPropertyChanged
    {
        private readonly IUnit baseUnit;
        private ConversionFormula()
        {
        }

        public ConversionFormula(IUnit baseUnit)
        {
            this.baseUnit = baseUnit;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double ConversionFactor { get; set; }

        public double Offset { get; set; }

        [XmlIgnore]
        public string ToSi
        {
            get
            {
                var builder = new StringBuilder();
                if (ConversionFactor != 1)
                {
                    builder.Append(ConversionFactor.ToString(CultureInfo.InvariantCulture) + "*");
                }
                builder.Append(this.baseUnit != null ? this.baseUnit.Quantity.Unit.ClassName : "x");
                if (Offset != 0)
                {
                    if (Offset > 0)
                    {
                        builder.AppendFormat("+{0}", Offset.ToString(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        builder.AppendFormat(Offset.ToString(CultureInfo.InvariantCulture));
                    }
                }
                return builder.ToString();
            }
        }

        [XmlIgnore]
        public string FromSi
        {
            get
            {
                var builder = new StringBuilder();

                builder.Append(this.baseUnit != null ? this.baseUnit.Quantity.Unit.ClassName : "x");
                if (ConversionFactor != 1)
                {
                    builder.Append( "/"+ConversionFactor.ToString(CultureInfo.InvariantCulture));
                }
                if (Offset != 0)
                {
                    if (Offset < 0)
                    {
                        builder.AppendFormat("+{0}",(-1* Offset).ToString(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        builder.AppendFormat((-1*Offset).ToString(CultureInfo.InvariantCulture));
                    }
                }
                return builder.ToString();
            }
        }

        [XmlIgnore]
        public bool CanRountrip
        {
            get
            {
                throw new NotImplementedException("message");
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}