using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IStudentParser
    {
        /// <summary>
        /// Parse student's file from excel.
        /// </summary>
        public Task<IStudent[]> ExcelParseAsync(IFormFile file);

        /// <summary>
        /// Parse student's file from csv.
        /// </summary>
        public Task<IStudent[]> CsvParseAsync(IFormFile file);

        /// <summary>
        /// Parse student's file from xml.
        /// </summary>
        public Task<IStudent[]> XmlParseAsync(IFormFile file);
    }
}
