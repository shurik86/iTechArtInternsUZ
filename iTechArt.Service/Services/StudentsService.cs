using CsvHelper;
using CsvHelper.Configuration;
﻿using AutoMapper;
using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.Dtos.Students;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IParser _parser;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentExcelGenerate _generateStudentExcel;
        private readonly IStudentXmlGenerate _generateStudentXml;
        private readonly IStreamToArray _streamToArray;

        public StudentsService(IStudentRepository studentRepository, 
                               IStudentExcelGenerate generateStudentExcel, 
                               IStudentXmlGenerate generateStudentXml, 
                               IStreamToArray streamToArray,
                               IParser parser,
                               IMapper mapper)
        {
            _parser = parser;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _generateStudentExcel = generateStudentExcel;
            _generateStudentXml = generateStudentXml;
            _streamToArray = streamToArray;
        }

        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file.
        /// </summary>
        public async Task<IStudent[]> GetAllAsync(int pageIndex, int pageSize)
        {
            return await _studentRepository.GetAllAsync(pageIndex, pageSize);
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
            var studentsXml = await _parser.XmlParseAsync<StudentXml>(formFile);

            var studentDto = studentsXml.Students.Select(s => _mapper.Map<StudentDto>(s));

            await _studentRepository.AddRangeAsync(studentDto);
        }

        /// <summary>
        /// Parse student's file from csv.
        /// </summary>
        public async Task CsvImportAsync(IFormFile formFile)
        {
            var studentsCsv = await _parser.CsvParseAsync<StudentMap, StudentDto>(formFile);

            await _studentRepository.AddRangeAsync(studentsCsv);
        }

        /// <summary>
        /// Parse student's file from excel.
        /// </summary>
        public async Task ExcelImportAsync(IFormFile formFile)
        {
            var studentsExcel = await _parser.ExcelParseAsync<StudentDto>(formFile);

            await _studentRepository.AddRangeAsync(studentsExcel);
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
            return await _generateStudentExcel.GetExcelAsync();
        }

        /// <summary>
        /// Exports Students Data to a new Csv file.
        /// </summary>
        public async Task<byte[]> ExportCsvAsync()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                AllowComments = false,
            };
            var groceryList = await _studentRepository.GetAllAsync();
            await using var ms = new MemoryStream();
            await using var writer = new StreamWriter(ms);
            await using CsvWriter cs = new CsvWriter(writer, csvConfig);
            cs.WriteHeader<IStudent>();
            cs.NextRecord();
            foreach (var record in groceryList)
            {
                cs.WriteRecord(record);
                cs.NextRecord();
            }
            var res = ms.ToArray();
            return res;
        }
    }
}
