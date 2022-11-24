using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Groceries
{
    public sealed class GroceryDto : IGrocery
    {
        /// <summary>
        /// Gets or sets Id of grocery.
        /// </summary>
        [XmlIgnore]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets First name of grocery employee.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.FIRSTNAME)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last name of grocery employee.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.LASTNAME)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Date of birth of grocery employee.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.BIRTHDAY)]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets Gender of grocery employee.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.GENDER)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or internal sets Email of grocery employee.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.EMAIL)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Jop position of grocery employee.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.JOBTITLE)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets Which department employee works.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.DEPARTMENTRETAIL)]
        public string DepartmentRetail { get; set; }

        /// <summary>
        /// Gets or sets Salary of grocery employee.
        /// </summary>
        [XmlElement(ElementName = GroceryConstants.SALARY)]
        public double Salary { get; set; }
    }
}
