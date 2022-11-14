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
    public sealed class GenerateMedStaffExcel : IGenerateMedStaffExcel
    {
        private readonly IMedStaffRepository _medStaffRepository;

        public GenerateMedStaffExcel(IMedStaffRepository medStaffRepository)
        {
            _medStaffRepository = medStaffRepository;
        }


        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetMedStaffExcelAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var medStaffArray = await _medStaffRepository.GetAllAsync();
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("MedStaff");
                var range = worksheet.Cells["A1"].LoadFromCollection(medStaffArray, true);
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
