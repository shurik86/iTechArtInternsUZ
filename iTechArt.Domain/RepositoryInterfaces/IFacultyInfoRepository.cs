using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IFacultyInfoRepository
    {
        /// <summary>
        /// Gets info about number of students enrolled in each faculty.
        /// </summary>
        public Task<IFacultyInfo> GetFacultyInfo();
    }
}
