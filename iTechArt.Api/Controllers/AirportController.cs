using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route(RouteConstants.AIRPORT)]
    [ApiController]
    public sealed class AirportController : ControllerBase
    {
        private readonly IAirportsService _airportsService;

        public AirportController(IAirportsService airportsService)
        {
            _airportsService = airportsService;
        }

        /// <summary>
        /// Controller of Importing airport data.
        /// </summary>
        [HttpPost(ApiConstants.IMPORT), Obsolete]
        public async Task<IActionResult> ImportAirportExcelAsync(IFormFile file)
        {
            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (FileConstants.Extensions.Contains(fileExtension))
                {
                    await _airportsService.ImportAirportFileAsync(file);
                    return Ok();
                }
            }
                
            return BadRequest("Invalid file format!");
        }

        /// <summary>
        /// Controller of Exporting airport data.
        /// </summary>
        [HttpGet("get_all")]
        public async Task<IActionResult> ExportAirportExcelAsync(int pageIndex)
        {
            return Ok(await _airportsService.ExportAirportExcelAsync(pageIndex));
        }

        /// <summary>
        /// Imports excel file.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async Task<IActionResult> ImportExcelFileAsync(IFormFile file)
        {
            await _airportsService.AirportExcelParseAsync(file);
            return Ok();
        }

        /// <summary>
        /// Imports csv file.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async Task<IActionResult> ImportCsvFileAsync(IFormFile file)
        {
            await _airportsService.AirportCSVParseAsync(file);
            return Ok();
        }

        /// <summary>
        /// Imports xml file.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTXML)]
        public async Task<IActionResult> ImportXmlFileAsync(IFormFile file)
        {
            await _airportsService.AirportXMLParseAsync(file);
            return Ok();
        }
    }
}
