using iTechArt.Domain.Enums;
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
        /// Count of grocery items.
        /// </summary>
        public Task<IGrocery[]> ExportGroceryAsync(int pageIndex, int pageSize, string fieldName, SortDirection sortDirection);
        public ValueTask <long> GetCountAsync();

        /// <summary>
        /// Exports Grocery Data to a new XML file.
        /// </summary>
        public Task<byte[]> ExportXmlAsync();

        /// <summary>
        /// Exports Grocery Data to a new Excel file.
        /// </summary>
        public Task<byte[]> ExportExcelAsync();

        /// <summary>
        /// Exports Grocery Data to a new Csv file.
        /// </summary>
        public Task<byte[]> ExportCsvAsync();
    }
}
