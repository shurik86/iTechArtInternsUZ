

namespace iTechArt.Domain.IExcelGenerate
{
    public interface IExcelGenerator
    {
        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public Task<byte[]> GetExcelAsync<T>(T[] arrayOfEntities)
            where T : class;
    }
}
