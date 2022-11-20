using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.MedStaffs
{
    [XmlRoot(MedStaffConstants.MEDSTAFFS)]
    public class MedStaffXml
    {
        /// <summary>
        /// Gets or sets list of med staffs.
        /// </summary>
        [XmlElement(ElementName = MedStaffConstants.MEDSTAFF)]
        public List<MedStaffDto> MedStaffs { get; set; }
    }
}
