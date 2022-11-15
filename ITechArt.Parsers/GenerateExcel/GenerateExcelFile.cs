using iTechArt.Database.DbContexts;
using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GenerateExcelFile : IGenerateExcel
    {
        private readonly IRepository _repository;

        public GenerateExcelFile(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetExcelAsync<T>()
            where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var arrayOfEntities = await _repository.GetAllAsync<T>();
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(nameof(T));
                var range = worksheet.Cells["A1"].LoadFromCollection(arrayOfEntities, true);
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
