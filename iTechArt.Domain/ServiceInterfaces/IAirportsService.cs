using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IAirportsService
    {
        /// <summary>
        /// Interface of Importing airport datas.
        /// </summary>
        public Task ImportAirportFileAsync(IFormFile file);

        /// <summary>
        /// Parse airport's file from excel.
        /// </summary>      
        public Task AirportExcelParseAsync(IFormFile file);

        /// <summary>
        /// Parse airport's file from csv.
        /// </summary>
        public Task AirportCSVParseAsync(IFormFile file);

        /// <summary>
        /// Parse airport's file from xml.
        /// </summary>
        public Task AirportXMLParseAsync(IFormFile file);
        /// <summary>
        /// Interface of Exporting airport datas.
        /// </summary>
        public Task<IAirport[]> ExportAirportExcelAsync(int pageIndex, int pageSize, string fieldName, SortDirection sortDirection);

        /// <summary>
        /// Exports Airport Data to a new XML file.
        /// </summary>
        public Task<byte[]> ExportXmlAsync();

        /// <summary>
        /// Exports Airport Data to a new Excel file.
        /// </summary>
        public Task<byte[]> ExportExcelAsync();

        /// <summary>
        /// Exports Airport Data to a new Csv file.
        /// </summary>
        public Task<byte[]> ExportCsvAsync();
    }
}
