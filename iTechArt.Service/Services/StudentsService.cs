using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentParser _studentParsers;
        public StudentsService(IStudentRepository studentRepository, IStudentParser studentParsers)
        {
            _studentRepository = studentRepository;
            _studentParsers = studentParsers;
        }

        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file.
        /// </summary>
        public async Task<IStudent[]> GetAllAsync(int pageIndex)
        {
            return await _studentRepository.GetAllAsync(pageIndex);
        }

        /// <summary>
        /// Async method that saves entities into DB.
        /// </summary>
        public async Task ImportStudentsAsync(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(formFile.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await ExcelImportAsync(formFile);
            }
            else if (fileExtension == ".csv")
            {
                await CsvImportAsync(formFile);
            }
            else if (fileExtension == ".xml")
            {
                await XmlImportAsync(formFile);
            }
            else
            {
                throw new Exception("wrong file extension");
            }
        }

        /// <summary>
        /// Parse student's file from xml.
        /// </summary>
        public async Task XmlImportAsync(IFormFile formFile)
        {
            var studentsXml = await _studentParsers.XmlParseAsync(formFile);

            await _studentRepository.AddRangeAsync(studentsXml);
        }

        /// <summary>
        /// Parse student's file from csv.
        /// </summary>
        public async Task CsvImportAsync(IFormFile formFile)
        {
            var studentsCsv = await _studentParsers.CsvParseAsync(formFile);

            await _studentRepository.AddRangeAsync(studentsCsv);
        }

        /// <summary>
        /// Parse student's file from excel.
        /// </summary>
        public async Task ExcelImportAsync(IFormFile formFile)
        {
            var studentsExcel = await _studentParsers.ExcelParseAsync(formFile);

            await _studentRepository.AddRangeAsync(studentsExcel);
        }
    }
}
