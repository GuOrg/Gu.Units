namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    /// <summary>
    /// http://physics.nist.gov/cuu/Units/prefixes.html
    /// </summary>
    public class Prefix : INotifyPropertyChanged
    {
        private string _name;
        private string _symbol;
        private int _power;
        private Prefix()
        {
        }

        public Prefix(string name, string symbol, int power)
        {
            Name = name;
            Symbol = symbol;
            Power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value == _symbol)
                {
                    return;
                }
                _symbol = value;
                OnPropertyChanged();
            }
        }

        public int Power
        {
            get { return _power; }
            set
            {
                if (value == _power)
                {
                    return;
                }
                _power = value;
                OnPropertyChanged();
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Power == 0 || string.IsNullOrEmpty(Name);
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Symbol: {1}, Power: {2}", this.Name, this.Symbol, this.Power);
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
