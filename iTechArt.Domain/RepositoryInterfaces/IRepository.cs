using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.RepositoryInterfaces
{
    /// <summary>
    /// Repository Contains Generic Methods
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Generic Get All Function for All Models.
        /// </summary>
        public Task<T[]> GetAllAsync<T>()
            where T : class;
    }
}
