using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    public class GraphController : ControllerBase
    {
        private readonly IGenderGraphService _genderGraphService;
        public GraphController(IGenderGraphService genderGraphService)
        {
            _genderGraphService = genderGraphService;
        }
        /// <summary>
        /// Provides collection of data for 5 tables including table name, count of males and females.
        /// </summary>
        [HttpGet("get_graph")]
         public async ValueTask<IActionResult> GetGraphDataAsync()
        {
            return Ok(await _genderGraphService.GetGraphDataAsync());
        }
    }
}
