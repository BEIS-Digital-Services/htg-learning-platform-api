using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Beis.LearningPlatform.Api.Controllers
{
    [ApiController]
	[Route("api/feedbackproblemreport")]
	public class FeedbackProblemReportController : ControllerBase
	{
		private readonly IFeedbackProblemReportRepository _feedbackProblemReportRepository;

		public FeedbackProblemReportController(IFeedbackProblemReportRepository feedbackProblemReportRepository)
		{
			_feedbackProblemReportRepository = feedbackProblemReportRepository;
		}

		[HttpOptions]
		public IActionResult GetFeedbackProblemReportOptions()
		{
			HttpContext.Response.Headers.Add("Allow", "OPTIONS,GET,POST,PUT,DELETE");
			return Ok();
		}

		[HttpGet("{id:int}", Name = "GetFeedbackProblemReport")]
		public async Task<IActionResult> GetFeedbackProblemReport(int id)
		{
			var feedbackProblemReport = await _feedbackProblemReportRepository.GetById(id);

			if (feedbackProblemReport == null)
			{
				return NotFound();
			}

			return Ok(feedbackProblemReport);
		}

        [HttpGet]
        public async Task<IActionResult> GetFeedbackProblemReports([FromQuery] PaginationParameter paginationParameter)
        {
            if (paginationParameter == null || !paginationParameter.IsValid())
            {
                return BadRequest();
            }

            var feedbackProblemReports = await _feedbackProblemReportRepository.GetPaginated(paginationParameter);
            return Ok(feedbackProblemReports);
        }

		[HttpPost]
		public async Task<ActionResult<FeedbackProblemReport>> CreateFeedbackProblemReport(FeedbackProblemReport feedbackProblemReport)
		{
			if (feedbackProblemReport == null)
			{
				return BadRequest();
			}

			var id = await _feedbackProblemReportRepository.Add(feedbackProblemReport);
			if (!id.HasValue)
			{ 
				return BadRequest();
			}
			feedbackProblemReport.Id = id.Value;
			return CreatedAtRoute("GetFeedbackProblemReport", new { id = id.Value }, feedbackProblemReport);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeedbackProblemReport(FeedbackProblemReport feedbackProblemReport)
		{			
			var rowCount = await _feedbackProblemReportRepository.Update(feedbackProblemReport);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteFeedbackProblemReport(int id)
		{			
			var rowCount = await _feedbackProblemReportRepository.DeleteById(id);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}
	}
}