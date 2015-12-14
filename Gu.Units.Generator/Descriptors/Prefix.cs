namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    /// <summary>
    /// http://physics.nist.gov/cuu/Units/prefixes.html
    /// </summary>
    [DebuggerDisplay("Prefix{Name} ({Symbol}) 1E{Power}")]
    [Serializable]
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
