using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Groceries
{
    [XmlRoot(GroceryConstants.GROCERIES)]
    public class GroceryXml
    {
        /// <summary>
        /// Gets or sets list of groceries.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.GROCERY)]
        public List<GroceryDto> Groceries { get; set; }
    }
}
