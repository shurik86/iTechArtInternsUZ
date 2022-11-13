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
        /// Controller of Importing airport data
        /// </summary>
        /// <param name="file"></param>
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
        /// Controller of Exporting airport data
        /// </summary>
        [HttpGet("get_all")]
        public async Task<IActionResult> ExportAirportExcelAsync(int pageIndex)
        {
            return Ok(await _airportsService.ExportAirportExcelAsync(pageIndex));
        }

        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async Task<IActionResult> ImportExcelFileAsync(IFormFile file)
        {
            await _airportsService.AirportExcelParserAsync(file);
            return Ok();
        }
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async Task<IActionResult> ImportCsvFileAsync(IFormFile file)
        {
            await _airportsService.AirportCSVParserAsync(file);
            return Ok();
        }
        [HttpPost(ApiConstants.IMPORTXML)]
        public async Task<IActionResult> ImportXmlFileAsync(IFormFile file)
        {
            await _airportsService.AirportXMLParserAsync(file);
            return Ok();
        }
    }
}
