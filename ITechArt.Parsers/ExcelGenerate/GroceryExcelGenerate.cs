using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;


namespace ITechArt.Parsers.ExcelGenerate
{
    public sealed class GroceryExcelGenerate : IGroceryExcelGenerate
    {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IExcelGenerator _generateExcel;

        public GroceryExcelGenerate(IGroceryRepository groceryRepository, IExcelGenerator generateExcel)
        {
            _groceryRepository = groceryRepository;
            _generateExcel = generateExcel;
        }

        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetExcelAsync()
        {
            var entityArray = await _groceryRepository.GetAllAsync();
            return await _generateExcel.GetExcelAsync<IGrocery>(entityArray);
        }
    }
}
