using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.Repositories;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class AirportService : IAirportsService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IGenerateAirportExcel _generateAirportExcel;
        private readonly IAirportParsers _airportParsers;
        private readonly IGenerateAirportXml _generateAirportXml;
        private readonly IStreamToArray _streamToArray;

        public AirportService(IAirportRepository airportRepository, 
                              IAirportParsers airportParsers,
                              IGenerateAirportExcel generateAirportExcel,
                              IGenerateAirportXml generateAirportXml,
                              IStreamToArray streamToArray)
        {
            _airportRepository = airportRepository;
            _airportParsers = airportParsers;
            _generateAirportExcel = generateAirportExcel;
            _generateAirportXml = generateAirportXml;
            _streamToArray = streamToArray;
        }

        /// <summary>
        /// Exporting airport datas.
        /// </summary>
        public async Task<IAirport[]> ExportAirportExcelAsync(int pageIndex)
        {
            return await _airportRepository.GetAllAsync(pageIndex);
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
            await _airportParsers.ExcelParserAsync(file);
        }

        /// <summary>
        /// Importing airport datas from csv file.
        /// </summary>
        public async Task AirportCSVParseAsync(IFormFile file)
        {
            await _airportParsers.CsvParserAsync(file);
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
    }
}
