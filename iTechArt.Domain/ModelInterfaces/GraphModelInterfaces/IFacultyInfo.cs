using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.ModelInterfaces.GraphModelInterfaces
{
    public interface IFacultyInfo
    {
        /// <summary>
        /// Gets and number of students in economics faculty.
        /// </summary>
        public int Economics { get; }

        /// <summary>
        /// Gets and number of students in law faculty.
        /// </summary>
        public int Law { get; }

        /// <summary>
        /// Gets and number of students in medicine faculty.
        /// </summary>
        public int Medicine { get; }

        /// <summary>
        /// Gets and number of students in psychology faculty.
        /// </summary>
        public int Psychology { get; }

        /// <summary>
        /// Gets and number of students in engineering faculty.
        /// </summary>
        public int Engineering { get; }

        /// <summary>
        /// Gets and number of students in science faculty.
        /// </summary>
        public int Science { get; }
    }
}
