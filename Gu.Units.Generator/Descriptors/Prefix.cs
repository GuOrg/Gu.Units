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
        private string name;
        private string symbol;
        private int power;

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
            get { return this.name; }
            set
            {
                if (value == this.name)
                {
                    return;
                }
                this.name = value;
                OnPropertyChanged();
            }
        }

        public string Symbol
        {
            get { return this.symbol; }
            set
            {
                if (value == this.symbol)
                {
                    return;
                }
                this.symbol = value;
                OnPropertyChanged();
            }
        }

        public int Power
        {
            get { return this.power; }
            set
            {
                if (value == this.power)
                {
                    return;
                }
                this.power = value;
                OnPropertyChanged();
            }
        }

        public bool IsEmpty => Power == 0 || string.IsNullOrEmpty(Name);

        public override string ToString()
        {
            return $"Name: {this.Name}, Symbol: {this.Symbol}, Power: {this.Power}";
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
