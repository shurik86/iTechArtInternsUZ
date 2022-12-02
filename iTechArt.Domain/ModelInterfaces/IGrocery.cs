using iTechArt.Domain.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IGrocery
    {
        /// <summary>
        /// Gets Id of grocery store.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets First name of grocery employee.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets Last name of grocery employee.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets Date of birth of grocery employee.
        /// </summary>
        public DateTime Birthday { get; }

        /// <summary>
        /// Gets Gender of grocery employee.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Gets Email of grocery employee.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets Job position of grocery employee.
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Gets Which department employee works.
        /// </summary>
        public string DepartmentRetail { get; }

        /// <summary>
        /// Gets Salary of grocery employee.
        /// </summary>
        public double Salary { get; }
    }
}
