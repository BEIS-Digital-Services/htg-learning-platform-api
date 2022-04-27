using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Beis.LearningPlatform.Api.Controllers
{
    [ApiController]
	[Route("api/skillsoneresponse")]
	public class SkillsOneResponseController : ControllerBase
	{
		private readonly ISkillsOneResponseRepository _skillsOneResponseRepository;

		public SkillsOneResponseController(ISkillsOneResponseRepository skillsOneResponseRepository)
		{
			_skillsOneResponseRepository = skillsOneResponseRepository;
		}

		[HttpOptions]
		public IActionResult GetSkillsOneResponseOptions()
		{
			HttpContext.Response.Headers.Add("Allow", "OPTIONS,GET,POST,PUT,DELETE");
			return Ok();
		}

		[HttpGet("{id:int}", Name = "GetSkillsOneResponse")]
		public async Task<IActionResult> GetSkillsOneResponse(int id)
		{
			var skillsOneResponse = await _skillsOneResponseRepository.GetById(id);

			if (skillsOneResponse == null)
			{
				return NotFound();
			}

			return Ok(skillsOneResponse);
		}

        [HttpGet]
        public async Task<IActionResult> GetSkillsOneResponses([FromQuery] PaginationParameter paginationParameter)
        {
            if (paginationParameter == null || !paginationParameter.IsValid())
            {
                return BadRequest();
            }

            var skillsOneResponses = await _skillsOneResponseRepository.GetPaginated(paginationParameter);
            return Ok(skillsOneResponses);
        }

		[HttpPost]
		public async Task<ActionResult<SkillsOneResponse>> CreateSkillsOneResponse(SkillsOneResponse skillsOneResponse)
		{
			if (skillsOneResponse == null)
			{
				return BadRequest();
			}

			var id = await _skillsOneResponseRepository.Add(skillsOneResponse);
			if (!id.HasValue)
			{ 
				return BadRequest();
			}
			skillsOneResponse.Id = id.Value;
			return CreatedAtRoute("GetSkillsOneResponse", new { id = id.Value }, skillsOneResponse);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSkillsOneResponse(SkillsOneResponse skillsOneResponse)
		{			
			var rowCount = await _skillsOneResponseRepository.Update(skillsOneResponse);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteSkillsOneResponse(int id)
		{			
			var rowCount = await _skillsOneResponseRepository.DeleteById(id);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}
	}
}