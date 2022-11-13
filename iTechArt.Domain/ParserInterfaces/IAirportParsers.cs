using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IAirportParsers
    {
        public Task CsvParserAsync(IFormFile file);
        public Task ExcelParserAsync(IFormFile file);
        public Task XmlParserAsync(IFormFile file);
    }
}
