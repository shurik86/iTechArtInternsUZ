using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace iTechArt.Serivce.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IGroceryParser _groceryParsers;
        private readonly IGenerateGroceryXml _generateGroceryXml;
        public GroceryService(IGroceryRepository groceryRepository, 
                              IGroceryParser groceryParsers,
                              IGenerateGroceryXml generateGroceryXml)
        {
            _groceryParsers = groceryParsers;
            _groceryRepository = groceryRepository;
            _generateGroceryXml = generateGroceryXml;
        }

        /// <summary>
        /// Export grocery data.
        /// </summary>
        public async Task<IGrocery[]> ExportGroceryAsync()
        {
            return await _groceryRepository.GetAllAsync();
        }


        /// <summary>
        /// Get Count of Groceries.
        /// </summary>
        public async ValueTask<int> GetCountOfGroceryAsync()
        {
            return await _groceryRepository.GetCountOfGroceryAsync();
        }


        /// <summary>
        /// Import Csv format grocery files.
        /// </summary>
        public async Task ImportCSVGroceryAsync(IFormFile formFile)
        {
           var groceryParse = await _groceryParsers.ParseCsvAsync(formFile);
            await _groceryRepository.AddGroceriesAsync(groceryParse);
        }


        /// <summary>
        /// Import Excel format grocery files.
        /// </summary>
        public async Task ImportExcelGroceryAsync(IFormFile formFile)
        {
            var groceryParse= await _groceryParsers.ExcelParseAsync(formFile);
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
            using (var memoryStream = new MemoryStream())
            {
                xmlDocument.Save(memoryStream);
                await memoryStream.FlushAsync();
                return memoryStream.ToArray();
            }
        }
    }
}
