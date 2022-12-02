using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;
using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Imports students into DB from file.
        /// </summary>
        public Task ImportStudentsAsync(IFormFile formFile);

        /// <summary>
        /// Exports students from DB.
        /// </summary>
        public Task<IStudent[]> GetAllAsync(int pageIndex, int pageSize, string fieldName, 
            SortDirection sortDirection, IStudentFilter studentFilter);

        /// <summary>
        /// Parse student's file from xml.
        /// </summary>
        public Task XmlImportAsync(IFormFile formFile);

        /// <summary>
        /// Parse student's file from csv.
        /// </summary>
        public Task CsvImportAsync(IFormFile formFile);

        /// <summary>
        /// Parse student's file from excel.
        /// </summary>
        public Task ExcelImportAsync(IFormFile formFile);

        /// <summary>
        /// Exports Student Data to a new XML file.
        /// </summary>
        public Task<byte[]> ExportXmlAsync();

        /// <summary>
        /// Exports Student Data to a new Excel file.
        /// </summary>
        public Task<byte[]> ExportExcelAsync();

        /// <summary>
        /// Exports Student Data to a new Csv file.
        /// </summary>
        public Task<byte[]> ExportCsvAsync();
    }
}
