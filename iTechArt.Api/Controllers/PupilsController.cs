using iTechArt.Api.Constants;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.PUPIL)]
    public sealed class PupilsController : ControllerBase
    {
        private readonly IPupilService _pupilService;
        public PupilsController(IPupilService pupilService)
        {
            _pupilService = pupilService;
        }

        /// <summary>
        /// Upload pupil's file
        /// </summary>
        [HttpPost(ApiConstants.IMPORT), Obsolete]
        public async Task<ActionResult> ImportAsync(IFormFile file)
        {
            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _pupilService.ImportPupilsFileAsync(file);
                    return Ok();
                }
            }
            
            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Get all pupils
        /// </summary>
        [HttpGet("get_all")]
        public async Task<ActionResult<IPupil[]>> GetAllAsync([FromQuery] int pageIndex, int pageSize, string fieldName, SortDirection sortDirection)
        {
            return Ok(await _pupilService.GetAllAsync(pageIndex, pageSize, fieldName, sortDirection));
        }

        /// <summary>
        /// Parse pupil's file from excel
        /// </summary>
        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async Task<ActionResult> ImportExcelFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _pupilService.ImportExcelAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse pupil's file from csv
        /// </summary>
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async Task<ActionResult> ImportCsvFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _pupilService.ImportCsvAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse pupil's file from xml
        /// </summary>
        [HttpPost(ApiConstants.IMPORTXML)]
        public async Task<ActionResult> ImportXmlFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _pupilService.ImportXmlAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Exports Pupils table to XML file.
        /// </summary>
        [HttpGet("get_xml")]
        public async Task<ActionResult> ExportXmlFile()
        {
            byte[] streamArray = await _pupilService.ExportXmlAsync();
            return new FileContentResult(streamArray, FileConstants.XmlContent)
            {
                FileDownloadName = $"{FileConstants.Pupils}_{Guid.NewGuid().ToString()}{FileConstants.xml}"
            };
        }

        /// <summary>
        /// Exports Pupils table from Database to Excel file.
        /// </summary>
        [HttpGet("get_xlsx")]
        public async Task<ActionResult> ExportExcelFile()
        {
            byte[] streamArray = await _pupilService.ExportExcelAsync();
            return new FileContentResult(streamArray, FileConstants.ExcelContent)
            {
                FileDownloadName = $"{FileConstants.Pupils}_{Guid.NewGuid().ToString()}{FileConstants.xlsx}"
            };
        }

        /// <summary>
        /// Exports Pupils table from Database to Csv file.
        /// </summary>
        [HttpGet("get_csv")]
        public async Task<ActionResult> ExportCsvFile()
        {
            byte[] streamArray = await _pupilService.ExportCsvAsync();
            return new FileContentResult(streamArray, "text/csv")
            {
                FileDownloadName = $"{FileConstants.Pupils}_{Guid.NewGuid().ToString()}{FileConstants.csv}"
            };
        }
    }
}
