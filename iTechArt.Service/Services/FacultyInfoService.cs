using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Services
{
    public sealed class FacultyInfoService : IFacultyInfoService
    {
        private readonly IFacultyInfoRepository _facultyInfoRepository;

        public FacultyInfoService(IFacultyInfoRepository facultyInfoRepository)
        {
            _facultyInfoRepository = facultyInfoRepository;
        }

        /// <summary>
        /// Gets info about number of students enrolled in each faculty.
        /// </summary>
        public async Task<IFacultyInfo> GetFacultyInfo()
        {
            return await _facultyInfoRepository.GetFacultyInfo();
        }
    }
}
