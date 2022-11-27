using iTechArt.Database.DbContexts;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels.GraphModels;
using Microsoft.EntityFrameworkCore;


namespace iTechArt.Repository.Repositories
{
    public sealed class FacultyInfoRepository : IFacultyInfoRepository
    {
        private readonly AppDbContext _dbContext;

        public FacultyInfoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets info about number of students enrolled in each faculty.
        /// </summary>
        public async Task<IFacultyInfo> GetFacultyInfo()
        {
            var students = await _dbContext.Students.ToArrayAsync();
            int economics = students.Select(c => c.Faculty = Faculty.Economics).ToList().Count;
            int law = students.Select(c => c.Faculty = Faculty.Law).ToList().Count;
            int medicine = students.Select(c => c.Faculty = Faculty.Medicine).ToList().Count;
            int psychology = students.Select(c => c.Faculty = Faculty.Psychology).ToList().Count;
            int engineering = students.Select(c => c.Faculty = Faculty.Engineering).ToList().Count;
            int science = students.Select(c => c.Faculty = Faculty.Science).ToList().Count;

            var facutlyInfo = new FacultyInfo
            {
                Economics = economics,
                Law = law,
                Medicine = medicine,
                Psychology = psychology,
                Engineering = engineering,
                Science = science
            };

            return facutlyInfo;
        }
    }
}
