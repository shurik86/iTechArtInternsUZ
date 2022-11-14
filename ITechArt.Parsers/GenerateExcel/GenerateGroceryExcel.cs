using iTechArt.Domain.ParserInterfaces.IGenerateExcel;
using iTechArt.Domain.RepositoryInterfaces;
using OfficeOpenXml;
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

        public GenerateGroceryExcel(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }


        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetGroceryExcelAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var groceryArray = await _groceryRepository.GetAllAsync();
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Grocery");
                var range = worksheet.Cells["A1"].LoadFromCollection(groceryArray, true);
                await package.SaveAsync();
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    await memoryStream.FlushAsync();
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
