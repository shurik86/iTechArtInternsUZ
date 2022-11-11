using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
