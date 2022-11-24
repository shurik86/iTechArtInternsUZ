using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Airports
{
    [XmlRoot(AirportConstants.AIPORTS)]
    public class AirportXml
    {
        /// <summary>
        /// Gets or set list of airports.
        /// </summary>
        [XmlElement(ElementName = AirportConstants.AIPRORT)]
        public List<AirportDTO> Airports { get; set; }
    }
}
