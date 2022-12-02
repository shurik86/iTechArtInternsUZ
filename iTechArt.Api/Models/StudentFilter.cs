using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;

namespace iTechArt.Api.Models
{
    public class StudentFilter : IStudentFilter
    {
        /// <summary>
        /// Gets or sets id of student.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets first name of student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets email of student.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password of student.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets string value majority, field of study.
        /// </summary>
        public string Majority { get; set; }

        /// <summary>
        /// Gets or sets gender of student.
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Gets or sets age of student.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets name of university of student.
        /// </summary>
        public string University { get; set; }

        /// <summary>
        /// Gets or sets faculty of student.
        /// </summary>
        public Faculty? Faculty { get; set; }
    }
}
