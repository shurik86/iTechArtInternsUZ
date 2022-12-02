using iTechArt.Domain.Enums;

namespace iTechArt.Domain.FilterModels
{
    public interface IGroceryFilter
    {
        /// <summary>
        /// Gets or sets id of grocery.
        /// </summary>
        public long? Id { get; }

        /// <summary>
        /// Gets or sets first name of grocery employee.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets or sets last name of grocery employee.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets or sets date of birth of grocery employee.
        /// </summary>
        public int? Age { get; }

        /// <summary>
        /// Gets or sets gender of grocery employee.
        /// </summary>
        public Gender? Gender { get; }

        /// <summary>
        /// Gets or sets email of grocery employee.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets or sets job position of grocery employee.
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Gets or sets which department employee works.
        /// </summary>
        public string DepartmentRetail { get; }

        /// <summary>
        /// Gets or sets salary of grocery employee.
        /// </summary>
        public double? Salary { get; }
    }
}
