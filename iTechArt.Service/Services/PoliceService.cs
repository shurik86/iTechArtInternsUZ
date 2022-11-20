using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IPoliceParsers;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.Dtos.Polices;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        private readonly IParser _parser;
        private readonly IPoliceRepository _policeRepository;
        private readonly ICsvParse _csvParse;
        private readonly IExcelParse _excelParse;
        private readonly IXmlParse _xmlParse;
        private readonly IPoliceExcelGenerate _generatePoliceExcel;
        private readonly IStreamToArray _streamToArray;
        private readonly IPoliceXmlGenerate _generatePoliceXml;

        public PoliceService(IPoliceRepository policeRepository, 
                             ICsvParse csvParse, 
                             IExcelParse excelParse, 
                             IXmlParse xmlParse, 
                             IPoliceExcelGenerate generatePoliceExcel, 
                             IStreamToArray streamToArray, 
                             IPoliceXmlGenerate generatePoliceXml,
                             IParser parser)
        {
            _policeRepository = policeRepository;
            _csvParse = csvParse;
            _excelParse = excelParse;
            _xmlParse = xmlParse;
            _generatePoliceExcel = generatePoliceExcel;
            _streamToArray = streamToArray;
            _generatePoliceXml = generatePoliceXml;
            _parser = parser;
        }

        /// <summary>
        /// Get all data from the databse.
        /// </summary>
        public async Task<IPolice[]> GetAllPoliceAsync(int pageIndex, int pageSize)
        {
            return await _policeRepository.GetAllAsync(pageIndex, pageSize);
        }

        /// <summary>
        /// Import XLSX or XLS data to the database.
        /// </summary>
        public async Task ImportExcelAsync(IFormFile formFile)
        {
            var policesArr = await _parser.ExcelParseAsync<PoliceDto>(formFile);
            await _policeRepository.AddRangeAsync(policesArr);
        }


        /// <summary>
        /// Import XML data to the database.
        /// </summary>
        public async Task ImportXmlAsync(IFormFile formFile)
        {
            var policesArr = await _xmlParse.ParseXMLAsync(formFile);
            await _policeRepository.AddRangeAsync(policesArr);
        }


        /// <summary>
        /// Import CSV data to the database.
        /// </summary>
        public async Task ImportCsvAsync(IFormFile formFile)
        {
            var policesArr = await _parser.CsvParseAsync<PoliceMap, PoliceDto>(formFile);
            await _policeRepository.AddRangeAsync(policesArr);
        }

        /// <summary>
        /// Exports Police Data to a new XML file.
        /// </summary>
        public async Task<byte[]> ExportXmlAsync()
        {
            XmlDocument xmlDocument = await _generatePoliceXml.GetPoliceXmlAsync();
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports Police Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generatePoliceExcel.GetExcelAsync();
        }
    }
}