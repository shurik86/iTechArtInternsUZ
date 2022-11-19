using iTechArt.Api.Constants;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route(RouteConstants.STUDENTS)]
    [ApiController]
    public sealed class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        public StudentsController(IStudentsService studentService)
        {
            _studentsService = studentService;
        }

        /// <summary>
        /// Takes csv or xlsx file.
        /// </summary>
        [HttpPost(ApiConstants.IMPORT), Obsolete]
        public async Task<ActionResult> ImportAsync(IFormFile file)
        {
            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _studentsService.ImportStudentsAsync(file);
                    return Ok();
                }
            }
             
            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Get all students.
        /// </summary>
        [HttpGet("get_all")]
        public async Task<ActionResult<IStudent[]>> GetAllAsync([FromQuery] int pageIndex)
        {
            return Ok(await _studentsService.GetAllAsync(pageIndex));
        }

        /// <summary>
        /// Parse student's file from excel.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async Task<ActionResult> ImportExcelFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _studentsService.ExcelImportAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse student's file from csv.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async Task<ActionResult> ImportCsvFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _studentsService.CsvImportAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Parse student's file from xml.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTXML)]
        public async Task<ActionResult> ImportXmlFileAsync(IFormFile file)
        {
            if (file is not null)
            {
                await _studentsService.XmlImportAsync(file);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Exports Students table to XML file.
        /// </summary>
        [HttpGet("get_xml")]
        public async Task<ActionResult> ExportXmlFile()
        {
            byte[] streamArray = await _studentsService.ExportXmlAsync();
            return new FileContentResult(streamArray, FileConstants.XmlContent)
            {
                FileDownloadName = $"{FileConstants.Students}_{Guid.NewGuid().ToString()}{FileConstants.xml}"
            };
        }

        /// <summary>
        /// Exports Students table from Database to Excel file.
        /// </summary>
        [HttpGet("get_xlsx")]
        public async Task<ActionResult> ExportExcelFile()
        {
            byte[] streamArray = await _studentsService.ExportExcelAsync();
            return new FileContentResult(streamArray, FileConstants.ExcelContent)
            {
                FileDownloadName = $"{FileConstants.Students}_{Guid.NewGuid().ToString()}{FileConstants.xlsx}"
            };
        }
    }
}
