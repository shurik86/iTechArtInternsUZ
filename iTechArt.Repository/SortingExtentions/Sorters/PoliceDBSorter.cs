using iTechArt.Database.Entities.Police;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class PoliceDBSorter : BaseDBSorter<PoliceDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected override Dictionary<string, Expression<Func<PoliceDb, object>>> TableFieldSorters { get; } = new() {
            { "firstname", f => f.Name },
            { "surname", s => s.Surname },
            { "email", e => e.Email },
            { "gender", g => g.Gender },
            { "address", a => a.Address },
            { "jobtitle", j => j.JobTitle },
            { "salary", s => s.Salary },
            { "birthdate", b => b.BirthDate }
        };
        
        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected override Expression<Func<PoliceDb, object>> DefaultFieldSorter => TableFieldSorters["firstname"];
    }
}