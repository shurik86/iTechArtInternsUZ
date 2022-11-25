using iTechArt.Database.Entities.Groceries;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class GroceryDBSorter : BaseDBSorter<GroceryDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected override Dictionary<string, Expression<Func<GroceryDb, object>>> TableFieldSorters { get; } = new() {
            { "firstname", f => f.FirstName },
            { "lastname", l => l.LastName },
            { "birthday", b => b.Birthday },
            { "gender", g => g.Gender },
            { "email", e => e.Email },
            { "jobtitle", j => j.Jobtitle },
            { "departmentretail", d => d.Departmentretail },
            { "salary", s => s.Salary }
        };
    }
}
