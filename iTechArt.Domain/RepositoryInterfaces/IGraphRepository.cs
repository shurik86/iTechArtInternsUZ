using iTechArt.Domain.ModelInterfaces;
namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGraphRepository
    {
        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for grocery table
        /// </summary>
        public Task<List<IGraph>> GetGroceryGraphData();

        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for Pupils table
        /// </summary>
        public Task<List<IGraph>> GetPupilsGraphData();

        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for Students table
        /// </summary>
        public Task<List<IGraph>> GetStudentsGraphData();

        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for Staffs table
        /// </summary>
        public Task<List<IGraph>> GetMedstaffGraphData();

        /// <summary>
        /// Gets the table name, amount for both genders for Police table
        /// </summary>
        public Task<List<IGraph>> GetPoliceGraphData();
    }
}
