using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Beis.LearningPlatform.Api.Controllers
{
	[ApiController]
	[Route("api/feedbackpageuseful")]
	public class FeedbackPageUsefulController : ControllerBase
	{
		private readonly IFeedbackPageUsefulRepository _feedbackPageUsefulRepository;

		public FeedbackPageUsefulController(IFeedbackPageUsefulRepository feedbackPageUsefulRepository)
		{
			_feedbackPageUsefulRepository = feedbackPageUsefulRepository;
		}

		[HttpOptions]
		public IActionResult GetFeedbackPageUsefulOptions()
		{
			HttpContext.Response.Headers.Add("Allow", "OPTIONS,GET,POST,PUT,DELETE");
			return Ok();
		}

		[HttpGet("{id:int}", Name = "GetFeedbackPageUseful")]
		public async Task<IActionResult> GetFeedbackPageUseful(int id)
		{
			var feedbackPageUseful = await _feedbackPageUsefulRepository.GetById(id);

			if (feedbackPageUseful == null)
			{
				return NotFound();
			}

			return Ok(feedbackPageUseful);
		}

        [HttpGet]
        public async Task<IActionResult> GetFeedbackPageUsefuls([FromQuery] PaginationParameter paginationParameter)
        {
            if (paginationParameter == null || !paginationParameter.IsValid())
            {
                return BadRequest();
            }

            var feedbackPageUsefuls = await _feedbackPageUsefulRepository.GetPaginated(paginationParameter);
            return Ok(feedbackPageUsefuls);
        }

		[HttpPost]
		public async Task<ActionResult<FeedbackPageUseful>> CreateFeedbackPageUseful(FeedbackPageUseful feedbackPageUseful)
		{
			if (feedbackPageUseful == null)
			{
				return BadRequest();
			}

			var id = await _feedbackPageUsefulRepository.Add(feedbackPageUseful);
			if (!id.HasValue)
			{ 
				return BadRequest();
			}
			feedbackPageUseful.Id = id.Value;
			return CreatedAtRoute("GetFeedbackPageUseful", new { id = id.Value }, feedbackPageUseful);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeedbackPageUseful(FeedbackPageUseful feedbackPageUseful)
		{			
			var rowCount = await _feedbackPageUsefulRepository.Update(feedbackPageUseful);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteFeedbackPageUseful(int id)
		{			
			var rowCount = await _feedbackPageUsefulRepository.DeleteById(id);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}
	}
}