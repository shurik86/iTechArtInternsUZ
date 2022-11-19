

namespace iTechArt.Domain.IExcelGenerate
{
    public interface IPupilExcelGenerate
    {
        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public Task<byte[]> GetExcelAsync();
    }
}
