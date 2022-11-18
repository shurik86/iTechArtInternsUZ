using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.IPoliceParsers;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        private readonly IPoliceRepository _policeRepository;
        private readonly ICsvParse _csvParse;
        private readonly IExcelParse _excelParse;
        private readonly IXmlParse _xmlParse;
        private readonly IGeneratePoliceExcel _generatePoliceExcel;
        private readonly IStreamToArray _streamToArray;
        private readonly IGeneratePoliceXml _generatePoliceXml;

        public PoliceService(IPoliceRepository policeRepository, 
                             ICsvParse csvParse, 
                             IExcelParse excelParse, 
                             IXmlParse xmlParse, 
                             IGeneratePoliceExcel generatePoliceExcel, 
                             IStreamToArray streamToArray, 
                             IGeneratePoliceXml generatePoliceXml)
        {
            _policeRepository = policeRepository;
            _csvParse = csvParse;
            _excelParse = excelParse;
            _xmlParse = xmlParse;
            _generatePoliceExcel = generatePoliceExcel;
            _streamToArray = streamToArray;
            _generatePoliceXml = generatePoliceXml;
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
            var policesArr = await _excelParse.ParseExcelAsync(formFile);
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
            var policesArr = await _csvParse.ParseCSVAsync(formFile);
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