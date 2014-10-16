namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public interface IUnit
    {
        string Symbol { get; set; }
        string ClassName { get; set; }
        string Namespace { get; }
        string ParameterName { get; }
        string QuantityName { get; set; }
        Quantity Quantity { get; set; }
        bool IsEmpty { get; }
        string UiName { get; }
        ObservableCollection<SubUnit> SubUnits { get; }
    }
}