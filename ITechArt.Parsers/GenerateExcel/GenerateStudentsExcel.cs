using iTechArt.Database.DbContexts;
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
    public sealed class GenerateStudentsExcel : IGenerateStudentsExcel
    {
        private readonly IStudentRepository _studentRepository;

        public GenerateStudentsExcel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetStudentsExcelAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var studentsArray = await _studentRepository.GetAllAsync();
            using(var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Students");
                var range = worksheet.Cells["A1"].LoadFromCollection(studentsArray, true);
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
