using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace ITechArt.Parsers.Dtos.Groceries
{
    public sealed class GroceryDto : IGrocery
    {
        /// <summary>
        /// Gets or sets Id of grocery.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets First name of grocery employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last name of grocery employee.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Date of birth of grocery employee.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets Gender of grocery employee.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or internal sets Email of grocery employee.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Jop position of grocery employee.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets Which department employee works.
        /// </summary>
        public string DepartmentRetail { get; set; }

        /// <summary>
        /// Gets or sets Salary of grocery employee.
        /// </summary>
        public double Salary { get; set; }
    }
}
