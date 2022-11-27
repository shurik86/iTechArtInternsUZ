using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Polices
{
    public sealed class PoliceDto : IPolice
    {
        /// <summary>
        /// Gets and sets police officer's id.
        /// </summary>
        [XmlIgnore]
        public long Id { get; set; }

        /// <summary>
        /// Gets and sets police officer's firstname.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets police officer's lastname.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.SURNAME)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets and sets police officer's email address.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.EMAIL)]
        public string Email { get; set; }

        /// <summary>
        /// Gets and sets police officer's gender.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.GENDER)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets and sets police officer's address.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.ADDRESS)]
        public string Address { get; set; }

        /// <summary>
        /// Gets and sets police officer's job title.
        /// </summary> 
        [XmlElement(ElementName = PoliceConstants.JOBTITLE)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets and sets police officer's salary in us dollars with 2 double precision.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.SALARY)]
        public double Salary { get; set; }

        /// <summary>
        /// Gets and sets police officer's birthdate.
        /// </summary>
        [XmlElement(ElementName = PoliceConstants.BIRTHDATE)]
        public DateTime BirthDate { get; set; }
    }
}
