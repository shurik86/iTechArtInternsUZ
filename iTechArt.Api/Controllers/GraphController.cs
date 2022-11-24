using iTechArt.Api.Constants;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route(RouteConstants.GRAPH)]
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
        [HttpGet(ApiConstants.GETGRAPH)]
         public async ValueTask<IActionResult> GetGraphDataAsync()
        {
            return Ok(await _genderGraphService.GetGraphDataAsync());
        }
    }
}
