namespace VaporStore.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    using Data.Models;

    [XmlType(nameof(Purchase))]
    public class ExportPurchaseDto
    {
        [XmlElement(nameof(Purchase.Card))]
        public string Card { get; set; }

        [XmlElement(nameof(Purchase.Card.Cvc))]
        public string Cvc { get; set; }

        [XmlElement(nameof(Purchase.Date))]
        public string Date { get; set; }

        [XmlElement(nameof(Purchase.Game))]
        public ExportGameDto Game { get; set; }
    }
}
