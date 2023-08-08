using CityInfo.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [ApiController] // this attribute is not required but it configures this controller aimed at improving developement experience
    [Route("api/cities")] // [controller] will evaluate to 'cities'
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            // Method 1: manually setting status code 
            // var temp = new JsonResult(CitiesDataStore.Current.Cities);
            // temp.StatusCode = 200;
            //new JsonResult(CitiesDataStore.Current.Cities);

            // Method 2: Use existing methods from ControllerBase which implements an IActionResult which has corresponding status code already!
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        //public JsonResult GetCity(int id)
        public ActionResult<CityDto> GetCity(int id)
        {
            //return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id) );
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id) );
            if (cityToReturn == null)
                return NotFound();

            return Ok(cityToReturn); // this will return the city with a 200 status code.

        }
    }
}
