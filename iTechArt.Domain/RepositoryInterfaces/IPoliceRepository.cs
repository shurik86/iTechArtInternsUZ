﻿using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;
using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPoliceRepository
    {
        /// <summary>
        /// Get all polices from database.
        /// </summary>
        public Task<IPolice[]> GetAllAsync(int pageIndex, int pageSize, string fieldName, SortDirection sortDirection, IPoliceFilter policeFilter);

        /// <summary>
        /// Add police to database.
        /// </summary>
        public Task AddAsync(IPolice police);

        /// <summary>
        /// Get police by id.
        /// </summary>
        public Task<IPolice> GetByIdAsync(long id);

        /// <summary>
        /// Delete police from database.
        /// </summary>
        public Task DeleteAsync(long id);

        /// </summary>
        /// Get count of polices.
        /// </summary>
        public Task<int> GetCountOfPolice();


        /// <summary>
        /// Updates entity in the database.
        /// </summary>
        public Task UpdateAsync(IPolice police);

        /// <summary>
        /// Adds collection of entities to the database.
        /// </summary>
        public Task AddRangeAsync(IEnumerable<IPolice> polices);

        /// <summary>
        /// Get all Police data from database.
        /// </summary>
        public Task<IPolice[]> GetAllAsync();
    }
}