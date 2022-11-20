using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using ITechArt.Parsers.Constants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos
{
    [XmlRoot(PupilStringConstants.PUPILS)]
    public class PupilDto : IPupil
    {
        /// <summary>
        /// Gets or sets id of pupil.
        /// </summary>
        [XmlIgnore]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of pupil.
        /// </summary>
        [MaxLength(64)]
        [XmlElement(ElementName = PupilStringConstants.FIRSTNAME)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets surname of pupil.
        /// </summary>
        [MaxLength(64)]
        [XmlElement(ElementName = PupilStringConstants.LASTNAME)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets birthdate of pupil.
        /// </summary>
        [XmlElement(ElementName = PupilStringConstants.DATEOFBIRTH)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets gender of pupil.
        /// </summary>
        [XmlElement(ElementName = PupilStringConstants.GENDER)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets phone number of pupil.
        /// </summary>
        [MaxLength(64)]
        [XmlElement(ElementName = PupilStringConstants.PHONENUMBER)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets address of pupil.
        /// </summary>
        [MaxLength(64)]
        [XmlElement(ElementName = PupilStringConstants.ADDRESS)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city, where pupil lives.
        /// </summary>
        [MaxLength(64)]
        [XmlElement(ElementName = PupilStringConstants.CITY)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the name of school, where pupil study.
        /// </summary>
        [MaxLength(256)]
        [XmlElement(ElementName = PupilStringConstants.SCHOOLNAME)]
        public string SchoolName { get; set; }

        /// <summary>
        /// Gets or sets the grade of study of pupil.
        /// </summary>
        [XmlElement(ElementName = PupilStringConstants.GRADE)]
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the language of education.
        /// </summary>
        [XmlElement(ElementName = PupilStringConstants.COURSELANGUAGE)]
        public CourseLanguage CourseLanguage { get; set; }

        /// <summary>
        /// Gets or sets shift of study.
        /// </summary>
        [XmlElement(ElementName = PupilStringConstants.SHIFT)]
        public Shift Shift { get; set; }
    }
}
