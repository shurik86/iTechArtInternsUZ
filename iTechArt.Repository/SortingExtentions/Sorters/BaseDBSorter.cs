using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public abstract class BaseDBSorter<TTableSorter> where TTableSorter : class
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected abstract Dictionary<string, Expression<Func<TTableSorter, object>>> TableFieldSorters { get; }

        public Expression<Func<TTableSorter, object>> GetFieldSorter(string fieldName)
        {
            return TableFieldSorters[fieldName];
        }
    }
}