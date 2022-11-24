using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using iTechArt.Repository.BusinessModels.GraphModels;
using Microsoft.EntityFrameworkCore;


namespace iTechArt.Repository.Repositories
{
    public sealed class RetirementRepository : IRetirementRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly int RetirementAgePolice = 40;
        private readonly int RetirementAgeGrocery = 60;
        private readonly int RetirementAgeMedStaff = 60;

        public RetirementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredPeopleAsync(int from, int to)
        {
            var retiredPolices = await _dbContext.Police
                .Where(c => c.BirthDate.Year >= from - RetirementAgePolice && c.BirthDate.Year <= to - RetirementAgePolice)
                .ToArrayAsync();
            var retiredMedStaff = await _dbContext.Staffs
                .Where(c => c.DateOfBirth.Year >= from - RetirementAgeMedStaff && c.DateOfBirth.Year <= to - RetirementAgeMedStaff)
                .ToArrayAsync();
            var retiredGrocery = await _dbContext.Groceries
                .Where(c => c.Birthday.Year >= from - RetirementAgeGrocery && c.Birthday.Year <= to - RetirementAgeGrocery)
                .ToArrayAsync();

            var retiredData = new RetiredPeople
            {
                RetiredPolice = retiredPolices.Length,
                RetiredMedStaff = retiredMedStaff.Length,
                RetiredGrocery = retiredGrocery.Length,
            };

            return retiredData;
        }
    }
}
