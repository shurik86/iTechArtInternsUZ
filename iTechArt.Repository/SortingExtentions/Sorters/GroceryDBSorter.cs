using iTechArt.Database.Entities.Groceries;
using iTechArt.Database.Entities.Students;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class GroceryDBSorter : BaseDBSorter<GroceryDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected override Dictionary<string, Expression<Func<GroceryDb, object>>> TableFieldSorters { get; } = new() {
            { "firstName", f => f.FirstName },
            { "lastName", l => l.LastName },
            { "birthday", b => b.Birthday },
            { "gender", g => g.Gender },
            { "email", e => e.Email },
            { "jobTitle", j => j.Jobtitle },
            { "departmentRetail", d => d.Departmentretail },
            { "salary", s => s.Salary }
        };

        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected override Expression<Func<GroceryDb, object>> DefaultFieldSorter => TableFieldSorters["firstName"];
    }
}
