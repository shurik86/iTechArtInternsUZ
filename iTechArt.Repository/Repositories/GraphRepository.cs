using iTechArt.Database.DbContexts;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repository.Repositories
{
    public sealed class GraphRepository : IGraphRepository
    {

        private readonly AppDbContext _dbContext;
        public GraphRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets from database table-name for grocery and count of males and females in grocery table.
        /// </summary>
        public async Task<IGraph> GetGroceryGraphDataAsync()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Groceries")).ToString();
            int maleAmount = await _dbContext.Groceries.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            int femaleAmount= await _dbContext.Groceries.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();
            double femaleAge = await _dbContext.Groceries.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.Birthday.Year}.Age).SumAsync();
            double maleAge = await _dbContext.Groceries.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.Birthday.Year }.Age).SumAsync();

            IGraph graphs = new Graph();
            graphs.Unit = tableName;
            graphs.MaleAmount = maleAmount;
            graphs.FemaleAmount = femaleAmount;
            graphs.AverageAgeMale = maleAmount / maleAge;
            graphs.AverageAgeFemale = femaleAmount / femaleAge;  
            return graphs;
        }
            
        /// <summary>
        /// Gets from database table-name for pupils and count of males and females in pupil table.
        /// </summary>
        public async Task<IGraph> GetPupilsGraphDataAsync()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Pupils")).ToString();
            var maleAmount = await _dbContext.Pupils.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            var femaleAmount = await _dbContext.Pupils.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();
            double femaleAge = await _dbContext.Pupils.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();
            double maleAge = await _dbContext.Pupils.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();

            IGraph graphs = new Graph();
            graphs.Unit = tableName;
            graphs.MaleAmount = maleAmount;
            graphs.FemaleAmount = femaleAmount;
            graphs.AverageAgeMale = maleAmount / maleAge;
            graphs.AverageAgeFemale = femaleAmount / femaleAge;
            return graphs;
        }
        /// <summary>
        /// Gets from database table-name for students and count of males and females in student table.
        /// </summary>
        public async Task<IGraph> GetStudentsGraphDataAsync()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Students")).ToString();
            var maleAmount = await _dbContext.Students.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            var femaleAmount = await _dbContext.Students.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();
            double femaleAge = await _dbContext.Students.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();
            double maleAge = await _dbContext.Students.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();

            IGraph graphs = new Graph();
            graphs.Unit = tableName;
            graphs.MaleAmount = maleAmount;
            graphs.FemaleAmount = femaleAmount;
            graphs.AverageAgeMale = maleAmount / maleAge;
            graphs.AverageAgeFemale = femaleAmount / femaleAge;
            return graphs;
        }

        /// <summary>
        /// Gets from database table-name for medstaffs and count of males and females in staffs table.
        /// </summary>
        public async Task<IGraph> GetMedstaffGraphDataAsync()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Staffs")).ToString();
            var maleAmount = await _dbContext.Staffs.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            var femaleAmount = await _dbContext.Staffs.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();
            double femaleAge = await _dbContext.Staffs.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();
            double maleAge = await _dbContext.Staffs.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();

            IGraph graphs = new Graph();
            graphs.Unit = tableName;
            graphs.MaleAmount = maleAmount;
            graphs.FemaleAmount = femaleAmount;
            graphs.AverageAgeMale = maleAmount / maleAge;
            graphs.AverageAgeFemale = femaleAmount / femaleAge;
            return graphs;
        }

        /// <summary>
        /// Gets from database table-name for police and count of males and females in police table.
        /// </summary>
        public async Task<IGraph> GetPoliceGraphDataAsync()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Police")).ToString();
            var maleAmount = await _dbContext.Police.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            var femaleAmount = await _dbContext.Police.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();

            //TODO:DM: After the dob will be added police need to uncomment the logic.
            double femaleAge = await _dbContext.Police.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.BirthDate.Year }.Age).SumAsync();
            double maleAge = await _dbContext.Police.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.BirthDate.Year }.Age).SumAsync();

            IGraph graphs = new Graph();
            graphs.Unit = tableName;
            graphs.MaleAmount = maleAmount;
            graphs.FemaleAmount = femaleAmount;

            graphs.AverageAgeMale = maleAmount / maleAge;
            graphs.AverageAgeFemale = femaleAmount / femaleAge;

            return graphs;
        }

    }
}
