using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGroceryRepository
    {
        /// <summary>
        /// Get all groceries from database.
        /// </summary>
        public Task<IGrocery[]> GetAllAsync();

        /// <summary>
        /// Get grocery by id.
        /// </summary>
        //public Task<IGrocery> GetByIdAsync(long id);

        /// <summary>
        /// Update grocery.
        /// </summary>
        public Task UpdateAsync(IGrocery grocery);

        /// <summary>
        /// Delete grocery from database.
        /// </summary>
        public Task DeleteAsync(long id);

        /// </summary>
        /// Get count of groceries.
        /// </summary>
        public ValueTask<int> GetCountAsync();

        /// <summary>
        /// Add groceries to database.
        /// </summary>
        public Task AddGroceriesAsync(IEnumerable<IGrocery> groceries);
    }
}
