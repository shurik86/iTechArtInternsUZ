namespace iTechArt.Repository.PaginationHelpers
{
    internal static class Pagination
    {
        /// <summary>
        /// Paginates DbSet according to the pageIndex and PageSize.
        /// </summary>
        public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> source, int pageIndex)
        {
            return pageIndex > 0
                ? source.Skip((pageIndex - 1) * PaginationConstant.PageSize)
                        .Take(PaginationConstant.PageSize)
                : source.Take(PaginationConstant.PageSize);
        }
    }
}
