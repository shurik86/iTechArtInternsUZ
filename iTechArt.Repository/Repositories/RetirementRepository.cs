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
        private readonly IMapper _mapper;
        private readonly int RetirementAge = 40;

        public RetirementRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredPolicesAsync()
        {
            var retiredPolices = await _dbContext.Police
                .Where(c => DateTime.Now.Year-c.BirthDate.Year >= RetirementAge)
                .Select(c => _mapper.Map<Police>(c))
                .ToArrayAsync();

            int Y1980 = retiredPolices.Where(c => c.BirthDate.Year+RetirementAge >= 1980 && c.BirthDate.Year+RetirementAge < 1985).ToList().Count;
            int Y1985 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 1985 && c.BirthDate.Year + RetirementAge < 1990).ToList().Count;
            int Y1990 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 1990 && c.BirthDate.Year + RetirementAge < 1995).ToList().Count;
            int Y1995 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 1995 && c.BirthDate.Year + RetirementAge < 2000).ToList().Count;
            int Y2000 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 2000 && c.BirthDate.Year + RetirementAge < 2005).ToList().Count;
            int Y2005 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 2005 && c.BirthDate.Year + RetirementAge < 2010).ToList().Count;
            int Y2010 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 2010 && c.BirthDate.Year + RetirementAge < 2015).ToList().Count;
            int Y2015 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 2015 && c.BirthDate.Year + RetirementAge < 2020).ToList().Count;
            int Y2020 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge >= 2020 && c.BirthDate.Year + RetirementAge < 2022).ToList().Count;
            int Y2022 = retiredPolices.Where(c => c.BirthDate.Year + RetirementAge == 2022).ToList().Count;

            var retiredData = new RetiredPeople
            {
                Y1980 = Y1980,
                Y1985 = Y1985,
                Y1990 = Y1990,
                Y1995 = Y1995,
                Y2000 = Y2000,
                Y2005 = Y2005,
                Y2010 = Y2010,
                Y2015 = Y2015,
                Y2020 = Y2020,
                Y2022 = Y2022
            };

            return retiredData;
        }
    }
}
