using iTechArt.Domain.Enums;

namespace iTechArt.Domain.FilterModels
{
    public interface IStudentFilter
    {
        /// <summary>
        /// Gets id of student.
        /// </summary>
        public long? Id { get; }

        /// <summary>
        /// Gets first name of student.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets last name of student.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets or sets email of student.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets password of student.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Gets string value majority, field of study.
        /// </summary>
        public string Majority { get; }

        /// <summary>
        /// Gets gender of student.
        /// </summary>
        public Gender? Gender { get; }

        /// <summary>
        /// Gets age of student.
        /// </summary>
        public int? Age { get; }

        /// <summary>
        /// Gets name of university of student.
        /// </summary>
        public string University { get; }

        /// <summary>
        /// Gets faculty of student.
        /// </summary>
        public Faculty? Faculty { get; }
    }
}
