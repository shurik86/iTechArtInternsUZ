using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;

namespace iTechArt.Repository.BusinessModels.GraphModels
{
    internal sealed class FacultyInfo : IFacultyInfo
    {
        /// <summary>
        /// Gets and sets number of students in economics faculty.
        /// </summary>
        public int Economics { get; internal set; }

        /// <summary>
        /// Gets and sets number of students in law faculty.
        /// </summary>
        public int Law { get; internal set; }

        /// <summary>
        /// Gets and sets number of students in medicine faculty.
        /// </summary>
        public int Medicine { get; internal set; }

        /// <summary>
        /// Gets and sets number of students in psychology faculty.
        /// </summary>
        public int Psychology { get; internal set; }

        /// <summary>
        /// Gets and sets number of students in engineering faculty.
        /// </summary>
        public int Engineering { get; internal set; }

        /// <summary>
        /// Gets and sets number of students in science faculty.
        /// </summary>
        public int Science { get; internal set; }
    }
}
