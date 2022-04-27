using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Beis.LearningPlatform.Api.Controllers
{
    [ApiController]
	[Route("api/diagnostictoolemailanswer")]
	public class DiagnosticToolEmailAnswerController : ControllerBase
	{
		private readonly IDiagnosticToolEmailAnswerRepository _diagnosticToolEmailAnswerRepository;

		public DiagnosticToolEmailAnswerController(IDiagnosticToolEmailAnswerRepository diagnosticToolEmailAnswerRepository)
		{
			_diagnosticToolEmailAnswerRepository = diagnosticToolEmailAnswerRepository;
		}

		[HttpOptions]
		public IActionResult GetDiagnosticToolEmailAnswerOptions()
		{
			HttpContext.Response.Headers.Add("Allow", "OPTIONS,GET,POST,PUT,DELETE");
			return Ok();
		}

		[HttpGet("{id:int}", Name = "GetDiagnosticToolEmailAnswer")]
		public async Task<IActionResult> GetDiagnosticToolEmailAnswer(int id)
		{
			var diagnosticToolEmailAnswer = await _diagnosticToolEmailAnswerRepository.GetById(id);

			if (diagnosticToolEmailAnswer == null)
			{
				return NotFound();
			}

			return Ok(diagnosticToolEmailAnswer);
		}

        [HttpGet]
        public async Task<IActionResult> GetDiagnosticToolEmailAnswers([FromQuery] PaginationParameter paginationParameter)
        {
            if (paginationParameter == null || !paginationParameter.IsValid())
            {
                return BadRequest();
            }

            var diagnosticToolEmailAnswers = await _diagnosticToolEmailAnswerRepository.GetPaginated(paginationParameter);
            return Ok(diagnosticToolEmailAnswers);
        }

        [HttpGet("{userEmailAddress}", Name = "GetDiagnosticToolEmailAnswerByEmail")]
        public async Task<IActionResult> GetDiagnosticToolEmailAnswerByEmail(string userEmailAddress)
        {
            var diagnosticToolEmailAnswers = await _diagnosticToolEmailAnswerRepository.GetByUserEmailAddress(userEmailAddress);

            if (diagnosticToolEmailAnswers == null || !diagnosticToolEmailAnswers.Any())
            {
                return NotFound();
            }

            return Ok(diagnosticToolEmailAnswers);
        }

		[HttpPost]
		public async Task<ActionResult<DiagnosticToolEmailAnswer>> CreateDiagnosticToolEmailAnswer(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer)
		{
			if (diagnosticToolEmailAnswer == null)
			{
				return BadRequest();
			}

			var id = await _diagnosticToolEmailAnswerRepository.Add(diagnosticToolEmailAnswer);
			if (!id.HasValue)
			{ 
				return BadRequest();
			}
			diagnosticToolEmailAnswer.Id = id.Value;
			return CreatedAtRoute("GetDiagnosticToolEmailAnswer", new { id = id.Value }, diagnosticToolEmailAnswer);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateDiagnosticToolEmailAnswer(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer)
		{			
			var rowCount = await _diagnosticToolEmailAnswerRepository.Update(diagnosticToolEmailAnswer);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteDiagnosticToolEmailAnswer(int id)
		{			
			var rowCount = await _diagnosticToolEmailAnswerRepository.DeleteById(id);
			if (rowCount == 0)
			{ 
				return NotFound();
			}
			return NoContent();
		}
	}
}