using AutoMapper;
using AutoMapper.QueryableExtensions;
using CsvHelper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Police;
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
    public sealed class PoliceRepository : IPoliceRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public PoliceRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add or Update Police entity to/from database.
        /// </summary>
        public async Task AddAsync(IPolice entity)
        {
            PoliceDb police = _mapper.Map<PoliceDb>(entity);
            if (entity != null)
            {
                _dbContext.Police.Add(police);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all Police data from database.
        /// </summary>
        public async Task<IPolice[]> GetAllAsync(int pageIndex, int pageSize, string fieldName, 
            SortDirection sortDirection, IPoliceFilter policeFilter)
        {
            return await _dbContext.Police.AsNoTracking()
                                          .Filtrate(policeFilter)
                                          .Sort(fieldName, sortDirection, new PoliceDBSorter())
                                          .Paginate(pageIndex, pageSize)
                                          .ProjectTo<Police>(_mapper.ConfigurationProvider)
                                          .ToArrayAsync();
        }

        /// <summary>
        /// Get Police by id.
        /// </summary>
        public async Task<IPolice> GetByIdAsync(long id)
        {
            return await _dbContext.Police.Select(entity => _mapper.Map<Police>(entity))
                                                      .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Delete Police from database.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var police = await _dbContext.Police.FirstOrDefaultAsync(c => c.Id == id);
            if (police != null)
            {
                _dbContext.Police.Remove(police);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get total count of police.
        /// </summary>
        public async Task<int> GetCountOfPolice()
        {
            return await _dbContext.Police.CountAsync();
        }


        ///// <summary>
        ///// Update entity.
        ///// </summary>
        public async Task UpdateAsync(IPolice entity)
        {
            var policeFromDb = await _dbContext.Police.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (policeFromDb != null)
            {
                _dbContext.Police.Update(_mapper.Map<PoliceDb>(entity));
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Add collection of polices to database.
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<IPolice> polices)
        {
            await _dbContext.AddRangeAsync(polices.Select(_mapper.Map<PoliceDb>));
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all Police data from database.
        /// </summary>
        public async Task<IPolice[]> GetAllAsync()
        {
            return await _dbContext.Police.Select(police => _mapper.Map<Police>(police)).ToArrayAsync();
        }
    }
}