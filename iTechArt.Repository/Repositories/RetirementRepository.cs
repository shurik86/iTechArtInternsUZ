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
        private readonly int RetirementAgeGrocery = 65;
        private readonly int RetirementAgeMedStaff = 65;

        public RetirementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredPolicesAsync()
        {
            var retiredPolices = await _dbContext.Police
                .Where(c => DateTime.Now.Year-c.BirthDate.Year >= RetirementAgePolice)
                .ToArrayAsync();

            int Y1980to84 = retiredPolices.Where(c => c.BirthDate.Year+ RetirementAgePolice >= 1980 && c.BirthDate.Year+ RetirementAgePolice < 1985).ToList().Count;
            int Y1985to89 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 1985 && c.BirthDate.Year + RetirementAgePolice < 1990).ToList().Count;
            int Y1990to94 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 1990 && c.BirthDate.Year + RetirementAgePolice < 1995).ToList().Count;
            int Y1995to99 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 1995 && c.BirthDate.Year + RetirementAgePolice < 2000).ToList().Count;
            int Y2000to04 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 2000 && c.BirthDate.Year + RetirementAgePolice < 2005).ToList().Count;
            int Y2005to09 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 2005 && c.BirthDate.Year + RetirementAgePolice < 2010).ToList().Count;
            int Y2010to14 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 2010 && c.BirthDate.Year + RetirementAgePolice < 2015).ToList().Count;
            int Y2015to19 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 2015 && c.BirthDate.Year + RetirementAgePolice < 2020).ToList().Count;
            int Y2020to21 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice >= 2020 && c.BirthDate.Year + RetirementAgePolice < 2022).ToList().Count;
            int Y2022 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAgePolice == 2022).ToList().Count;

            var retiredData = new RetiredPeople
            {
                Y1980to84 = Y1980to84,
                Y1985to89 = Y1985to89,
                Y1990to94 = Y1990to94,
                Y1995to99 = Y1995to99,
                Y2000to04 = Y2000to04,
                Y2005to09 = Y2005to09,
                Y2010to14 = Y2010to14,
                Y2015to19 = Y2015to19,
                Y2020to21 = Y2020to21,
                Y2022 = Y2022
            };

            return retiredData;
        }

        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredMedStaffAsync()
        {
            var retiredMedStaffs = await _dbContext.Staffs
                .Where(c => DateTime.Now.Year - c.DateOfBirth.Year >= RetirementAgeMedStaff)
                .ToArrayAsync();

            int Y1980to84 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 1980 && c.DateOfBirth.Year + RetirementAgeMedStaff < 1985).ToList().Count;
            int Y1985to89 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 1985 && c.DateOfBirth.Year + RetirementAgeMedStaff < 1990).ToList().Count;
            int Y1990to94 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 1990 && c.DateOfBirth.Year + RetirementAgeMedStaff < 1995).ToList().Count;
            int Y1995to99 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 1995 && c.DateOfBirth.Year + RetirementAgeMedStaff < 2000).ToList().Count;
            int Y2000to04 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 2000 && c.DateOfBirth.Year + RetirementAgeMedStaff < 2005).ToList().Count;
            int Y2005to09 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 2005 && c.DateOfBirth.Year + RetirementAgeMedStaff < 2010).ToList().Count;
            int Y2010to14 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 2010 && c.DateOfBirth.Year + RetirementAgeMedStaff < 2015).ToList().Count;
            int Y2015to19 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 2015 && c.DateOfBirth.Year + RetirementAgeMedStaff < 2020).ToList().Count;
            int Y2020to21 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff >= 2020 && c.DateOfBirth.Year + RetirementAgeMedStaff < 2022).ToList().Count;
            int Y2022 = retiredMedStaffs.Where(c => c.DateOfBirth.Year + RetirementAgeMedStaff == 2022).ToList().Count;

            var retiredData = new RetiredPeople
            {
                Y1980to84 = Y1980to84,
                Y1985to89 = Y1985to89,
                Y1990to94 = Y1990to94,
                Y1995to99 = Y1995to99,
                Y2000to04 = Y2000to04,
                Y2005to09 = Y2005to09,
                Y2010to14 = Y2010to14,
                Y2015to19 = Y2015to19,
                Y2020to21 = Y2020to21,
                Y2022 = Y2022
            };

            return retiredData;
        }

        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredGroceriesAsync()
        {
            var retiredGroceries = await _dbContext.Groceries
                .Where(c => DateTime.Now.Year - c.Birthday.Year >= RetirementAgeGrocery)
                .ToArrayAsync();

            int Y1980to84 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 1980 && c.Birthday.Year + RetirementAgeGrocery < 1985).ToList().Count;
            int Y1985to89 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 1985 && c.Birthday.Year + RetirementAgeGrocery < 1990).ToList().Count;
            int Y1990to94 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 1990 && c.Birthday.Year + RetirementAgeGrocery < 1995).ToList().Count;
            int Y1995to99 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 1995 && c.Birthday.Year + RetirementAgeGrocery < 2000).ToList().Count;
            int Y2000to04 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 2000 && c.Birthday.Year + RetirementAgeGrocery < 2005).ToList().Count;
            int Y2005to09 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 2005 && c.Birthday.Year + RetirementAgeGrocery < 2010).ToList().Count;
            int Y2010to14 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 2010 && c.Birthday.Year + RetirementAgeGrocery < 2015).ToList().Count;
            int Y2015to19 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 2015 && c.Birthday.Year + RetirementAgeGrocery < 2020).ToList().Count;
            int Y2020to21 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery >= 2020 && c.Birthday.Year + RetirementAgeGrocery < 2022).ToList().Count;
            int Y2022 = retiredGroceries.Where(c => c.Birthday.Year + RetirementAgeGrocery == 2022).ToList().Count;

            var retiredData = new RetiredPeople
            {
                Y1980to84 = Y1980to84,
                Y1985to89 = Y1985to89,
                Y1990to94 = Y1990to94,
                Y1995to99 = Y1995to99,
                Y2000to04 = Y2000to04,
                Y2005to09 = Y2005to09,
                Y2010to14 = Y2010to14,
                Y2015to19 = Y2015to19,
                Y2020to21 = Y2020to21,
                Y2022 = Y2022
            };

            return retiredData;
        }
    }
}
