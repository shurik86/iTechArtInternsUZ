using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.Dtos;
using ITechArt.Parsers.Parsers;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IGenericParser _genericParser;
        private readonly IMapper _mapper;
        private readonly IPupilExcelGenerate _generatePupilExcel;
        private readonly IPupilXmlGenerate _generatePupilXml;
        private readonly IStreamToArray _streamToArray;

        public PupilService(IPupilRepository pupilRepository, 
                            IGenericParser genericParser, 
                            IMapper mapper, 
                            IPupilExcelGenerate generatePupilExcel, 
                            IPupilXmlGenerate generatePupilXml, 
                            IStreamToArray streamToArray)
        {
            _pupilRepository = pupilRepository;
            _genericParser = genericParser;
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
            var pupilsFromExcel = await _genericParser.ExcelParseAsync<PupilDto>(file);

            await _pupilRepository.AddRangeAsync(pupilsFromExcel);
        }

        /// <summary>
        /// Parse pupil's file from csv.
        /// </summary>
        public async Task ImportCsvAsync(IFormFile file)
        {
            var pupilsFromCsv = await _genericParser.CsvParseAsync<PupilMap, PupilDto>(file);

            await _pupilRepository.AddRangeAsync(pupilsFromCsv);
        }

        /// <summary>
        /// Parse pupil's file from xml.
        /// </summary>
        public async Task ImportXmlAsync(IFormFile file)
        {
            var pupilsFromXml = await _genericParser.XmlParseAsync<PupilXml>(file);

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

        /// <summary>
        /// Exports pupils Data to a new Csv file.
        /// </summary>
        public async Task<byte[]> ExportCsvAsync()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                AllowComments = false,
            };
            var dataList = await _pupilRepository.GetAllAsync();
            await using var ms = new MemoryStream();
            await using var writer = new StreamWriter(ms);
            await using CsvWriter cs = new CsvWriter(writer, csvConfig);
            cs.WriteHeader<IPupil>();
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
