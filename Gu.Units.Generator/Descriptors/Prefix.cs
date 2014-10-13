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
        private int _factor;
        public Prefix()
        {
        }

        public Prefix(string name, string symbol, int factor)
        {
            Name = name;
            Symbol = symbol;
            Factor = factor;
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

        public int Factor
        {
            get { return _factor; }
            set
            {
                if (value == _factor)
                {
                    return;
                }
                _factor = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Symbol: {1}, Factor: {2}", this.Name, this.Symbol, this.Factor);
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
