using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IMedStaffRepository
    {
        /// <summary>
        /// Get all medStaff from database.
        /// </summary>
        /// <returns> Array of Repository Model Interfaces </returns>
        Task<IMedStaff[]> GetAllAsync(int pageIndex);

        /// <summary>
        /// Add medStaff to database.
        /// </summary>
        Task AddAsync(IMedStaff medStaff);

        /// <summary>
        /// Add array of medStaff.
        /// </summary>
        Task AddRangeAsync(IEnumerable<IMedStaff> medStaffs);

        /// <summary>
        /// Get medStaff by id.
        /// </summary>
        /// <returns> Resopisitory model interface </returns>
        Task<IMedStaff> GetByIdAsync(long id);

        /// <summary>
        /// Update medStaff.
        /// </summary>
        Task UpdateAsync(IMedStaff doctor);

        /// <summary>
        /// Delete doctor from database.
        /// </summary>
        Task DeleteAsync(long id);

        /// </summary>
        /// Get count of medStaff.
        /// </summary>
        public Task<int> GetCountOfDoctors();

        /// <summary>
        /// Get all medStaffs from database.
        /// </summary>
        public Task<IMedStaff[]> GetAllAsync();
    }
}
