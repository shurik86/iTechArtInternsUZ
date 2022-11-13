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
        public Task AirportExcelParserAsync(IFormFile file);

        /// <summary>
        /// Parse airport's file from csv.
        /// </summary>
        public Task AirportCSVParserAsync(IFormFile file);

        /// <summary>
        /// Parse airport's file from xml.
        /// </summary>
        public Task AirportXMLParserAsync(IFormFile file);
        /// <summary>
        /// Interface of Exporting airport datas.
        /// </summary>
        public Task<IAirport[]> ExportAirportExcelAsync(int pageIndex);
    }
}
