using iTechArt.Database.DbContexts;
using iTechArt.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Repository.Repositories
{
    /// <summary>
    /// Repository Contains Generic Methods
    /// </summary>
    public sealed class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Generic Get All Function for All Models.
        /// </summary>
        public async Task<T[]> GetAllAsync<T>() where T : class
        {
            return await _dbContext.Set<T>().ToArrayAsync();
        }
    }
}
