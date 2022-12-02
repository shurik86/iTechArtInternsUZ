using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IAirportParsers
    {
        /// <summary>
        /// Parse Csv file.
        /// </summary>
        public Task CsvParserAsync(IFormFile file);

        /// <summary>
        /// Parse Excel file.
        /// </summary>
        public Task ExcelParserAsync(IFormFile file);

        /// <summary>
        /// Parse Xml file.
        /// </summary>
        public Task XmlParserAsync(IFormFile file);
    }
}
