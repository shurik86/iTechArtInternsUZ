using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;

namespace iTechArt.Api.Models
{
    public class GroceryFilter : IGroceryFilter
    {
        /// <summary>
        /// Gets or sets id of grocery.
        /// </summary>
        public long? Id { get; set; }
        
        /// <summary>
        /// Gets or sets First name of grocery employee.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Gets or sets Last name of grocery employee.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets date of birth of grocery employee.
        /// </summary>
        public int? Age { get; set; }
        
        /// <summary>
        /// Gets or sets gender of grocery employee.
        /// </summary>
        public Gender? Gender { get; set; }
        
        /// <summary>
        /// Gets or sets email of grocery employee.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Gets or sets job position of grocery employee.
        /// </summary>
        public string JobTitle { get; set; }
        
        /// <summary>
        /// Gets or sets which department employee works.
        /// </summary>
        public string DepartmentRetail { get; set; }
        
        /// <summary>
        /// Gets or sets salary of grocery employee.
        /// </summary>
        public double? Salary { get; set; }
    }
}
