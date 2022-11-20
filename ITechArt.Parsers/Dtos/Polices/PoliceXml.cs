using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Polices
{
    [XmlRoot(PoliceConstants.POLICES)]
    public class PoliceXml
    {
        /// <summary>
        /// Gets or sets list of polices.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.POLICE)]
        public List<PoliceDto> Polices { get; set; }
    }
}
