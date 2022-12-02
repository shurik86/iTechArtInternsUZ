using iTechArt.Domain.Enums;
using iTechArt.Repository.SortingExtentions.Sorters;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace iTechArt.Repository.PaginationExtensions
{
    internal static class Sorting
    {
        /// <summary>
        /// Sorts DbSet according to the fieldname and sortdirection.
        /// </summary>
        public static IOrderedQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source,
                                                               string fieldName,
                                                               SortDirection sortDirection,
                                                               BaseDBSorter<TSource> dBSorter)
            where TSource : class
        {
            var fieldTableSorter = dBSorter.GetFieldSorter(fieldName);

            return source.ApplySorter(fieldTableSorter,
                                      sortDirection);
        }

        private static IOrderedQueryable<TSource> ApplySorter<TSource>(this IQueryable<TSource> source,
                                                                       Expression<Func<TSource, object>> selector,
                                                                       SortDirection sortDirection)
        {
            return sortDirection == SortDirection.Descending
                ? source.OrderByDescending(selector)
                : source.OrderBy(selector);
        }
    }
}