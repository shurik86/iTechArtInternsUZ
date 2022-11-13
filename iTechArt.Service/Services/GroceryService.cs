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
        private readonly IGroceryParsers _groceryParsers;
        private readonly IGenerateGroceryXml _generateGroceryXml;

        public GroceryService(IGroceryRepository groceryRepository, 
                              IGroceryParsers groceryParsers,
                              IGenerateGroceryXml generateGroceryXml)
        {
            _groceryParsers = groceryParsers;
            _groceryRepository = groceryRepository;
            _generateGroceryXml = generateGroceryXml;
        }

        /// <summary>
        /// Export grocery data
        /// </summary>
        public async Task<IGrocery[]> ExportGrocery()
        {
            return await _groceryRepository.GetAllAsync();
        }


        /// <summary>
        /// Get Count of Groceries
        /// </summary>
        public async ValueTask<int> GetCountOfGrocery()
        {
            return await _groceryRepository.GetCountOfGrocery();
        }


        /// <summary>
        /// Import Csv format grocery files
        /// </summary>
        public async Task ImportCSVGrocery(IFormFile formFile)
        {
            await _groceryParsers.RecordCsvToDatabase(formFile);
        }


        /// <summary>
        /// Import Excel format grocery files
        /// </summary>
        public async Task ImportExcelGrocery(IFormFile formFile)
        {
            await _groceryParsers.RecordExcelToDatabase(formFile);
        }


        /// <summary>
        /// Import XML format grocery files
        /// </summary>
        public async Task ImportXMLGrocery(IFormFile formFile)
        {
            await _groceryParsers.RecordXmlToDatabase(formFile);
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
