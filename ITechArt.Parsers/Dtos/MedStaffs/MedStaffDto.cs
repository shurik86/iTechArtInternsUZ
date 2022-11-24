using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using ITechArt.Parsers.Constants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.MedStaffs
{
    public sealed class MedStaffDto : IMedStaff
    {
        /// <summary>
        /// Gets && internal sets Unical Id of a medStaff.
        /// </summary>
        [XmlIgnore]
        public long Id { get; set; }

        /// <summary>
        /// Gets && internal sets Firstname of a medStaff
        /// </summary>
        [MaxLength(24)]
        [XmlElement(ElementName = MedStaffConstants.FIRSTNAME)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets && internal sets Lastname of a medStaff.
        /// </summary>
        [MaxLength(24)]
        [XmlElement(ElementName = MedStaffConstants.LASTNAME)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets && internal sets Gender of a medStaff.
        /// </summary>
        [XmlElement(ElementName = MedStaffConstants.GENDER)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets && internal sets Email address of a medStaff.
        /// </summary>
        [MaxLength(32)]
        [XmlElement(ElementName = MedStaffConstants.EMAIL)]
        public string Email { get; set; }

        /// <summary>
        /// Gets && internal sets Phone number of a medStaff.
        /// string
        /// </summary>
        [MaxLength(16)]
        [XmlElement(ElementName = MedStaffConstants.PHONENUMBER)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets && internal sets Date of birth of a medStaff.
        /// </summary>
        [XmlElement(ElementName = MedStaffConstants.DATEOFBIRTH)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets && internal sets Address of a medStaff.
        /// </summary>
        [MaxLength(24)]
        [XmlElement(ElementName = MedStaffConstants.ADDRESS)]
        public string Address { get; set; }

        /// <summary>
        /// Gets && internal sets Monthly salary of a medStaff.
        /// </summary>
        [XmlElement(ElementName = MedStaffConstants.SALARY)]
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets && internal sets Name of a hospital where the medStaff works.
        /// </summary>
        [MaxLength(24)]
        [XmlElement(ElementName = MedStaffConstants.HOSPITALNAME)]
        public string HospitalName { get; set; }

        /// <summary>
        /// Gets && internal sets Postal code of a city where the medStaff works.
        /// </summary>
        [MaxLength(16)]
        [XmlElement(ElementName = MedStaffConstants.POSTALCODE)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets && internal sets Work shift of a medStaff.
        /// </summary>
        [XmlElement(ElementName = MedStaffConstants.SHIFT)]
        public Shift Shift { get; set; }
    }
}
