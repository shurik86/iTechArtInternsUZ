using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;
using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to import XLSX or XLS data to the database.
        /// </summary>
        public Task ImportExcelAsync(IFormFile formFile);


        /// <summary>
        /// function to import XML data to the database.
        /// </summary>
        public Task ImportXmlAsync(IFormFile formFile);

        /// <summary>
        /// function to import CSV data to the database.
        /// </summary>
        public Task ImportCsvAsync(IFormFile formFile);

        /// <summary>
        /// function to export data from the database.
        /// </summary>
        public Task<IPolice[]> GetAllPoliceAsync(int pageIndex, int pageSize, string fieldName, 
            SortDirection sortDirection, IPoliceFilter policeFilter);

        /// <summary>
        /// Exports Police Data to a new XML file.
        /// </summary>
        public Task<byte[]> ExportXmlAsync();

        /// <summary>
        /// Exports Police Data to a new Excel file.
        /// </summary>
        public Task<byte[]> ExportExcelAsync();

        /// <summary>
        /// Exports Police Data to a new Csv file.
        /// </summary>
        public Task<byte[]> ExportCsvAsync();
    }
}