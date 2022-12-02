using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;

namespace iTechArt.Api.Models
{
    public class PupilFilter : IPupilFilter
    {
        /// <summary>
        /// Gets id if pupil.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets name of pupil.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets surname of pupil.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets birthdate of pupil.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Gets gender of pupil.
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Gets phone number of pupil.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets address of pupil.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets a city, where pupil lives.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets name of school, where pupil study.
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// Gets grade of study of pupil.
        /// </summary>
        public int? Grade { get; set; }

        /// <summary>
        /// Gets a language of education.
        /// </summary>
        public CourseLanguage? CourseLanguage { get; set;  }

        /// <summary>
        /// Gets a shift of study.
        /// </summary>
        public Shift? Shift { get; set; }
    }
}
