using iTechArt.Domain.Enums;

namespace iTechArt.Domain.FilterModels
{
    public interface IGroceryFilter
    {
        /// <summary>
        /// Gets id of grocery.
        /// </summary>
        public long? Id { get; }

        /// <summary>
        /// Gets first name of grocery employee.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets last name of grocery employee.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets date of birth of grocery employee.
        /// </summary>
        public int? Age { get; }

        /// <summary>
        /// Gets gender of grocery employee.
        /// </summary>
        public Gender? Gender { get; }

        /// <summary>
        /// Gets email of grocery employee.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets job position of grocery employee.
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Gets which department employee works.
        /// </summary>
        public string DepartmentRetail { get; }

        /// <summary>
        /// Gets salary of grocery employee.
        /// </summary>
        public double? Salary { get; }
    }
}
