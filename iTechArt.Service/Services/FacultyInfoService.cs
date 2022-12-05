using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

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
        public async Task<IFacultyInfo> GetFacultyInfoAsync()
        {
            return await _facultyInfoRepository.GetFacultyInfoAsync();
        }
    }
}
