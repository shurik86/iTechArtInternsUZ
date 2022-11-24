using iTechArt.Domain.Enums;
using iTechArt.Repository.SortingExtentions.Sorters;
using System.Linq.Expressions;

namespace iTechArt.Repository.PaginationExtensions
{
    internal static class Sorting
    {
        /// <summary>
        /// Paginates DbSet according to the pageIndex and PageSize.
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
            if (sortDirection == SortDirection.Ascending)
            {
                return source.OrderBy(selector);
            }
            else
            {
                return source.OrderByDescending(selector);
            }
        }
    }
}