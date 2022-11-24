using AutoMapper;
using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.Dtos.Pupils;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IParser _parser;
        private readonly IMapper _mapper;
        private readonly IPupilExcelGenerate _generatePupilExcel;
        private readonly IPupilXmlGenerate _generatePupilXml;
        private readonly IStreamToArray _streamToArray;

        public PupilService(IPupilRepository pupilRepository, 
                            IParser parser, 
                            IMapper mapper, 
                            IPupilExcelGenerate generatePupilExcel, 
                            IPupilXmlGenerate generatePupilXml, 
                            IStreamToArray streamToArray)
        {
            _pupilRepository = pupilRepository;
            _parser = parser;
            _mapper = mapper;
            _generatePupilExcel = generatePupilExcel;
            _generatePupilXml = generatePupilXml;
            _streamToArray = streamToArray;
        }


        /// <summary>
        /// Get all pupils.
        /// </summary>
        public async Task<IPupil[]> GetAllAsync(int pageIndex, int pageSize)
        {
            return await _pupilRepository.GetAllAsync(pageIndex, pageSize);
        }

        /// <summary>
        /// Import pupil's file.
        /// </summary>
        [Obsolete]
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
            var pupilsFromExcel = await _parser.ExcelParseAsync<PupilDto>(file);

            await _pupilRepository.AddRangeAsync(pupilsFromExcel);
        }

        /// <summary>
        /// Parse pupil's file from csv.
        /// </summary>
        public async Task ImportCsvAsync(IFormFile file)
        {
            var pupilsFromCsv = await _parser.CsvParseAsync<PupilMap, PupilDto>(file);

            await _pupilRepository.AddRangeAsync(pupilsFromCsv);
        }

        /// <summary>
        /// Parse pupil's file from xml.
        /// </summary>
        public async Task ImportXmlAsync(IFormFile file)
        {
            var pupilsFromXml = await _parser.XmlParseAsync<PupilXml>(file);

            var pupilsDto = pupilsFromXml.Pupils.Select(p => _mapper.Map<PupilDto>(p));

            await _pupilRepository.AddRangeAsync(pupilsDto);
        }

        /// <summary>
        /// Exports Pupils Data to a new XML file.
        /// </summary>
        public async Task<byte[]> ExportXmlAsync()
        {
            XmlDocument xmlDocument = await _generatePupilXml.GetPupilsXmlAsync();
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports Pupils Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generatePupilExcel.GetExcelAsync();
        }
    }
}
