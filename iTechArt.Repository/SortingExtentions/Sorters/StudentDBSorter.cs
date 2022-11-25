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
            { "firstname", f => f.FirstName },
            { "lastname", l => l.LastName },
            { "email", e => e.Email },
            { "majority", m => m.Majority },
            { "university", u => u.University }
        };
    }
}