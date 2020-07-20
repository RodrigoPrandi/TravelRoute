using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelRouteApi.Dto;
using TravelRouteApi.Exceptions;
using TravelRouteApi.Service;

namespace TravelRouteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestRouteController : ControllerBase
    {
        private readonly IBestRouteService bestRouteService;

        public BestRouteController(IBestRouteService bestRouteService)
        {
            this.bestRouteService = bestRouteService;
        }

        [HttpGet]
        public ActionResult<BestRoute> Get(string from, string to)
        {
            try
            {
                var bestRoute = bestRouteService.CalcBestRoute(new Route(from, to));
                return Ok(bestRoute);
            }
            catch(BusinessException e)
            {
                return ValidationProblem(e.Message, null, StatusCodes.Status400BadRequest);
            }
        }
    }
}
