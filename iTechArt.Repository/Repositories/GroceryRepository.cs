﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using iTechArt.Repository.FilterExtensions;
using iTechArt.Repository.PaginationExtensions;
using iTechArt.Repository.SortingExtentions.Sorters;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GroceryRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all entities from database.
        /// </summary>
        public async Task<IGrocery[]> GetAllAsync(int pageIndex, int pageSize, string fieldName, 
            SortDirection sortDirection, IGroceryFilter groceryFilter)
        {
            return await _dbContext.Groceries.AsNoTracking()
                                             .Filtrate(groceryFilter)
                                             .Sort(fieldName, sortDirection, new GroceryDBSorter())
                                             .Paginate(pageIndex, pageSize)
                                             .ProjectTo<Grocery>(_mapper.ConfigurationProvider)
                                             .ToArrayAsync();
        }

        /// <summary>
        /// Get grocery by id.
        /// </summary>
        public async Task<IGrocery> GetByIdAsync(long id)
        {
            return await _dbContext.Groceries.Select(entity => _mapper.Map<Grocery>(entity))
                                                      .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Update grocery.
        /// </summary>
        public async Task UpdateAsync(IGrocery grocery)
        {
            _dbContext.Set<GroceryDb>().Update(_mapper.Map<GroceryDb>(grocery));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete grocery from database.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var grocery = await _dbContext.Groceries.FirstOrDefaultAsync(c => c.Id == id);
            if (grocery != null)
            {
                _dbContext.Groceries.Remove(grocery);
                await _dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Add grocery items to database.
        /// </summary>
        public async Task AddGroceriesAsync(IEnumerable<IGrocery> groceries)
        {
            try
            {
                await _dbContext.AddRangeAsync(groceries.Select(_mapper.Map<GroceryDb>));
                await _dbContext.SaveChangesAsync();
          
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get total count of groceries.
        /// </summary>
        public async ValueTask<long> GetCountAsync()
        {
            return await _dbContext.Groceries.CountAsync();
        }

        /// <summary>
        /// Get all entities from database.
        /// </summary>
        public async Task<IGrocery[]> GetAllAsync()
        {
            return await _dbContext.Groceries.Select(groceries => _mapper.Map<Grocery>(groceries)).ToArrayAsync();
        }
    }
}