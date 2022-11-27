using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Pupils
{
    [XmlRoot(PupilConstants.PUPILS)]
    public class PupilXml
    {
        /// <summary>
        /// Gets or sets list of pupils.
        /// </summary>
        [XmlElement(ElementName = PupilConstants.PUPIL)]
        public List<PupilDto> Pupils { get; set; }
    }
}
