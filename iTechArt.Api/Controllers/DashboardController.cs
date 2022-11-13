using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ITotalStatisticsService _statsService;

        public DashboardController(ITotalStatisticsService statsService)
        {
            _statsService = statsService;
        }

        /// <summary>
        /// Returns total numbers of entities in db.
        /// </summary>
        [HttpGet("count-of-users")]
        public async Task<IActionResult> TotalAmountsAsync()
        {
            return Ok(await _statsService.GetCountOfUsersAsync());
        }
    }
}
