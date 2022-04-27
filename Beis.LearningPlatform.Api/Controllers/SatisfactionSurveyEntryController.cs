using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Beis.LearningPlatform.Api.Controllers
{
    [ApiController]
	[Route("api/satisfactionsurveyentry")]
	public class SatisfactionSurveyEntryController : ControllerBase
	{
		private readonly ISatisfactionSurveyEntryRepository _satisfactionSurveyEntryRepository;

		public SatisfactionSurveyEntryController(ISatisfactionSurveyEntryRepository satisfactionSurveyEntryRepository)
		{
			_satisfactionSurveyEntryRepository = satisfactionSurveyEntryRepository;
		}

		[HttpOptions]
		public IActionResult GetSatisfactionSurveyEntryOptions()
		{
			HttpContext.Response.Headers.Add("Allow", "OPTIONS,GET,POST,PUT,DELETE");
			return Ok();
		}

		[HttpGet("{id:int}", Name = "GetSatisfactionSurveyEntry")]
		public async Task<IActionResult> GetSatisfactionSurveyEntry(int id)
		{
			var satisfactionSurveyEntry = await _satisfactionSurveyEntryRepository.GetById(id);

			if (satisfactionSurveyEntry == null)
			{
				return NotFound();
			}

			return Ok(satisfactionSurveyEntry);
		}

        [HttpGet]
        public async Task<IActionResult> GetSatisfactionSurveyEntrys([FromQuery] PaginationParameter paginationParameter)
        {
            if (paginationParameter == null || !paginationParameter.IsValid())
            {
                return BadRequest();
            }

            var satisfactionSurveyEntries = await _satisfactionSurveyEntryRepository.GetPaginated(paginationParameter);
            return Ok(satisfactionSurveyEntries);
        }

		[HttpPost]
		public async Task<ActionResult<SatisfactionSurveyEntry>> CreateSatisfactionSurveyEntry(SatisfactionSurveyEntry satisfactionSurveyEntry)
		{
			if (satisfactionSurveyEntry == null)
			{
				return BadRequest();
			}

			var id = await _satisfactionSurveyEntryRepository.Add(satisfactionSurveyEntry);
			if (!id.HasValue)
			{ 
				return BadRequest();
			}
			satisfactionSurveyEntry.Id = id.Value;
			return CreatedAtRoute("GetSatisfactionSurveyEntry", new { id = id.Value }, satisfactionSurveyEntry);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSatisfactionSurveyEntry(SatisfactionSurveyEntry satisfactionSurveyEntry)
		{			
			var rowCount = await _satisfactionSurveyEntryRepository.Update(satisfactionSurveyEntry);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteSatisfactionSurveyEntry(int id)
		{			
			var rowCount = await _satisfactionSurveyEntryRepository.DeleteById(id);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}
	}
}