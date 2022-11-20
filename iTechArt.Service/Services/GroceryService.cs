using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.Dtos.Groceries;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace iTechArt.Serivce.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IParser _parser;
        private readonly IGroceryRepository _groceryRepository;
        private readonly IGroceryParser _groceryParsers;
        private readonly IGroceryExcelGenerate _generateGroceryExcel;
        private readonly IGroceryXmlGenerate _generateGroceryXml;
        private readonly IStreamToArray _streamToArray;

        public GroceryService(IGroceryRepository groceryRepository, 
                              IGroceryParser groceryParsers,
                              IGroceryExcelGenerate generateGroceryExcel,
                              IGroceryXmlGenerate generateGroceryXml,
                              IStreamToArray streamToArray,
                              IParser parser)
        {
            _groceryRepository = groceryRepository;
            _groceryParsers = groceryParsers;
            _generateGroceryExcel = generateGroceryExcel;
            _generateGroceryXml = generateGroceryXml;
            _streamToArray = streamToArray;
            _parser = parser;
        }

        /// <summary>
        /// Export grocery data.
        /// </summary>
        public async Task<IGrocery[]> ExportGroceryAsync(int pageIndex, int pageSize)
        {
            return await _groceryRepository.GetAllAsync(pageIndex, pageSize);
        }

        /// <summary>
        /// Get Count of Groceries.
        /// </summary>
        public async ValueTask<int> GetCountOfGroceryAsync()
        {
            return await _groceryRepository.GetCountAsync();
        }

        /// <summary>
        /// Import Csv format grocery files.
        /// </summary>
        public async Task ImportCSVGroceryAsync(IFormFile formFile)
        {
            var groceryParse = await _parser.CsvParseAsync<GroceryMap, GroceryDto>(formFile);
           
            await _groceryRepository.AddGroceriesAsync(groceryParse);
        }

        /// <summary>
        /// Import Excel format grocery files.
        /// </summary>
        public async Task ImportExcelGroceryAsync(IFormFile formFile)
        {
            var groceryParse= await _parser.ExcelParseAsync<GroceryDto>(formFile);

            await _groceryRepository.AddGroceriesAsync(groceryParse);
        }

        /// <summary>
        /// Import XML format grocery files.
        /// </summary>
        public async Task ImportXMLGroceryAsync(IFormFile formFile)
        {
            var groceryParse = await _groceryParsers.XmlParseAsync(formFile);
            await _groceryRepository.AddGroceriesAsync(groceryParse);
        }

        /// <summary>
        /// Exports Grocery Data to a new XML file.
        /// </summary>
        public async Task<byte[]> ExportXmlAsync()
        {
            XmlDocument xmlDocument = await _generateGroceryXml.GetGroceryXmlAsync();
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports Grocery Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generateGroceryExcel.GetExcelAsync();
        }
    }
}
