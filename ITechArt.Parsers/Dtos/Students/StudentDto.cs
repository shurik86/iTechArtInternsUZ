using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Students
{
    [XmlRoot(StudentsConstants.STUDENTS)]
    public class StudentDto : IStudent
    {
        /// <summary>
        /// Gets or sets id of student.
        /// </summary>
        [XmlIgnore]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets name of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.FIRSTNAME)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.LASTNAME)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets email of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.EMAIL)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.PASSWORD)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets string value majority, field of study.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.MAJORITY)]
        public string Majority { get; set; }

        /// <summary>
        /// Gets or sets gender of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.GENDER)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets birth date of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.DATEOFBIRTH)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets name of university of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.UNIVERSITY)]
        public string University { get; set; }

        /// <summary>
        /// Gets or sets name of university of student.
        /// </summary>
        [XmlElement(ElementName = StudentsConstants.FACULTY)]
        public Faculty Faculty { get; set; }
    }
}
