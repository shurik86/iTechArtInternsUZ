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
    public sealed class MedStaffService : IMedStaffService
    {
        private readonly IMedStaffRepository _medStaffRepository;
        private readonly IMedStaffParser _medStaffParser;
        private readonly IGenerateMedStaffXml _generateMedStaffXml;
        private readonly IGenerateMedStaffExcel _generateMedStaffExcel;
        private readonly IStreamToArray _streamToArray;

        public MedStaffService(IMedStaffRepository medStaffRepository, 
                               IMedStaffParser medStaffParser,
                               IGenerateMedStaffXml generateMedStaffXml,
                               IGenerateMedStaffExcel generateMedStaffExcel,
                               IStreamToArray streamToArray)
        {
            _medStaffRepository = medStaffRepository;
            _medStaffParser = medStaffParser;
            _generateMedStaffXml = generateMedStaffXml;
            _generateMedStaffExcel = generateMedStaffExcel;
            _streamToArray = streamToArray;
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
            return await _streamToArray.XmlStreamToArrayAsync(xmlDocument);
        }

        /// <summary>
        /// Exports MedStaff Data to a new Excel file.
        /// </summary>
        public async Task<byte[]> ExportExcelAsync()
        {
            return await _generateMedStaffExcel.GetMedStaffExcelAsync();
        }
    }
}
