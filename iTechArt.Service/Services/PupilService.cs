using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IGenerateExcel;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IPupilParser _pupilParsers;
        private readonly IGeneratePupilsXml _generatePupilsXml;
        private readonly IGeneratePupilsExcel _generatePupilsExcel;
        private readonly IStreamToArray _streamToArray;

        public PupilService(IPupilRepository pupilRepository, 
                            IPupilParser pupilParsers,
                            IGeneratePupilsXml generatePupilsXml,
                            IStreamToArray streamToArray,
                            IGeneratePupilsExcel generatePupilsExcel)
        {
            _pupilRepository = pupilRepository;
            _pupilParsers = pupilParsers;
            _generatePupilsXml = generatePupilsXml;
            _streamToArray = streamToArray;
            _generatePupilsExcel = generatePupilsExcel;
        }

        /// <summary>
        /// Get all pupils.
        /// </summary>
        public async Task<IPupil[]> GetAllAsync()
        {
            return await _pupilRepository.GetAllAsync();
        }

        /// <summary>
        /// Import pupil's file.
        /// </summary>
        public async Task ImportPupilsFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await ImportExcelAsync(file);
            }
            else if (fileExtension == ".csv")
            {
                await ImportCsvAsync(file);
            }
            else if (fileExtension == ".xml")
            {
                await ImportXmlAsync(file);
            }
        }

        /// <summary>
        /// Parse pupil's file from excel.
        /// </summary>
        public async Task ImportExcelAsync(IFormFile file)
        {
            var pupilsFromExcel = await _pupilParsers.ExcelParseAsync(file);

            await _pupilRepository.AddRangeAsync(pupilsFromExcel);
        }

        /// <summary>
        /// Parse pupil's file from csv.
        /// </summary>
        public async Task ImportCsvAsync(IFormFile file)
        {
            var pupilsFromCsv = await _pupilParsers.CsvParseAsync(file);

            await _pupilRepository.AddRangeAsync(pupilsFromCsv);
        }

        /// <summary>
        /// Parse pupil's file from xml.
        /// </summary>
        public async Task ImportXmlAsync(IFormFile file)
        {
            var pupilsFromXml = await _pupilParsers.XmlParseAsync(file);
         
            await _pupilRepository.AddRangeAsync(pupilsFromXml);
        }

        /// <summary>
        /// Exports Pupils Data to a new XML file.
        /// </summary>
        public async Task<byte[]> ExportXmlAsync()
        {
            XmlDocument xmlDocument = await _generatePupilsXml.GetPupilsXmlAsync();
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports Pupils Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generatePupilsExcel.GetPupilsExcelAsync();
        }
    }
}
