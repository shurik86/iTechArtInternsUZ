using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IGenerateExcel;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentParser _studentParsers;
        private readonly IGenerateStudentsExcel _generateStudentsExcel;
        private readonly IGenerateStudentXml _generateStudentXml;
        private readonly IStreamToArray _streamToArray;


        public StudentsService(IStudentRepository studentRepository, 
                               IStudentParser studentParsers, 
                               IGenerateStudentsExcel generateStudentsExcel, 
                               IGenerateStudentXml generateStudentXml, 
                               IStreamToArray streamToArray)
        {
            _studentRepository = studentRepository;
            _studentParsers = studentParsers;
            _generateStudentsExcel = generateStudentsExcel;
            _generateStudentXml = generateStudentXml;
            _streamToArray = streamToArray;
        }

        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file.
        /// </summary>
        [HttpGet()]
        public async Task<IStudent[]> ExportStudentsAsync(int pageIndex)
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
            await _studentParsers.XmlParseAsync(formFile);
        }

        /// <summary>
        /// Parse student's file from csv.
        /// </summary>
        public async Task CsvImportAsync(IFormFile formFile)
        {
            await _studentParsers.CsvParseAsync(formFile);
        }

        /// <summary>
        /// Parse student's file from excel.
        /// </summary>
        public async Task ExcelImportAsync(IFormFile formFile)
        {
            await _studentParsers.ExcelParseAsync(formFile);
        }

        /// <summary>
        /// Exports Students Data to a new XML file.
        /// </summary>
        public async Task<byte[]> ExportXmlAsync()
        {
            XmlDocument xmlDocument = await _generateStudentXml.GetStudentsXmlAsync();
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports Students Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generateStudentsExcel.GetStudentsExcelAsync();
        }
    }
}
