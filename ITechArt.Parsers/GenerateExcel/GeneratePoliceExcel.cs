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
    public sealed class GeneratePoliceExcel : IGeneratePoliceExcel
    {
        private readonly IPoliceRepository _policeRepository;

        public GeneratePoliceExcel(IPoliceRepository policeRepository)
        {
            _policeRepository = policeRepository;
        }


        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetPoliceExcelAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var policeArray = await _policeRepository.GetAllAsync();
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Police");
                var range = worksheet.Cells["A1"].LoadFromCollection(policeArray, true);
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
