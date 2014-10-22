namespace Gu.Units.Generator
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public interface IUnit : INotifyPropertyChanged
    {
        string Symbol { get; set; }
        string ClassName { get; set; }
        string ParameterName { get; }
        string QuantityName { get; set; }
        Quantity Quantity { get; set; }
        bool IsEmpty { get; }
        string UiName { get; }
        ObservableCollection<Conversion> Conversions { get; }
        bool AnyOffsetConversion { get; }
        bool IsSymbolNameValid { get; }
        Settings Settings { get; set; }
    }
}