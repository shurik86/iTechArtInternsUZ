using AutoMapper;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using ITechArt.Parsers.Dtos;
using ITechArt.Parsers.Parsers;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public sealed class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IGenericParser _genericParser;
        private readonly IMapper _mapper;

        public PupilService(IPupilRepository pupilRepository, 
                            IGenericParser genericParser, 
                            IMapper mapper)
        {
            _pupilRepository = pupilRepository;
            _genericParser = genericParser;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all pupils.
        /// </summary>
        public async Task<IPupil[]> GetAllAsync(int pageIndex)
        {
            return await _pupilRepository.GetAllAsync(pageIndex);
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
    }
}
