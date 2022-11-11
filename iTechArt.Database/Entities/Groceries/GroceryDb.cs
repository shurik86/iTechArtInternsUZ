using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Database.Entities.Groceries
{
    public sealed class GroceryDb
    {
        /// <summary>
        /// Get or sets ID of grocery employee.
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// Get or sets Fist Name of grocery employee.
        /// </summary>
        [MaxLength(32)]
        [Column("first_Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Get or sets Surname of grocery employee.
        /// </summary>
        [MaxLength(32)]
        [Column("last_Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Get or sets Birthdate of grocery employee.
        /// </summary>
        [Column("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Get or sets Gender of grocery employee.
        /// </summary>
        [Column("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Get or sets Email of grocery employee.
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Get or sets Job position of grocery employee.
        /// </summary>
        [Column("job_title")]
        public string Jobtitle { get; set; }

        /// <summary>
        /// Get or sets Current department of grocery employee.
        /// </summary>
        [Column("department_retail")]
        public string Departmentretail { get; set; }

        /// <summary>
        /// Get or sets Salary of each grocery employee.
        /// </summary>
        [Column("salary")]
        public double Salary { get; set; }
    }
}
