using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Students
{
    [XmlRoot(StudentsConstants.STUDENTS)]
    public class StudentXml
    {
        /// <summary>
        /// Gets or sets list of students.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.STUDENT)]
        public List<StudentDto> Students { get; set; }
    }
}
