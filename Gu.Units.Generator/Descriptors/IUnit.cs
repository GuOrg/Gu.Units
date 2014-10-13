namespace Gu.Units.Generator
{
    using System.Xml.Serialization;

    public interface IUnit
    {
        string Symbol { get; set; }
        string ClassName { get; set; }
        string QuantityName { get; set; }
        Quantity Quantity { get; set; }
        bool IsEmpty { get; }
        string UiName { get; }
    }
}