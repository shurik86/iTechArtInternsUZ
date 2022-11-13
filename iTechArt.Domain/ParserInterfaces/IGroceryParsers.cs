using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IGroceryParser
    {
        /// <summary>
        /// Parse csv grocery file. 
        /// </summary>
        public Task<IGrocery[]> ParseCsvAsync(IFormFile formFile);

        /// <summary>
        /// Parse Excel grocery file. 
        /// </summary>
        public Task<IGrocery[]> ExcelParseAsync(IFormFile formFile);

        /// <summary>
        /// Parse XML grocery file. 
        /// </summary>
        public Task<IGrocery[]> XmlParseAsync(IFormFile formFile);
    }
}
