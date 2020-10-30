namespace Gu.Units.Wpf.Demo
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public sealed class ViewModel : INotifyPropertyChanged
    {
        public static readonly ViewModel Instance = new ViewModel();

        private Length length = Length.FromMillimetres(1234.567);
        private Speed speed = Speed.FromMetresPerSecond(1.2);
        private Pressure pressure = Pressure.FromMegapascals(1.23);
        private Length? nullableLength = Length.FromMillimetres(1234.567);
        private object objectLength = Length.FromMillimetres(1234.567);

        private ViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Length Length
        {
            get => this.length;
            set
            {
                if (value.Equals(this.length))
                {
                    return;
                }

                this.length = value;
                this.OnPropertyChanged();
            }
        }

        public Length? NullableLength
        {
            get => this.nullableLength;
            set
            {
                if (value == this.nullableLength)
                {
                    return;
                }

                this.nullableLength = value;
                this.OnPropertyChanged();
            }
        }

        public object ObjectLength
        {
            get => this.objectLength;
            set
            {
                if (Equals(value, this.objectLength))
                {
                    return;
                }

                this.objectLength = value;
                this.OnPropertyChanged();
            }
        }

        public Speed Speed
        {
            get => this.speed;
            set
            {
                if (value.Equals(this.speed))
                {
                    return;
                }

                this.speed = value;
                this.OnPropertyChanged();
            }
        }

        public Pressure Pressure
        {
            get => this.pressure;
            set
            {
                if (value.Equals(this.pressure))
                {
                    return;
                }

                this.pressure = value;
                this.OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}