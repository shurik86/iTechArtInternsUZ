using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class MedStaffService : IMedStaffService
    {
        private readonly IMedStaffRepository _medStaffRepository;
        private readonly IMedStaffParser _medStaffParser;
        private readonly IGenerateMedStaffXml _generateMedStaffXml;

        public MedStaffService(IMedStaffRepository medStaffRepository, 
                               IMedStaffParser medStaffParser,
                               IGenerateMedStaffXml generateMedStaffXml)
        {
            _medStaffRepository = medStaffRepository;
            _medStaffParser = medStaffParser;
            _generateMedStaffXml = generateMedStaffXml;
        }

        /// <summary>
        /// Takes no input so far.
        /// </summary>
        public async Task<IMedStaff[]> ExportMedStaffFileAsync()
        {
            return await _medStaffRepository.GetAllAsync();
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task CSVParseAsync(IFormFile file)
        {
            await _medStaffParser.ParseCSVAsync(file);
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task ExcelParseAsync(IFormFile file)
        {
            await _medStaffParser.ParseExcelAsync(file);
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
            using (var memoryStream = new MemoryStream())
            {
                xmlDocument.Save(memoryStream);
                await memoryStream.FlushAsync();
                return memoryStream.ToArray();
            }
        }
    }
}
