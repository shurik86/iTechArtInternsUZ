using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Pupils
{
    [XmlRoot(PupilStringConstants.PUPILS)]
    public class PupilXml
    {
        /// <summary>
        /// Gets or sets list of pupils.
        /// </summary>
        [XmlElement(ElementName = PupilStringConstants.PUPIL)]
        public List<PupilDto> Pupils { get; set; }
    }
}
