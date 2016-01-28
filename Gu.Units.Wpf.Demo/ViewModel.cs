namespace Gu.Units.Wpf.Demo
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    public class ViewModel : INotifyPropertyChanged
    {
        private Length length = Length.FromMillimetres(1234.567);
        private Speed speed = Speed.FromMetresPerSecond(1.2);
        private Pressure pressure = Pressure.FromMegapascals(1.23);

        public static readonly ViewModel Instance = new ViewModel();

        private ViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Length Length
        {
            get { return this.length; }
            set
            {
                if (value.Equals(this.length))
                    return;
                this.length = value;
                OnPropertyChanged();
            }
        }

        public Speed Speed
        {
            get { return this.speed; }
            set
            {
                if (value.Equals(this.speed))
                    return;
                this.speed = value;
                OnPropertyChanged();
            }
        }

        public Pressure Pressure
        {
            get { return this.pressure; }
            set
            {
                if (value.Equals(this.pressure))
                    return;
                this.pressure = value;
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