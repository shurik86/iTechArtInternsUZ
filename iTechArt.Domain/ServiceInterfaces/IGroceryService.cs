using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
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
        public Task<IGrocery[]> ExportGrocery(int pageIndex);

        /// <summary>
        /// Count of grocery items.
        /// </summary>
        public ValueTask <int> GetCountOfGroceryAsync();

    }
}
