namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Gu.State;

    public abstract class UnitViewModel : INotifyPropertyChanged
    {
        protected static readonly PropertiesSettings ChangeTrackerSettings = CreateChangeTrackerSettings();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static PropertiesSettings CreateChangeTrackerSettings()
        {
            var settings = PropertiesSettings.Build()
                                             .AddImmutableType<UnitParts>()
                                             .AddImmutableType<OperatorOverload>()
                                             .AddImmutableType<IEnumerable<IConversion>>()
                                             .CreateSettings();
            return settings;
        }
    }
}