using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IStudentRepository
    {   
        /// <summary>
        /// Get all students from database.
        /// </summary>
        public Task<IStudent[]> GetAllAsync(int pageIndex, int pageSize, string fieldName, SortDirection sortDirection);

        /// <summary>
        /// Add student to database.
        /// </summary>
        public Task AddAsync(IStudent student);

        /// <summary>
        /// Get student by id.
        /// </summary>
        public Task<IStudent> GetByIdAsync(long id);

        /// <summary>
        /// Update student.
        /// </summary>
        public Task UpdateAsync(IStudent student);

        /// <summary>
        /// Delete student from database.
        /// </summary>
        public Task DeleteAsync(long id);

        /// </summary>
        /// Get count of students.
        /// </summary>
        public Task<long> GetCountAsync();

        /// <summary>
        /// Add student array.
        /// </summary>
        public Task AddRangeAsync(IEnumerable<IStudent> pupils);

        /// <summary>
        /// Get all students from database.
        /// </summary>
        public Task<IStudent[]> GetAllAsync();

    }
}
