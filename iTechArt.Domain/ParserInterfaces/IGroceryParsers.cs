using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IGroceryParsers
    {
        public Task RecordCsvToDatabaseAsync(IFormFile formFile);

        public Task RecordExcelToDatabaseAsync(IFormFile formFile);

        public Task RecordXmlToDatabaseAsync(IFormFile formFile);
    }
}
