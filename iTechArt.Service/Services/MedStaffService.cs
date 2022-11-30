﻿using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.Dtos.MedStaffs;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Xml;
using IParser = iTechArt.Domain.ParserInterfaces.IParser;

namespace iTechArt.Service.Services
{
    public sealed class MedStaffService : IMedStaffService
    {
        private readonly IParser _parser;
        private readonly IMedStaffRepository _medStaffRepository;
        private readonly IMedStaffParser _medStaffParser;
        private readonly IMedStaffExcelGenerate _generateMedStaffExcel;
        private readonly IMedStaffXmlGenerate _generateMedStaffXml;
        private readonly IStreamToArray _streamToArray;

        public MedStaffService(IMedStaffRepository medStaffRepository, 
                               IMedStaffParser medStaffParser, 
                               IMedStaffExcelGenerate generateMedStaffExcel, 
                               IMedStaffXmlGenerate generateMedStaffXml, 
                               IStreamToArray streamToArray,
                               IParser parser)
        {
            _medStaffRepository = medStaffRepository;
            _medStaffParser = medStaffParser;
            _generateMedStaffExcel = generateMedStaffExcel;
            _generateMedStaffXml = generateMedStaffXml;
            _streamToArray = streamToArray;
            _parser = parser;
        }


        /// <summary>
        /// Takes no input so far.
        /// </summary>
        public async Task<IMedStaff[]> ExportMedStaffFileAsync(int pageIndex, int pageSize, string fieldName, SortDirection sortDirection)
        {
            return await _medStaffRepository.GetAllAsync(pageIndex, pageSize, fieldName, sortDirection);
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task CSVParseAsync(IFormFile file)
        {
            var medStaffsFromCsv = await _parser.CsvParseAsync<MedStaffMap, MedStaffDto>(file);

            await _medStaffRepository.AddRangeAsync(medStaffsFromCsv);
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task ExcelParseAsync(IFormFile file)
        {
            var medStaffsFromExcel = await _parser.ExcelParseAsync<MedStaffDto>(file);

            await _medStaffRepository.AddRangeAsync(medStaffsFromExcel);
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task XMLParseAsync(IFormFile file)
        {
            await _medStaffParser.ParseXMLAsync(file);
        }

        /// <summary>
        /// Takes filestream.
        /// </summary>
        public async Task ImportMedStaffFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await _medStaffParser.ParseExcelAsync(file);
            }
            else if (fileExtension == ".csv")
            {
                await _medStaffParser.ParseCSVAsync(file);
            }
            else if (fileExtension == ".xml")
            {
                await _medStaffParser.ParseXMLAsync(file);
            }
        }

        /// <summary>
        /// Exports MedStaff Data to a new XML file.
        /// </summary>
        public async Task<byte[]> ExportXmlAsync()
        {
            XmlDocument xmlDocument = await _generateMedStaffXml.GetMedStaffXmlAsync();
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports MedStaff Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generateMedStaffExcel.GetExcelAsync();
        }

        /// <summary>
        /// Exports MedStaff Data to a new Csv file.
        /// </summary>
        public async Task<byte[]> ExportCsvAsync()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                AllowComments = false,
            };
            var dataList = await _medStaffRepository.GetAllAsync();
            await using var ms = new MemoryStream();
            await using var writer = new StreamWriter(ms);
            await using CsvWriter cs = new CsvWriter(writer, csvConfig);
            cs.WriteHeader<IMedStaff>();
            cs.NextRecord();
            foreach (var record in dataList)
            {
                cs.WriteRecord(record);
                cs.NextRecord();
            }
            var res = ms.ToArray();
            return res;
        }
    }
}
