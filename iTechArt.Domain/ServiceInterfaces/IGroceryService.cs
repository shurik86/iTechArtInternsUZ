using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGroceryService
    {
        /// <summary>
        /// Import Csv format data for grocery.
        /// </summary>
        public Task ImportCSVGroceryAsync(IFormFile formFile);
        /// <summary>
        /// Import Excel format data for grocery.
        /// </summary>
        public Task ImportExcelGroceryAsync(IFormFile formFile);
        /// <summary>
        /// Import Xml format data for grocery.
        /// </summary>
        public Task ImportXMLGroceryAsync(IFormFile formFile);

        /// <summary>
        /// Export data for grocery.
        /// </summary>
        public Task<IGrocery[]> ExportGroceryAsync(int pageIndex);

        /// <summary>
        /// Count of grocery not implemented yet.
        /// </summary>
        public ValueTask <int> GetCountOfGroceryAsync();
    }
}
