using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public abstract class BaseDBSorter<TTableSorter> where TTableSorter : class
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected abstract Dictionary<string, Expression<Func<TTableSorter, object>>> TableFieldSorters { get; }

        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected abstract Expression<Func<TTableSorter, object>> DefaultFieldSorter { get; }

        public Expression<Func<TTableSorter, object>> GetFieldSorter(string fieldName)
        {
            if (TableFieldSorters.ContainsKey(fieldName))
            {
                return TableFieldSorters[fieldName];
            }

            return DefaultFieldSorter;
        }
    }
}