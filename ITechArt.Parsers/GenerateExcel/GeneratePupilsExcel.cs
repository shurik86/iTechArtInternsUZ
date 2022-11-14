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
    public sealed class GeneratePupilsExcel : IGeneratePupilsExcel
    {
        private readonly IPupilRepository _pupilRepository;

        public GeneratePupilsExcel(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }


        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetPupilsExcelAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var pupilsArray = await _pupilRepository.GetAllAsync();
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Pupils");
                var range = worksheet.Cells["A1"].LoadFromCollection(pupilsArray, true);
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
