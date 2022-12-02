using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;
using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using iTechArt.Service.Parsers;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Xml;
using IParser = iTechArt.Domain.ParserInterfaces.IParser;

namespace iTechArt.Service.Services
{
    public sealed class AirportService : IAirportsService
    {
        private readonly IParser _parser;
        private readonly IAirportRepository _airportRepository;
        private readonly IAirportExcelGenerate _generateAirportExcel;
        private readonly IAirportParsers _airportParsers;
        private readonly IAirportXmlGenerate _generateAirportXml;
        private readonly IStreamToArray _streamToArray;

        public AirportService(IAirportRepository airportRepository, 
                              IAirportParsers airportParsers,
                              IAirportExcelGenerate generateAirportExcel,
                              IAirportXmlGenerate generateAirportXml,
                              IStreamToArray streamToArray,
                              IParser parser)
        {
            _airportRepository = airportRepository;
            _airportParsers = airportParsers;
            _generateAirportExcel = generateAirportExcel;
            _generateAirportXml = generateAirportXml;
            _streamToArray = streamToArray;
            _parser = parser;
        }

        /// <summary>
        /// Exporting airport datas.
        /// </summary>
        public async Task<IAirport[]> ExportAirportExcelAsync(int pageIndex, int pageSize, string fieldName, 
            SortDirection sortDirection, IAirportFilter airportFilter)
        {
            return await _airportRepository.GetAllAsync(pageIndex, pageSize, fieldName, sortDirection, airportFilter);
        }

        /// <summary>
        /// Import airport's file.
        /// </summary>
        public async Task ImportAirportFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (FileConstants.excelExtensions.Contains(fileExtension))
            {
                await AirportExcelParseAsync(file);
            }
            else if (FileConstants.csvExtensions.Contains(fileExtension))
            {
                await AirportCSVParseAsync(file);
            }
            else if (FileConstants.xmlExtensions.Contains(fileExtension))
            {
                await AirportXMLParseAsync(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Importing airport datas from excel file.
        /// </summary>
        public async Task AirportExcelParseAsync(IFormFile file)
        {
            var airportsFromExcel = await _parser.ExcelParseAsync<AirportDTO>(file);

            await _airportRepository.AddRangeAsync(airportsFromExcel);
        }

        /// <summary>
        /// Importing airport datas from csv file.
        /// </summary>
        public async Task AirportCSVParseAsync(IFormFile file)
        {
            var airportsFromCsv = await _parser.CsvParseAsync<AirportMap, AirportDTO>(file);

            await _airportRepository.AddRangeAsync(airportsFromCsv);
        }

        /// <summary>
        /// Importing airport datas from xml file.
        /// </summary>
        public async Task AirportXMLParseAsync(IFormFile file)
        {
            await _airportParsers.XmlParserAsync(file);
        }

        /// <summary>
        /// Exports Airport Data to a new XML file.
        /// </summary>
        public async Task<byte[]> ExportXmlAsync()
        {
            XmlDocument xmlDocument = await _generateAirportXml.GetAirportXmlAsync();
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports Airport Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generateAirportExcel.GetExcelAsync();
        }


        /// <summary>
        /// Exports Airport Data to a new Csv file.
        /// </summary>
        public async Task<byte[]> ExportCsvAsync()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                AllowComments = false,
            };
            var dataList = await _airportRepository.GetAllAsync();
            await using var ms = new MemoryStream();
            await using var writer = new StreamWriter(ms);
            await using CsvWriter cs = new CsvWriter(writer, csvConfig);
            cs.WriteHeader<IAirport>();
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
