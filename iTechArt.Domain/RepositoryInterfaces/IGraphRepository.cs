using iTechArt.Domain.ModelInterfaces;
namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGraphRepository
    {
        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for grocery table.
        /// </summary>
        public Task<IGraph> GetGroceryGraphDataAsync();

        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for Pupils table.
        /// </summary>
        public Task<IGraph> GetPupilsGraphDataAsync();

        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for Students table.
        /// </summary>
        public Task<IGraph> GetStudentsGraphDataAsync();

        /// <summary>
        /// Gets the table name, amount for both genders,and average ages for both genders for Staffs table.
        /// </summary>
        public Task<IGraph> GetMedstaffGraphDataAsync();

        /// <summary>
        /// Gets the table name, amount for both genders for Police table.
        /// </summary>
        public Task<IGraph> GetPoliceGraphDataAsync();
    }
}
