﻿using iTechArt.Database.DbContexts;
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
        public async Task<IGraph> GetGroceryGraphData()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Groceries")).ToString();
            var maleAmount = await _dbContext.Groceries.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            var femaleAmount= await _dbContext.Groceries.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();
            var femaleAge = await _dbContext.Groceries.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.Birthday.Year}.Age).SumAsync();
            var maleAge = await _dbContext.Groceries.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.Birthday.Year }.Age).SumAsync();

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
        public async Task<IGraph> GetPupilsGraphData()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Pupils")).ToString();
            var maleAmount = await _dbContext.Pupils.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            var femaleAmount = await _dbContext.Pupils.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();
            var femaleAge = await _dbContext.Pupils.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();
            var maleAge = await _dbContext.Pupils.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();

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
        public async Task<IGraph> GetStudentsGraphData()
        {
            var tableName = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Students")).ToString();
            var maleAmount = await _dbContext.Students.GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync();
            var femaleAmount = await _dbContext.Students.GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync();
            var femaleAge = await _dbContext.Students.Where(p => p.Gender == Gender.Female).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();
            var maleAge = await _dbContext.Students.Where(p => p.Gender == Gender.Male).Select(c => new { Age = DateTime.Now.Year - c.DateOfBirth.Year }.Age).SumAsync();

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
        public async Task<IGraph> GetMedstaffGraphData()
        {
            var graphs = new List<IGraph>();
            graphs.Add(new Graph()
            {
                Unit = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Staffs")).ToString(),
                MaleAmount = await _dbContext.Staffs
                      .GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync(),
                FemaleAmount = await _dbContext.Staffs
                    .GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync(),
            });
            return null;
        }

        /// <summary>
        /// Gets from database table-name for police and count of males and females in police table.
        /// </summary>
        public async Task<IGraph> GetPoliceGraphData()
        {
            var graphs = new List<IGraph>();
            graphs.Add(new Graph()
            {
                Unit = _dbContext.Model.GetEntityTypes().Select(x => x.GetTableName()).FirstOrDefault(a => a.Equals("Police")).ToString(),
                MaleAmount = await _dbContext.Police
                      .GroupBy(a => a.Gender).Select(g => g.Count(o => o.Gender == Gender.Male)).FirstOrDefaultAsync(),
                FemaleAmount = await _dbContext.Police
                    .GroupBy(c => new { Gender.Female }).Select(s => s.Count(x => x.Gender == Gender.Female)).FirstOrDefaultAsync(),
            });
            return null;
        }

    }
}
