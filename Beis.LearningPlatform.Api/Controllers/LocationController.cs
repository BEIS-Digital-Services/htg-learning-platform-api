using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Beis.LearningPlatform.Api.Controllers
{
    [ApiController]
	[Route("api/location")]
	public class LocationController : ControllerBase
	{
		private readonly ILocationRepository _locationRepository;

		public LocationController(ILocationRepository locationRepository)
		{
			_locationRepository = locationRepository;
		}

		[HttpOptions]
		public IActionResult GetLocationOptions()
		{
			HttpContext.Response.Headers.Add("Allow", "OPTIONS,GET,POST,PUT,DELETE");
			return Ok();
		}

		[HttpGet("{id:int}", Name = "GetLocation")]
		public async Task<IActionResult> GetLocation(int id)
		{
			var location = await _locationRepository.GetById(id);

			if (location == null)
			{
				return NotFound();
			}

			return Ok(location);
		}

        [HttpGet]
        public async Task<IActionResult> GetLocations([FromQuery] PaginationParameter paginationParameter)
        {
            if (paginationParameter == null || !paginationParameter.IsValid())
            {
                return BadRequest();
            }

            var locations = await _locationRepository.GetPaginated(paginationParameter);
            return Ok(locations);
        }

		[HttpPost]
		public async Task<ActionResult<Location>> CreateLocation(Location location)
		{
			if (location == null)
			{
				return BadRequest();
			}

			var id = await _locationRepository.Add(location);
			if (!id.HasValue)
			{ 
				return BadRequest();
			}
			location.Id = id.Value;
			return CreatedAtRoute("GetLocation", new { id = id.Value }, location);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateLocation(Location location)
		{			
			var rowCount = await _locationRepository.Update(location);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteLocation(int id)
		{			
			var rowCount = await _locationRepository.DeleteById(id);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}
	}
}