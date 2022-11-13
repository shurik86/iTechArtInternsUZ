using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Serivce.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IGroceryParsers _groceryParsers;
        public GroceryService(IGroceryRepository groceryRepository, IGroceryParsers groceryParsers)
        {
            _groceryParsers = groceryParsers;
            _groceryRepository = groceryRepository;
        }

        /// <summary>
        /// Export grocery data.
        /// </summary>
        public async Task<IGrocery[]> ExportGroceryAsync(int pageIndex)
        {
            return await _groceryRepository.GetAllAsync(pageIndex);
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
            await _groceryParsers.RecordCsvToDatabaseAsync(formFile);
        }
        /// <summary>
        /// Import Excel format grocery files.
        /// </summary>
        public async Task ImportExcelGroceryAsync(IFormFile formFile)
        {
            await _groceryParsers.RecordExcelToDatabaseAsync(formFile);
        }
        /// <summary>
        /// Import XML format grocery files.
        /// </summary>
        public async Task ImportXMLGroceryAsync(IFormFile formFile)
        {
            await _groceryParsers.RecordXmlToDatabaseAsync(formFile);
        }
    }
}
