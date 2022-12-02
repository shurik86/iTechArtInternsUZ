using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IFacultyInfoService
    {
        /// <summary>
        /// Gets info about number of students enrolled in each faculty.
        /// </summary>
        public Task<IFacultyInfo> GetFacultyInfo();
    }
}
