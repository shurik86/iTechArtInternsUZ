﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
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
    public sealed class MedStaffRepository : IMedStaffRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public MedStaffRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add medStaff to database.
        /// </summary>  
        public async Task AddAsync(IMedStaff medStaff)
        {
            var mappedMedStaff = _mapper.Map<MedStaffDb>(medStaff);

            await _dbContext.Staffs.AddAsync(mappedMedStaff);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Add collection of medStaffs to database.
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<IMedStaff> medStaffs)
        {
            await _dbContext.AddRangeAsync(medStaffs.Select(_mapper.Map<MedStaffDb>));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all medStaffs from database.
        /// </summary>
        public async Task<IMedStaff[]> GetAllAsync(int pageIndex, int pageSize, string fieldName, 
            SortDirection sortDirection, IMedStaffFilter medStaffFilter)
        {
            return await _dbContext.Staffs.AsNoTracking()
                                   .Filtrate(medStaffFilter)
                                   .Sort(fieldName, sortDirection, new MedStaffDBSorter())
                                   .Paginate(pageIndex, pageSize)
                                   .ProjectTo<MedStaff>(_mapper.ConfigurationProvider)
                                   .ToArrayAsync();
        }

        /// <summary>
        /// Get medStaff by id.
        /// </summary>
        public async Task<IMedStaff> GetByIdAsync(long id)
        {
            var medStaff = await _dbContext.Staffs.FirstOrDefaultAsync(d => d.Id == id);

            if (medStaff is null)
                return null;

            return _mapper.Map<MedStaff>(medStaff);
        }

        /// <summary>
        /// Update medStaff.
        /// </summary>
        public async Task UpdateAsync(IMedStaff doctor)
        {
            var mappedMedStaff = _mapper.Map<MedStaffDb>(doctor);

            _dbContext.Staffs.Update(mappedMedStaff);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete medStaff from database.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var medStaff = await _dbContext.Staffs.FirstOrDefaultAsync(d => d.Id == id);

            if(medStaff is null)
                return;

            _dbContext.Staffs.Remove(_mapper.Map<MedStaffDb>(medStaff));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of medStaff.
        /// </summary>
        public async Task<int> GetCountOfDoctors()
        {
            return await _dbContext.Staffs.CountAsync();
        }

        /// <summary>
        /// Get all medStaffs from database.
        /// </summary>
        public async Task<IMedStaff[]> GetAllAsync()
        {
            return await _dbContext.Staffs.Select(c => _mapper.Map<MedStaff>(c)).ToArrayAsync();
        }
    }
}
