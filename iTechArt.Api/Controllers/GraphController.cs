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
        private readonly IGetRetirementInfoService _getRetirementInfoService;
        private readonly IFacultyInfoService _facultyInfoService;

        public GraphController(IGenderGraphService genderGraphService, 
                               IGetRetirementInfoService getRetirementInfoService, 
                               IFacultyInfoService facultyInfoService)
        {
            _genderGraphService = genderGraphService;
            _getRetirementInfoService = getRetirementInfoService;
            _facultyInfoService = facultyInfoService;
        }
        /// <summary>
        /// Provides collection of data for 5 tables including table name, count of males and females.
        /// </summary>
        [HttpGet(ApiConstants.GETGRAPH)]
         public async ValueTask<IActionResult> GetGraphDataAsync()
        {
            return Ok(await _genderGraphService.GetGraphDataAsync());
        }

        /// <summary>
        /// Provides collection of data for 3 tables including info about retired stuff.
        /// </summary>
        [HttpGet(ApiConstants.GETRETIREMENT)]
        public async ValueTask<IActionResult> GetRetirementDataAsync(int from, int to)
        {
            return Ok(await _getRetirementInfoService.GetRetiredPeopleAsync(from, to));
        }

        /// <summary>
        /// Provides collection of data about how many students are in each faculty.
        /// </summary>
        [HttpGet(ApiConstants.GetFacultyInfo)]
        public async ValueTask<IActionResult> GetFacultyInfoAsync()
        {
            return Ok(await _facultyInfoService.GetFacultyInfo());
        }
    }
}
