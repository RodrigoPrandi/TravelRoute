using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelRouteApi.Dto;
using TravelRouteApi.Exceptions;
using TravelRouteApi.Service;

namespace TravelRouteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService routeService;

        public RouteController(IRouteService routeService)
        {
            this.routeService = routeService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<string> Post([FromBody] RouteValue routeValue)
        {
            try
            {
                routeService.Save(routeValue);
                return Created("api/route", routeValue);
            }
            catch (BusinessException e)
            {
                return ValidationProblem(e.Message, null, StatusCodes.Status400BadRequest);
            }
        }
    }
}
