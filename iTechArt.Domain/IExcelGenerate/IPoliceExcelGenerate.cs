

namespace iTechArt.Domain.IExcelGenerate
{
    public interface IPoliceExcelGenerate
    {
        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public Task<byte[]> GetExcelAsync();
    }
}
