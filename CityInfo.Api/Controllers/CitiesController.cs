using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [ApiController] // not required but it gives better developement experience
    [Route("api/cities")] // [controller] will evaluate to 'cities'
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object> {
                new { id = 1, Name = "Manila"},
                new { id = 2, Name = "Christchurch"}
            });
        }
    }
}
