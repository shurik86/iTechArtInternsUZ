using iTechArt.Database.Entities.Groceries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class GroceryDBSorter : BaseDBSorter<GroceryDb>
    {
        /// <summary>
        /// 
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
