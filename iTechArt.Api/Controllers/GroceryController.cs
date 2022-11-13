using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.GROCERIES)]
    public sealed class GroceryController : Controller
    {
        private readonly IGroceryService _groceryService;
        private const string CSV = "csv";
        private const string EXCEL = "officedocument.spreadsheetml.sheet";
        private const string XML = "xml";

        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        [HttpPost(ApiConstants.IMPORT),Obsolete]
        public async ValueTask<IActionResult> ImportGroceryFilesAsync(IFormFile file)
        {
            if (file != null && file.ContentType.Contains(CSV))
            {
                await _groceryService.ImportCSVGroceryAsync(file);
                return Ok();
            }
            else if (file != null && file.ContentType.Contains(EXCEL)) 
            {
                await _groceryService.ImportExcelGroceryAsync(file);
                return Ok();
            }
            else if (file != null && file.ContentType.Contains(XML))
            {
                await _groceryService.ImportXMLGroceryAsync(file);
                return Ok();
            }
            return BadRequest();
        }
        /// <summary>
        /// Api route which applies the following extensions
        /// will allow to upload the data from CSV file to db.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTCSV)]
        public async ValueTask<IActionResult> ImportCsvGroceryFileAsync(IFormFile file)
        {
            if (file != null && file.ContentType.Contains(CSV))
            {
                await _groceryService.ImportCSVGroceryAsync(file);
                return Ok();
            }
            else
            return BadRequest();

        }
        /// <summary>
        /// Api route which applies the following extensions
        /// will allow to upload the data from Excel file to db.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTEXCEL)]
        public async ValueTask<IActionResult> ImportExcelGroceryFileAsync(IFormFile file)
        {
            if (file != null && file.ContentType.Contains(EXCEL))
            {
                await _groceryService.ImportExcelGroceryAsync(file);
                return Ok();
            }
            else
                return BadRequest();

        }
        /// <summary>
        /// Api route which applies the following extensions
        /// will allow to upload the data from XML file to db.
        /// </summary>
        [HttpPost(ApiConstants.IMPORTXML)]
        public async ValueTask<IActionResult> ImportXMLGroceryFileAsync(IFormFile file)
        {
            if (file != null && file.ContentType.Contains(XML))
            {
                await _groceryService.ImportXMLGroceryAsync(file);
                return Ok();
            }
            else
                return BadRequest();
        }
        /// <summary>
        /// Api route which allows to get all info from db and parse it to the following format.
        /// </summary>
        [HttpGet("get_all")]
        public async Task<IActionResult> ExportGroceryDataAsync([FromQuery] int pageIndex)
        {
            return Ok(await _groceryService.ExportGroceryAsync(pageIndex));
        }
        /// <summary>
        /// Get total amount of groceries
        /// </summary>

        //[HttpGet(ApiConstants.GETCOUNTOFGROCERY)]
        //public IActionResult GetCountOfGrocery()
        //{
        //    return Ok(_groceryService.GetCountOfGrocery());
        //}
    }
}
