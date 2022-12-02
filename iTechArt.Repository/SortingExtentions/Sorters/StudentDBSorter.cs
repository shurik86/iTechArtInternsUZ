using iTechArt.Database.Entities.Students;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class StudentDBSorter : BaseDBSorter<StudentDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected override Dictionary<string, Expression<Func<StudentDb, object>>> TableFieldSorters { get; } = new() {
            { "firstName", f => f.FirstName },
            { "lastName", l => l.LastName },
            { "email", e => e.Email },
            { "majority", m => m.Majority },
            { "university", u => u.University }
        };

        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected override Expression<Func<StudentDb, object>> DefaultFieldSorter => TableFieldSorters["firstName"];
    }
}