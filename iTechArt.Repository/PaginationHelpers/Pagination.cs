namespace iTechArt.Repository.PaginationHelpers
{
    internal static class Pagination
    {
        public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> source, int pageIndex)
        {
            return PaginationConstant.PageSize > 0 && pageIndex > 0
                ? source.Skip((pageIndex - 1) * PaginationConstant.PageSize).Take(PaginationConstant.PageSize)
                : source.Take(PaginationConstant.PageSize);
        }
    }
}
