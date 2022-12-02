using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;

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
