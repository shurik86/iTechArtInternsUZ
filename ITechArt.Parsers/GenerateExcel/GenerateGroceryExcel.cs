using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GenerateGroceryExcel : IGenerateGroceryExcel
    {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IGenerateExcel _generateExcel;

        public GenerateGroceryExcel(IGroceryRepository groceryRepository, IGenerateExcel generateExcel)
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
