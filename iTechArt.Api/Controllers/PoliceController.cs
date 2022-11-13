using iTechArt.Api.Constants;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.POLICE)]
    public sealed class PoliceController : ControllerBase
    {
        private readonly IPoliceService _policeService;

        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
        }

        /// <summary>
        /// route: api/police/import. Takes xlsx.
        /// Uploads xslx data about Police and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async Task<IActionResult> ImportExcelAsync(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension == FileConstants.xlsx || fileExtension == FileConstants.xls)
                {
                    await _policeService.ImportExcelAsync(file);
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid file format!");
                }
            }
            else
            {
                return BadRequest("No input found!");
            }
        }


        /// <summary>
        /// route: api/police/import. Takes xml.
        /// Uploads xml data about Police and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTXML)]
        public async Task<IActionResult> ImportXmlAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (file != null && fileExtension == FileConstants.xml)
            {
                await _policeService.ImportXmlAsync(file);
                return Ok();
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// route: api/police/import. Takes csv.
        /// Uploads csv data about Police and saves in database.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async Task<IActionResult> ImportCsvAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (file != null && fileExtension == FileConstants.csv)
            {
                await _policeService.ImportCsvAsync(file);
                return Ok();
            }
            else
            {
                return BadRequest("Invalid file format!");
            }
        }

        /// <summary>
        /// route: api/police/export.
        /// Gets all data about police from the database.
        /// </summary>
        [HttpGet("get_all")]
        public async Task<ActionResult<IPolice[]>> GetAllDataAsync([FromQuery] int pageIndex)
        {
            return Ok(await _policeService.GetAllPoliceAsync(pageIndex));
        }
    }
}