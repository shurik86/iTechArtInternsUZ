using iTechArt.Api.Constants;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController, Route(RouteConstants.MEDSTAFF)]
    public sealed class MedStaffController : ControllerBase
    {
        private readonly IMedStaffService _medStaffService;
        private readonly IGetRetirementInfoService _getRetirementInfo;

        public MedStaffController(IMedStaffService medStaffService, IGetRetirementInfoService getRetirementInfo)
        {
            _medStaffService = medStaffService;
            _getRetirementInfo = getRetirementInfo;
        }

        /// <summary>
        /// Uploads file and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORT), Obsolete]
        public async Task<IActionResult> ImportAsync(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _medStaffService.ImportMedStaffFileAsync(file);

                    return Ok();
                }
            }
                        
            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Uploads excel file and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async Task<IActionResult> ImportExcelAsync(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                {
                    await _medStaffService.ExcelParseAsync(file);

                    return Ok();
                }
            }

            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Uploads csv file and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async Task<IActionResult> ImportCSVAsync(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == ".csv")
                {
                    await _medStaffService.CSVParseAsync(file);

                    return Ok();
                }
            }

            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Uploads xml file and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTXML)]
        public async Task<IActionResult> ImportXMLAsync(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == ".xml")
                {
                    await _medStaffService.XMLParseAsync(file);

                    return Ok();
                }
            }

            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Gets all data from database.
        /// </summary>
        [HttpGet("get_all")]
        public async Task<ActionResult<IMedStaff[]>> ExportAsync([FromQuery] int pageIndex, int pageSize)
        {
            return Ok(await _medStaffService.ExportMedStaffFileAsync(pageIndex, pageSize));
        }

        /// <summary>
        /// Exports MedStaff table to Xml file.
        /// </summary>
        [HttpGet("get_xml")]
        public async Task<ActionResult> ExportXmlFile()
        {
            byte[] streamArray = await _medStaffService.ExportXmlAsync();
            return new FileContentResult(streamArray, FileConstants.XmlContent)
            {
                FileDownloadName = $"{FileConstants.MedStaff}_{Guid.NewGuid().ToString()}{FileConstants.xml}"
            };
        }

        /// <summary>
        /// Exports MedStaff table from Database to Excel file.
        /// </summary>
        [HttpGet("get_xlsx")]
        public async Task<ActionResult> ExportExcelFile()
        {
            byte[] streamArray = await _medStaffService.ExportExcelAsync();
            return new FileContentResult(streamArray, FileConstants.ExcelContent)
            {
                FileDownloadName = $"{FileConstants.MedStaff}_{Guid.NewGuid().ToString()}{FileConstants.xlsx}"
            };
        }

        /// <summary>
        /// Gets retirement info about medstaffs from database.
        /// </summary>
        [HttpGet("get_retired")]
        public async Task<ActionResult> GetRetiredMedStaffs(int from, int to)
        {
            return Ok(await _getRetirementInfo.GetRetiredPeopleAsync(from, to));
        }
    }
}
