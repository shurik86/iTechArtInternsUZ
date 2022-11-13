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
    public sealed class GenerateAirportExcel : IGenerateAirportExcel
    {
        private readonly IAirportRepository _airportRepository;

        public GenerateAirportExcel(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetAirportExcelAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var airportsArray = await _airportRepository.GetAllAsync();
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Airport");
                var range = worksheet.Cells["A1"].LoadFromCollection(airportsArray, true);
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
